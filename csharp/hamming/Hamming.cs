using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException("Strands must have the same length.");

        return firstStrand.Zip(secondStrand).Count(bases => bases.First != bases.Second);
    }
}