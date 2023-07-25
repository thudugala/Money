using System;
using Thudugala.System.Exceptions;

namespace Thudugala.System
{
    /// <summary>
    /// Example: 1 USD (SourceCurrency) = 1.6 (Rate) NZD (DestinationCurrency)
    /// </summary>
    public readonly struct ExchangeRate : IComparable, IComparable<ExchangeRate>, IEquatable<ExchangeRate>
    {
        /// <summary>
        /// 
        /// </summary>
        public CurrencyCode SourceCurrency { get; }

        /// <summary>
        /// 
        /// </summary>
        public CurrencyCode DestinationCurrency { get; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Rate { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceCurrency"></param>
        /// <param name="destinationCurrency"></param>
        /// <param name="rate"></param>
        public ExchangeRate(CurrencyCode sourceCurrency, CurrencyCode destinationCurrency, decimal rate)
        {
            SourceCurrency = sourceCurrency;
            DestinationCurrency = destinationCurrency;
            Rate = rate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"1 {SourceCurrency} = {Rate} {DestinationCurrency}";

        #region Equality

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ExchangeRate other)
        {
            return CurrencyCode.Equals(SourceCurrency, other.SourceCurrency) &&
                CurrencyCode.Equals(DestinationCurrency, other.DestinationCurrency) &&
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
                return (Rate.GetHashCode() * 397) ^ SourceCurrency.GetHashCode() ^ DestinationCurrency.GetHashCode();
            }
        }

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
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ExchangeRate left, ExchangeRate right) => !(left == right);

        #endregion

        #region Comparable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(ExchangeRate other)
        {
            CurrencyMismatchException.ThrowIfMisMatch(SourceCurrency, other.SourceCurrency);
            CurrencyMismatchException.ThrowIfMisMatch(DestinationCurrency, other.DestinationCurrency);

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

        #endregion
    }
}
