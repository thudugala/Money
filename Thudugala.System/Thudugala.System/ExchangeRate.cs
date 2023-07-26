using System;
using Thudugala.System.Exceptions;

namespace Thudugala.System
{
    /// <summary>
    /// Will convert Money to different Currency with the given rate
    /// Example: 1 USD (FromCurrency) = 1.6 (Rate) NZD (ToCurrency)
    /// </summary>
    public readonly struct ExchangeRate : IComparable, IComparable<ExchangeRate>, IEquatable<ExchangeRate>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="fromCurrency">Money Currency</param>
        /// <param name="toCurrency">Money to be Currency</param>
        /// <param name="rate">Rate will not be Zero or Negative</param>
        public ExchangeRate(CurrencyCode fromCurrency, CurrencyCode toCurrency, decimal rate)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            Rate = rate == 0 ? 1 : Math.Abs(rate);
        }

        /// <summary>
        /// Money Currency
        /// </summary>
        public CurrencyCode FromCurrency { get; }

        /// <summary>
        /// Rate canot be Zero or Negative
        /// </summary>
        public decimal Rate { get; }

        /// <summary>
        /// Money to be Currency
        /// </summary>
        public CurrencyCode ToCurrency { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"1 {FromCurrency} = {Rate} {ToCurrency}";

        #region Equality

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ExchangeRate left, ExchangeRate right) => !(left == right);

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ExchangeRate left, ExchangeRate right) => left.Equals(right);

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ExchangeRate other)
        {
            return CurrencyCode.Equals(FromCurrency, other.FromCurrency) &&
                CurrencyCode.Equals(ToCurrency, other.ToCurrency) &&
                decimal.Equals(Rate, other.Rate);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            return other.GetType() == GetType() && Equals((ExchangeRate)other);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Rate.GetHashCode() * 397) ^ FromCurrency.GetHashCode() ^ ToCurrency.GetHashCode();
            }
        }

        #endregion Equality

        #region Comparable

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(ExchangeRate other)
        {
            CurrencyMismatchException.ThrowIfMisMatch(FromCurrency, other.FromCurrency);
            CurrencyMismatchException.ThrowIfMisMatch(ToCurrency, other.ToCurrency);

            return Rate.CompareTo(other.Rate);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(object other)
        {
            IncompatibleTypeException.ThrowIfMismatch(other.GetType(), GetType());
            return CompareTo((ExchangeRate)other);
        }

        #endregion Comparable
    }
}