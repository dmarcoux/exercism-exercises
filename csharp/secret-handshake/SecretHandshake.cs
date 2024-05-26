using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class SecretHandshake
{
    [Flags]
    enum Command : byte
    {
        Wink              = 1,
        DoubleBlink       = 1 << 1,
        CloseYourEyes     = 1 << 2,
        Jump              = 1 << 3,
        ReverseEverything = 1 << 4,
    }
    public static string[] Commands(int commandValue)
    {
        // Only keep the first 5 bits, everything else is irrelevant
        byte relevantCommands = (byte)(0b1_1111 & commandValue);

        IEnumerable<Command> commands = Enum.GetValues<Command>().Where(command => ((byte)command & relevantCommands) != 0);

        // If the command ReverseEverything is part of the commands, all the other commands have to be returned in a reverse order
        if (commands.Contains(Command.ReverseEverything))
        {
            commands = commands.Reverse().Skip(1);
        }

        return commands.Select(c => ConvertPascalCaseToLowercaseSentence(c.ToString())).ToArray();
    }

    private static string ConvertPascalCaseToLowercaseSentence(string str)
    {
        return Regex.Replace(str, "[a-z][A-Z]", m => $"{m.Value[0]} {char.ToLower(m.Value[1])}")
            .ToLower();
    }
}
