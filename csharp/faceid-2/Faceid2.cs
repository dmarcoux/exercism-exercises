using System;
using System.Collections.Generic;

public class FacialFeatures(string eyeColor, decimal philtrumWidth) : IEquatable<FacialFeatures>
{
    public string EyeColor { get; } = eyeColor;
    public decimal PhiltrumWidth { get; } = philtrumWidth;

    public override bool Equals(object obj) => this.Equals(obj as FacialFeatures);

    public bool Equals(FacialFeatures other)
    {
        if (other is null)
            return false;

        if (Object.ReferenceEquals(this, other))
            return true;

        if (this.GetType() != other.GetType())
            return false;

        return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
    }

    public override int GetHashCode() => (EyeColor, PhiltrumWidth).GetHashCode();

    public static bool operator ==(FacialFeatures lhs, FacialFeatures rhs)
    {
        if (lhs is null)
            return (rhs is null);

        return lhs.Equals(rhs);
    }

    public static bool operator !=(FacialFeatures lhs, FacialFeatures rhs) => !(lhs == rhs);
}

public class Identity(string email, FacialFeatures facialFeatures) : IEquatable<Identity>
{
    public string Email { get; } = email;
    public FacialFeatures FacialFeatures { get; } = facialFeatures;

    public override bool Equals(object obj) => this.Equals(obj as Identity);

    public bool Equals(Identity other)
    {
        if (other is null)
            return false;

        if (Object.ReferenceEquals(this, other))
            return true;

        if (this.GetType() != other.GetType())
            return false;

        return Email == other.Email && FacialFeatures == other.FacialFeatures;
    }

    public override int GetHashCode() => (Email, FacialFeatures).GetHashCode();

    public static bool operator ==(Identity lhs, Identity rhs)
    {
        if (lhs is null)
            return (rhs is null);

        return lhs.Equals(rhs);
    }

    public static bool operator !=(Identity lhs, Identity rhs) => !(lhs == rhs);
}

public class Authenticator
{
    private HashSet<Identity> _identities = new HashSet<Identity>();
    private static readonly Identity _adminIdentity = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA == faceB;

    public bool IsAdmin(Identity identity) => _adminIdentity == identity;

    public bool Register(Identity identity) => _identities.Add(identity);

    public bool IsRegistered(Identity identity) => _identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => Object.ReferenceEquals(identityA, identityB);
}