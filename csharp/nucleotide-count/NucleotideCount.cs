using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> count = new Dictionary<char, int>()
        {
            { 'A', 0 },
            { 'C', 0 },
            { 'G', 0 },
            { 'T', 0 },
        };

        foreach (char nucleotide in sequence)
        {
            if (!count.ContainsKey(nucleotide))
                throw new ArgumentException($"Invalid nucleotide {nucleotide} in DNA sequence.");

            count[nucleotide] += 1;
        }

        return count;
    }
}