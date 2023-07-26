using System;
using System.Globalization;

namespace Thudugala.MultiCurrencyMoney
{
    /// <summary>
    /// Setup Global Settings for type Money
    /// </summary>
    public static class GlobalSetting
    {
        private static CurrencyCode baseCurrencyCode;
        private static CurrencyCode defaultCurrencyCode;
        private static Func<Money, string> moneyToString;

        /// <summary>
        /// Set the Default CurrencyCode to use when reading base exchange rates.
        /// </summary>
        public static CurrencyCode BaseCurrencyCode
        {
            get
            {
                if (baseCurrencyCode is null)
                {
                    ResetBaseCurrencyCode();
                }
                return baseCurrencyCode;
            }

            set
            {
                if (value is null)
                {
                    return;
                }
                baseCurrencyCode = value;
            }
        }

        /// <summary>
        /// Set the Default CurrencyCode to use if not set by the user
        /// </summary>
        public static CurrencyCode DefaultCurrencyCode
        {
            get
            {
                if (defaultCurrencyCode is null)
                {
                    ResetDefaultCurrencyCode();
                }
                return defaultCurrencyCode;
            }

            set
            {
                if (value is null)
                {
                    return;
                }
                defaultCurrencyCode = value;
            }
        }

        /// <summary>
        /// The number of decimal places in the return value
        /// </summary>
        public static int ExchangeRateRoundingDecimalPlacesCount { get; set; } = 4;

        /// <summary>
        /// Get/Set Money ToString representation.
        /// </summary>
        public static Func<Money, string> MoneyToString
        {
            get
            {
                if (moneyToString is null)
                {
                    ResetMoneyToString();
                }
                return moneyToString;
            }
            set
            {
                if (value is null)
                {
                    return;
                }
                moneyToString = value;
            }
        }

        /// <summary>
        /// When CurrencyCode convert to string show ISO CurrencySymbol
        /// </summary>
        public static bool ShowISOCurrencySymbol { get; set; } = true;

        /// <summary>
        /// Reset back to USD
        /// </summary>
        public static void ResetBaseCurrencyCode()
        {
            BaseCurrencyCode = CurrencyCode.USD;
        }

        /// <summary>
        /// Reset back to Current Region
        /// </summary>
        public static void ResetDefaultCurrencyCode()
        {
            var region = RegionInfo.CurrentRegion;

            DefaultCurrencyCode = new CurrencyCode(region.ISOCurrencySymbol, region.CurrencySymbol, region.CurrencyEnglishName);
        }

        /// <summary>
        /// Reset MoneyToString
        /// </summary>
        public static void ResetMoneyToString()
        {
            MoneyToString = (money) => { return $"{money.Amount} {money.Currency}"; };
        }
    }
}