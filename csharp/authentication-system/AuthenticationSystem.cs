using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Authenticator(Identity admin)
{
    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }

    private readonly IDictionary<string, Identity> _developers
        = new ReadOnlyDictionary<string, Identity>(new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = "blue"
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = "brown"
            }
        });

    public Identity Admin => admin;

    public IDictionary<string, Identity> GetDevelopers() => _developers;
}

public struct Identity
{
    public string Email { get; set; }

    public string EyeColor { get; set; }
}