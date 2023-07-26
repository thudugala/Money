using System;
using System.Globalization;

namespace Thudugala.System
{
    /// <summary>
    /// Setup Global Settings for type Money
    /// </summary>
    public static class GlobalSetting
    {
        private static CurrencyCode defaultCurrencyCode;
        private static Func<Money, string> moneyToString;

        /// <summary>
        /// Set the Default ISOCurrencySymbol for CurrencyCode to use if not set by the user
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
        /// Reset DefaultCurrencyCode to back to Current Region ISOCurrencySymbol
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
            moneyToString = (money) => { return $"{money.Amount} {money.Currency}"; };
        }
    }
}