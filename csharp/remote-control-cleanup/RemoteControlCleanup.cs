public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }
    public ITelemetry Telemetry { get; }
    private Speed currentSpeed;

    public RemoteControlCar()
    {
        Telemetry = new RemoteControlCarTelemetry(this);
    }

    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = SpeedUnits == SpeedUnits.CentimetersPerSecond ? "centimeters" : "meters";

            return $"{Amount} {unitsString} per second";
        }
    }

    private class RemoteControlCarTelemetry(RemoteControlCar parent) : ITelemetry
    {
        private RemoteControlCar _parent = parent;

        public void Calibrate() { }

        public bool SelfTest() => true;

        public void ShowSponsor(string sponsorName) => _parent.SetSponsor(sponsorName);

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = unitsString == "cps" ? SpeedUnits.CentimetersPerSecond : SpeedUnits.MetersPerSecond;

            _parent.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    public string GetSpeed() => currentSpeed.ToString();

    private void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;

    private void SetSpeed(Speed speed) => currentSpeed = speed;
}

public enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond
}

public interface ITelemetry
{
    public void Calibrate();
    public bool SelfTest();
    public void ShowSponsor(string sponsorName);
    public void SetSpeed(decimal amount, string unitsString);
}