using System;
using System.Linq;
using System.Runtime.CompilerServices;

class BirdCount
{
    private int[] _birdsPerDay;

    public BirdCount(int[] birdsPerDay) => this._birdsPerDay = birdsPerDay;

    public static int[] LastWeek() => [0, 2, 5, 3, 7, 8, 4];

    public int Today() => this._birdsPerDay.Last();

    public void IncrementTodaysCount()
    {
        int todayIndex = this._birdsPerDay.Length - 1;
        this._birdsPerDay[todayIndex] += 1;
    }

    public bool HasDayWithoutBirds() => this._birdsPerDay.Contains(0);

    public int CountForFirstDays(int numberOfDays) => this._birdsPerDay.Take(numberOfDays).Sum();

    public int BusyDays() => this._birdsPerDay.Count(birds => birds >= 5);
}
