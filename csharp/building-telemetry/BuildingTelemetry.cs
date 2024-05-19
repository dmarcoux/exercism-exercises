using System;

public class RemoteControlCar
{
    private int _batteryPercentage = 100;
    private int _distanceDrivenInMeters = 0;
    private string[] _sponsors = [];
    private int _latestSerialNum = 0;

    public void Drive()
    {
        if (_batteryPercentage < 0)
            return;

        _batteryPercentage -= 10;
        _distanceDrivenInMeters += 2;
    }

    public void SetSponsors(params string[] sponsors) => _sponsors = sponsors;

    public string DisplaySponsor(int sponsorNum) => _sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum, out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum < _latestSerialNum)
        {
            serialNum = _latestSerialNum;
            batteryPercentage = distanceDrivenInMeters = -1;
            return false;
        }

        _latestSerialNum = serialNum;
        batteryPercentage = this._batteryPercentage;
        distanceDrivenInMeters = this._distanceDrivenInMeters;
        return true;
    }

    public static RemoteControlCar Buy() => new RemoteControlCar();
}

public class TelemetryClient(RemoteControlCar car)
{
    public string GetBatteryUsagePerMeter(int serialNum)
    {
        if (car.GetTelemetryData(ref serialNum, out int batteryPercentage, out int distanceDrivenInMeters) && distanceDrivenInMeters > 0)
            return $"usage-per-meter={(100 - batteryPercentage) / distanceDrivenInMeters}";

        return "no data";
    }
}