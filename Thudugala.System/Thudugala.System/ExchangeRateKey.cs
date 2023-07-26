using System;
using Thudugala.System.Exceptions;

namespace Thudugala.System;

/// <summary>
///
/// </summary>
public class ExchangeRateKey : IComparable, IComparable<ExchangeRateKey>, IEquatable<ExchangeRateKey>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="fromCurrency">Money Currency</param>
    /// <param name="toCurrency">Money to be Currency</param>
    /// <param name="recordedAt"></param>
    public ExchangeRateKey(CurrencyCode fromCurrency, CurrencyCode toCurrency, DateTime recordedAt)
    {
        FromCurrency = fromCurrency;
        ToCurrency = toCurrency;
        RecordedAt = recordedAt;
    }

    /// <summary>
    /// Money Currency
    /// </summary>
    public CurrencyCode FromCurrency { get; }

    /// <summary>
    /// Money to be Currency
    /// </summary>
    public CurrencyCode ToCurrency { get; }

    /// <summary>
    /// Rate Recorded At
    /// </summary>
    public DateTime RecordedAt { get; }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"{FromCurrency} to {ToCurrency} at {RecordedAt}";

    #region Equality

    /// <summary>
    ///
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ExchangeRateKey left, ExchangeRateKey right) => !(left == right);

    /// <summary>
    ///
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ExchangeRateKey left, ExchangeRateKey right) => left.Equals(right);

    /// <summary>
    ///
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ExchangeRateKey other)
    {
        return other is not null &&
            (ReferenceEquals(this, other) ||
             (CurrencyCode.Equals(FromCurrency, other.FromCurrency) &&
              CurrencyCode.Equals(ToCurrency, other.ToCurrency) &&
              DateTime.Equals(RecordedAt, other.RecordedAt)));
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public override bool Equals(object other)
    {
        return other is not null && (ReferenceEquals(this, other) || (other.GetType() == GetType() && Equals((ExchangeRateKey)other)));
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        unchecked
        {
            return (FromCurrency.GetHashCode() * 397) ^ ToCurrency.GetHashCode() ^ RecordedAt.GetHashCode();
        }
    }

    #endregion Equality

    #region Comparable

    /// <summary>
    ///
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(ExchangeRateKey other)
    {
        if (other is null)
        {
            return 1;
        }
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        CurrencyMismatchException.ThrowIfMisMatch(FromCurrency, other.FromCurrency);
        CurrencyMismatchException.ThrowIfMisMatch(ToCurrency, other.ToCurrency);

        return DateTime.Compare(RecordedAt, other.RecordedAt);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(object other)
    {
        if (other is null)
        {
            return 1;
        }
        IncompatibleTypeException.ThrowIfMismatch(other.GetType(), GetType());
        return CompareTo((ExchangeRateKey)other);
    }

    #endregion Comparable
}