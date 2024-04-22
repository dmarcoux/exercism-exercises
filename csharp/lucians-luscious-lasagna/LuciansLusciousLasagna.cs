class Lasagna
{
    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int minutes) => ExpectedMinutesInOven() - minutes;

    public int PreparationTimeInMinutes(int numberOfLayers) => numberOfLayers * 2;

    public int ElapsedTimeInMinutes(int numberOfLayers, int minutesSinceInOven) => PreparationTimeInMinutes(numberOfLayers) + minutesSinceInOven;
}
