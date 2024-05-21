using System;
using System.Collections.Generic;
using System.Linq;

public class Robot
{
    private static readonly HashSet<string> ExistingRobotNames = [];
    private const string LettersForName = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string NumbersForName = "0123456789";

    public Robot() => Name = GenerateRandomName();

    public string Name { get; private set; }

    public void Reset()
    {
        ExistingRobotNames.Remove(Name);
        Name = GenerateRandomName();
    }

    private string GenerateRandomName()
    {
        string newName;

        do
        {
            string letters = new string(Enumerable.Repeat(LettersForName, 2).Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
            string numbers = new string(Enumerable.Repeat(NumbersForName, 3).Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
            newName = string.Concat(letters, numbers);
        } while (!ExistingRobotNames.Add(newName));

        return newName;
    }
}