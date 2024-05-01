using System;

class RemoteControlCar(int speed, int batteryDrain)
{
    private int _batteryLeft = 100;
    private int _distanceDriven = 0;

    public bool BatteryDrained() => (_batteryLeft - batteryDrain) < 0;

    public int DistanceDriven() => _distanceDriven;

    public void Drive()
    {
        if (BatteryDrained()) return;

        _distanceDriven += speed;
        _batteryLeft -= batteryDrain;
    }

    public static RemoteControlCar Nitro() => new(speed: 50, batteryDrain: 4);
}

class RaceTrack(int distance)
{
    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained() && car.DistanceDriven() < distance)
        {
            car.Drive();
        }

        return car.DistanceDriven() >= distance;
    }
}
