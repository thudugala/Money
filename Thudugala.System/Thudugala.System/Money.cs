using System;
using Thudugala.System.Exceptions;

namespace Thudugala.System
{
    /// <summary>
    /// 
    /// </summary>
    public readonly struct Money : IComparable, IComparable<Money>, IEquatable<Money>
    {
        /// <summary>
        /// Amount = 0 and Currency is GlobalSetting.DefaultISOCurrencySymbol
        /// </summary>
        public static Money Empty { get; } = new Money();

        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// 
        /// </summary>
        public CurrencyCode Currency { get; }

        /// <summary>
        /// 
        /// </summary>
        public Money() : this(0)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public Money(decimal amount) : this(amount, null)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        public Money(decimal amount, CurrencyCode currency)
        {
            Amount = amount;
            Currency = currency ?? new CurrencyCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Amount} {Currency}";

        #region Equality

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Money other)
        {
            return decimal.Equals(Amount, other.Amount) && CurrencyCode.Equals(Currency, other.Currency);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            return other.GetType() == GetType() && Equals((Money)other);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount.GetHashCode() * 397) ^ Currency.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Money left, Money right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Money left, Money right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Money left, decimal right) => left.Equals(new Money(right));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Money left, decimal right) => !(left == new Money(right));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(decimal left, Money right) => right.Equals(new Money(left));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(decimal left, Money right) => !(right == new Money(left));

        #endregion

        #region Comparable

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Money other)
        {
            CurrencyMismatchException.ThrowIfMisMatch(Currency, other.Currency);

            return decimal.Compare(Amount, other.Amount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(object other)
        {
            IncompatibleTypeException.ThrowIfMismatch(other.GetType(), GetType());

            return CompareTo((Money)other);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Money left, Money right) => left.CompareTo(right) < 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Money left, Money right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Money left, Money right) => left.CompareTo(right) > 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Money left, Money right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Money left, decimal right) => left.CompareTo(new Money(right)) < 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Money left, decimal right) => left.CompareTo(new Money(right)) <= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Money left, decimal right) => left.CompareTo(new Money(right)) > 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Money left, decimal right) => left.CompareTo(new Money(right)) >= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(decimal left, Money right) => right.CompareTo(new Money(left)) < 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(decimal left, Money right) => right.CompareTo(new Money(left)) <= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(decimal left, Money right) => right.CompareTo(new Money(left)) > 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(decimal left, Money right) => right.CompareTo(new Money(left)) >= 0;

        #endregion

        #region Unary Operators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static Money operator ++(Money me) => new(me.Amount + 1, me.Currency);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static Money operator --(Money me) => new(me.Amount - 1, me.Currency);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static Money operator +(Money me) => new(+me.Amount, me.Currency);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static Money operator -(Money me) => new(-me.Amount, me.Currency);

        #endregion

        #region Binary Operations

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Money operator +(Money left, Money right)
        {
            CurrencyMismatchException.ThrowIfMisMatch(left.Currency, right.Currency);

            return new Money(left.Amount + right.Amount, left.Currency);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Money operator -(Money left, Money right)
        {
            CurrencyMismatchException.ThrowIfMisMatch(left.Currency, right.Currency);

            return new Money(left.Amount - right.Amount, left.Currency);
        }
                
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Money operator *(Money left, decimal right) => new(left.Amount * right, left.Currency);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Money operator *(decimal left, Money right) => new(left * right.Amount, right.Currency);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="rate"></param>
        /// <returns></returns>
        public static Money operator *(Money left, ExchangeRate rate)
        {
            CurrencyMismatchException.ThrowIfMisMatch(left.Currency, rate.FromCurrency);

            return new(left.Amount * rate.Rate, rate.ToCurrency);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Money operator *(ExchangeRate rate, Money right)
        {
            CurrencyMismatchException.ThrowIfMisMatch(right.Currency, rate.FromCurrency);

            return new(right.Amount * rate.Rate, rate.ToCurrency);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Money operator /(Money left, decimal right) => new(left.Amount / right, left.Currency);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Money operator /(decimal left, Money right) => new(left / right.Amount, right.Currency);
               
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Money operator %(Money left, decimal right) => new(left.Amount % right, left.Currency);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Money operator %(decimal left, Money right) => new(left % right.Amount, right.Currency);

        #endregion
    }
}
