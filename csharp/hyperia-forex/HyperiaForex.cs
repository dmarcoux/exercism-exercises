using System;

public struct CurrencyAmount(decimal amount, string currency) : IEquatable<CurrencyAmount>, IComparable<CurrencyAmount>
{
    public decimal Amount { get; } = amount;

    public string Currency { get; } = currency;

    #region IEquatable
    public override bool Equals(object obj) => obj is CurrencyAmount other && Equals(other);

    public bool Equals(CurrencyAmount other)
    {
        if (Currency != other.Currency)
            throw new ArgumentException("Comparing different currencies is not supported.");

        return Amount == other.Amount && Currency == other.Currency;
    }

    public override int GetHashCode() => (Amount, Currency).GetHashCode();

    public static bool operator ==(CurrencyAmount lhs, CurrencyAmount rhs) => lhs.Equals(rhs);

    public static bool operator !=(CurrencyAmount lhs, CurrencyAmount rhs) => !(lhs == rhs);
    #endregion

    #region IComparable
    public int CompareTo(CurrencyAmount other)
    {
        if (Currency != other.Currency)
            throw new ArgumentException("Comparing different currencies is not supported.");

        return Amount.CompareTo(other.Amount);
    }

    public int CompareTo(object obj)
        => obj is CurrencyAmount other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(CurrencyAmount)}");

    public static bool operator >(CurrencyAmount lhs, CurrencyAmount rhs) => lhs.CompareTo(rhs) > 0;

    public static bool operator <(CurrencyAmount lhs, CurrencyAmount rhs) => lhs.CompareTo(rhs) < 0;
    #endregion

    #region Arithmetic
    public static CurrencyAmount operator +(CurrencyAmount lhs, CurrencyAmount rhs)
    {
         if (lhs.Currency != rhs.Currency)
             throw new ArgumentException("Comparing different currencies is not supported.");

         return new CurrencyAmount(currency: lhs.Currency, amount: lhs.Amount + rhs.Amount);
    }

    public static CurrencyAmount operator -(CurrencyAmount lhs, CurrencyAmount rhs)
    {
         if (lhs.Currency != rhs.Currency)
             throw new ArgumentException("Comparing different currencies is not supported.");

         return new CurrencyAmount(currency: lhs.Currency, amount: lhs.Amount - rhs.Amount);
    }

    public static CurrencyAmount operator *(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        if (lhs.Currency != rhs.Currency)
            throw new ArgumentException("Comparing different currencies is not supported.");

        return new CurrencyAmount(currency: lhs.Currency, amount: lhs.Amount * rhs.Amount);
    }

    public static CurrencyAmount operator /(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        if (lhs.Currency != rhs.Currency)
            throw new ArgumentException("Comparing different currencies is not supported.");

        return new CurrencyAmount(currency: lhs.Currency, amount: lhs.Amount / rhs.Amount);
    }
    #endregion

    #region Conversion
    public static explicit operator double(CurrencyAmount currencyAmount) => (double)currencyAmount.Amount;

    public static implicit operator decimal(CurrencyAmount currencyAmount) => currencyAmount.Amount;
    #endregion
}