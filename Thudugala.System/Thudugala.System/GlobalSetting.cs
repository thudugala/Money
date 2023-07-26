using System.Globalization;
namespace Thudugala.System
{
    /// <summary>
    /// Setup Global Settings for type Money
    /// </summary>
    public static class GlobalSetting
    {        
        private static string defaultISOCurrencySymbol;

        /// <summary>
        /// Set the Default ISOCurrencySymbol for CurrencyCode to use if not set by the user
        /// </summary>
        public static string DefaultISOCurrencySymbol
        {
            get
            {
                if(defaultISOCurrencySymbol is null)
                {
                    ResetDefaultISOCurrencySymbol();
                }
                return defaultISOCurrencySymbol;
            }

            set
            {
                if (value is null || string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                defaultISOCurrencySymbol = value;
            }
        }

        /// <summary>
        /// Reset DefaultISOCurrencySymbol to back to Current Region ISOCurrencySymbol
        /// </summary>
        public static void ResetDefaultISOCurrencySymbol()
        {
            DefaultISOCurrencySymbol = RegionInfo.CurrentRegion.ISOCurrencySymbol;
        }
    }
}
