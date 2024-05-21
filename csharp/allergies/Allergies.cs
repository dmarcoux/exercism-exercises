using System;
using System.Collections;
using System.Linq;

[Flags]
public enum Allergen : byte
{
    Eggs         = 1,
    Peanuts      = 1 << 1,
    Shellfish    = 1 << 2,
    Strawberries = 1 << 3,
    Tomatoes     = 1 << 4,
    Chocolate    = 1 << 5,
    Pollen       = 1 << 6,
    Cats         = 1 << 7,
}

public class Allergies(int originalScore)
{
    // Every bit in an allergy score represents an allergy. We only consider the first 8 bits, so we can safely cast originalScore to byte.
    private readonly byte _relevantScore = (byte)originalScore;

    public bool IsAllergicTo(Allergen allergen) => (_relevantScore & (byte)allergen) != 0;

    public Allergen[] List() => Enum.GetValues<Allergen>().Where(IsAllergicTo).ToArray();
}