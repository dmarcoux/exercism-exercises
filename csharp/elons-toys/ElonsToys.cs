using System;

class RemoteControlCar
{
    private int _batteryPercentage = 100;
    private int _distanceDriven = 0;
    
    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {_distanceDriven} meters";

    public string BatteryDisplay()
    {
        if (_batteryPercentage == 0)
        {
            return "Battery empty";
        }

        return $"Battery at {_batteryPercentage}%";
    }

    public void Drive()
    {
        if (_batteryPercentage == 0)
        {
            return;
        }

        _distanceDriven += 20;
        _batteryPercentage -= 1;
    }
}
