using System;

namespace Thudugala.System
{
    /// <summary>
    /// Will convert Money to different Currency with the given rate
    /// Example: 1 USD (FromCurrency) = 1.6 (Rate) NZD (ToCurrency)
    /// </summary>
    public class ExchangeRate : ExchangeRateKey, IComparable, IComparable<ExchangeRate>, IEquatable<ExchangeRate>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="fromCurrency">Money Currency</param>
        /// <param name="toCurrency">Money to be Currency</param>
        /// <param name="rate">Rate will not be Zero or Negative</param>
        /// <param name="recordedAt"></param>
        public ExchangeRate(CurrencyCode fromCurrency, CurrencyCode toCurrency, decimal rate, DateTime recordedAt)
            : base(fromCurrency, toCurrency, recordedAt)
        {
            Rate = rate == 0 ? 1 : Math.Abs(rate);
        }

        /// <summary>
        /// Rate canot be Zero or Negative
        /// </summary>
        public decimal Rate { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"1 {FromCurrency} = {Rate} {ToCurrency} at {RecordedAt}";

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
            return other is not null &&
            (ReferenceEquals(this, other) ||
             (decimal.Equals(Rate, other.Rate) &&
              base.Equals(other)));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            return other is not null && (ReferenceEquals(this, other) || (other.GetType() == GetType() && Equals((ExchangeRate)other)));
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Rate.GetHashCode() * 397) ^ base.GetHashCode();
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
            var result = base.CompareTo(other);
            return result != 0 ? result : decimal.Compare(Rate, other.Rate);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public new int CompareTo(object other)
        {
            return CompareTo((ExchangeRate)other);
        }

        #endregion Comparable

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ExchangeRate DeepCopy()
        {
            return new ExchangeRate(FromCurrency.DeepCopy(), ToCurrency.DeepCopy(), Rate, RecordedAt);
        }
    }
}