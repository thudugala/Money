using System;

namespace Thudugala.System.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrencyMismatchException : InvalidOperationException
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
        /// <param name="sourceCurrency"></param>
        /// <param name="destinationCurrency"></param>
        public CurrencyMismatchException(
            CurrencyCode sourceCurrency,
            CurrencyCode destinationCurrency)
            : base($"Cannot compare {sourceCurrency} and {destinationCurrency}")
        {
            SourceCurrency = sourceCurrency;
            DestinationCurrency = destinationCurrency;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceCurrency"></param>
        /// <param name="destinationCurrency"></param>
        /// <exception cref="CurrencyMismatchException"></exception>
        public static void ThrowIfMisMatch(CurrencyCode sourceCurrency,
            CurrencyCode destinationCurrency)
        {
            if (sourceCurrency != destinationCurrency)
            {
                throw new CurrencyMismatchException(sourceCurrency, destinationCurrency);
            }
        }
    }
}
