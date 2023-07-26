using System;
using Thudugala.System.Exceptions;

namespace Thudugala.System
{
    /// <summary>
    /// Designed to be inherited and ad new currency codes if needed.
    /// </summary>
    public class CurrencyCode : IComparable, IComparable<CurrencyCode>, IEquatable<CurrencyCode>
    {
        public static CurrencyCode AED = new("AED", "د.إ.‏", "United Arab Emirates Dirham");
        public static CurrencyCode AFN = new("AFN", "؋", "Afghan Afghani");
        public static CurrencyCode ALL = new("ALL", "Lekë", "Albanian Lek");
        public static CurrencyCode AMD = new("AMD", "֏", "Armenian Dram");
        public static CurrencyCode ARS = new("ARS", "$", "Argentine Peso");
        public static CurrencyCode AUD = new("AUD", "$", "Australian Dollar");
        public static CurrencyCode AZN = new("AZN", "₼", "Azerbaijani Manat");
        public static CurrencyCode BAM = new("BAM", "КМ", "Bosnia-Herzegovina Convertible Mark");
        public static CurrencyCode BDT = new("BDT", "৳", "Bangladeshi Taka");
        public static CurrencyCode BGN = new("BGN", "лв.", "Bulgarian Lev");
        public static CurrencyCode BHD = new("BHD", "د.ب.‏", "Bahraini Dinar");
        public static CurrencyCode BND = new("BND", "$", "Brunei Dollar");
        public static CurrencyCode BOB = new("BOB", "Bs", "Bolivian Boliviano");
        public static CurrencyCode BRL = new("BRL", "R$", "Brazilian Real");
        public static CurrencyCode BTN = new("BTN", "Nu.", "Bhutanese Ngultrum");
        public static CurrencyCode BWP = new("BWP", "P", "Botswanan Pula");
        public static CurrencyCode BYN = new("BYN", "Br", "Belarusian Ruble");
        public static CurrencyCode BZD = new("BZD", "$", "Belize Dollar");
        public static CurrencyCode CAD = new("CAD", "$", "Canadian Dollar");
        public static CurrencyCode CDF = new("CDF", "FC", "Congolese Franc");
        public static CurrencyCode CHF = new("CHF", "CHF", "Swiss Franc");
        public static CurrencyCode CLP = new("CLP", "CLP", "Chilean Peso");
        public static CurrencyCode CNY = new("CNY", "¥", "Chinese Yuan");
        public static CurrencyCode COP = new("COP", "$", "Colombian Peso");
        public static CurrencyCode CRC = new("CRC", "₡", "Costa Rican Colón");
        public static CurrencyCode CUP = new("CUP", "$", "Cuban Peso");
        public static CurrencyCode CZK = new("CZK", "Kč", "Czech Koruna");
        public static CurrencyCode DKK = new("DKK", "kr.", "Danish Krone");
        public static CurrencyCode DOP = new("DOP", "RD$", "Dominican Peso");
        public static CurrencyCode DZD = new("DZD", "د.ج.‏", "Algerian Dinar");
        public static CurrencyCode EGP = new("EGP", "ج.م.‏", "Egyptian Pound");
        public static CurrencyCode ERN = new("ERN", "Nfk", "Eritrean Nakfa");
        public static CurrencyCode ETB = new("ETB", "ብር", "Ethiopian Birr");
        public static CurrencyCode EUR = new("EUR", "€", "Euro");
        public static CurrencyCode GBP = new("GBP", "£", "British Pound");
        public static CurrencyCode GEL = new("GEL", "₾", "Georgian Lari");
        public static CurrencyCode GTQ = new("GTQ", "Q", "Guatemalan Quetzal");
        public static CurrencyCode HKD = new("HKD", "HK$", "Hong Kong Dollar");
        public static CurrencyCode HNL = new("HNL", "L", "Honduran Lempira");
        public static CurrencyCode HRK = new("HRK", "HRK", "Croatian Kuna");
        public static CurrencyCode HTG = new("HTG", "G", "Haitian Gourde");
        public static CurrencyCode HUF = new("HUF", "Ft", "Hungarian Forint");
        public static CurrencyCode IDR = new("IDR", "IDR", "Indonesian Rupiah");
        public static CurrencyCode ILS = new("ILS", "₪", "Israeli New Shekel");
        public static CurrencyCode INR = new("INR", "₹", "Indian Rupee");
        public static CurrencyCode IQD = new("IQD", "د.ع.‏", "Iraqi Dinar");
        public static CurrencyCode IRR = new("IRR", "ریال", "Iranian Rial");
        public static CurrencyCode ISK = new("ISK", "ISK", "Icelandic Króna");
        public static CurrencyCode JMD = new("JMD", "$", "Jamaican Dollar");
        public static CurrencyCode JOD = new("JOD", "د.أ.‏", "Jordanian Dinar");
        public static CurrencyCode JPY = new("JPY", "￥", "Japanese Yen");
        public static CurrencyCode KES = new("KES", "Ksh", "Kenyan Shilling");
        public static CurrencyCode KGS = new("KGS", "сом", "Kyrgystani Som");
        public static CurrencyCode KHR = new("KHR", "៛", "Cambodian Riel");
        public static CurrencyCode KRW = new("KRW", "₩", "South Korean Won");
        public static CurrencyCode KWD = new("KWD", "د.ك.‏", "Kuwaiti Dinar");
        public static CurrencyCode KZT = new("KZT", "₸", "Kazakhstani Tenge");
        public static CurrencyCode LAK = new("LAK", "₭", "Laotian Kip");
        public static CurrencyCode LBP = new("LBP", "ل.ل.‏", "Lebanese Pound");
        public static CurrencyCode LKR = new("LKR", "රු.", "Sri Lankan Rupee");
        public static CurrencyCode LYD = new("LYD", "د.ل.‏", "Libyan Dinar");
        public static CurrencyCode MAD = new("MAD", "د.م.‏", "Moroccan Dirham");
        public static CurrencyCode MDL = new("MDL", "L", "Moldovan Leu");
        public static CurrencyCode MKD = new("MKD", "ден.", "Macedonian Denar");
        public static CurrencyCode MMK = new("MMK", "K", "Myanmar Kyat");
        public static CurrencyCode MNT = new("MNT", "₮", "Mongolian Tugrik");
        public static CurrencyCode MVR = new("MVR", "ރ.", "Maldivian Rufiyaa");
        public static CurrencyCode MXN = new("MXN", "$", "Mexican Peso");
        public static CurrencyCode MYR = new("MYR", "RM", "Malaysian Ringgit");
        public static CurrencyCode NGN = new("NGN", "NGN", "Nigerian Naira");
        public static CurrencyCode NIO = new("NIO", "C$", "Nicaraguan Córdoba");
        public static CurrencyCode NOK = new("NOK", "kr", "Norwegian Krone");
        public static CurrencyCode NPR = new("NPR", "नेरू", "Nepalese Rupee");
        public static CurrencyCode NZD = new("NZD", "$", "New Zealand Dollar");
        public static CurrencyCode OMR = new("OMR", "ر.ع.‏", "Omani Rial");
        public static CurrencyCode PAB = new("PAB", "B/.", "Panamanian Balboa");
        public static CurrencyCode PEN = new("PEN", "S/", "Peruvian Sol");
        public static CurrencyCode PHP = new("PHP", "₱", "Philippine Piso");
        public static CurrencyCode PKR = new("PKR", "ر", "Pakistani Rupee");
        public static CurrencyCode PLN = new("PLN", "zł", "Polish Zloty");
        public static CurrencyCode PYG = new("PYG", "Gs.", "Paraguayan Guarani");
        public static CurrencyCode QAR = new("QAR", "ر.ق.‏", "Qatari Rial");
        public static CurrencyCode RON = new("RON", "RON", "Romanian Leu");
        public static CurrencyCode RSD = new("RSD", "RSD", "Serbian Dinar");
        public static CurrencyCode RUB = new("RUB", "RUB", "Russian Ruble");
        public static CurrencyCode RWF = new("RWF", "RF", "Rwandan Franc");
        public static CurrencyCode SAR = new("SAR", "ر.س.‏", "Saudi Riyal");
        public static CurrencyCode SEK = new("SEK", "kr", "Swedish Krona");
        public static CurrencyCode SGD = new("SGD", "$", "Singapore Dollar");
        public static CurrencyCode SOS = new("SOS", "S", "Somali Shilling");
        public static CurrencyCode SYP = new("SYP", "ل.س.‏", "Syrian Pound");
        public static CurrencyCode THB = new("THB", "฿", "Thai Baht");
        public static CurrencyCode TMT = new("TMT", "TMT", "Turkmenistani Manat");
        public static CurrencyCode TND = new("TND", "د.ت.‏", "Tunisian Dinar");
        public static CurrencyCode TRY = new("TRY", "₺", "Turkish Lira");
        public static CurrencyCode TTD = new("TTD", "$", "Trinidad & Tobago Dollar");
        public static CurrencyCode UAH = new("UAH", "₴", "Ukrainian Hryvnia");
        public static CurrencyCode USD = new("USD", "$", "US Dollar");
        public static CurrencyCode UYU = new("UYU", "$", "Uruguayan Peso");
        public static CurrencyCode UZS = new("UZS", "сўм", "Uzbekistani Som");
        public static CurrencyCode VES = new("VES", "Bs.S", "Venezuelan Bolívar");
        public static CurrencyCode VND = new("VND", "₫", "Vietnamese Dong");
        public static CurrencyCode XAF = new("XAF", "FCFA", "Central African CFA Franc");
        public static CurrencyCode XCD = new("XCD", "EC$", "East Caribbean Dollar");
        public static CurrencyCode XOF = new("XOF", "CFA", "West African CFA Franc");
        public static CurrencyCode YER = new("YER", "ر.ي.‏", "Yemeni Rial");
        public static CurrencyCode ZAR = new("ZAR", "R", "South African Rand");

        /// <summary>
        /// Defualt Currency will be CurrentRegion.ISOCurrencySymbol
        /// </summary>
        public CurrencyCode()
        {
            ISOCurrencySymbol = GlobalSetting.DefaultCurrencyCode.ISOCurrencySymbol;
            CurrencySymbol = GlobalSetting.DefaultCurrencyCode.CurrencySymbol;
            EnglishName = GlobalSetting.DefaultCurrencyCode.EnglishName;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="iSOCurrencySymbol"></param>
        /// <param name="currencySymbol"></param>
        /// <param name="englishName"></param>
        public CurrencyCode(string iSOCurrencySymbol, string currencySymbol, string englishName)
        {
            if (string.IsNullOrWhiteSpace(iSOCurrencySymbol))
            {
                throw new ArgumentException($"'{nameof(iSOCurrencySymbol)}' cannot be null or whitespace.", nameof(iSOCurrencySymbol));
            }

            if (string.IsNullOrWhiteSpace(currencySymbol))
            {
                throw new ArgumentException($"'{nameof(currencySymbol)}' cannot be null or whitespace.", nameof(currencySymbol));
            }

            if (string.IsNullOrWhiteSpace(englishName))
            {
                throw new ArgumentException($"'{nameof(englishName)}' cannot be null or whitespace.", nameof(englishName));
            }

            ISOCurrencySymbol = iSOCurrencySymbol;
            CurrencySymbol = currencySymbol;
            EnglishName = englishName;
        }

        /// <summary>
        /// Gets the currency symbol associated with the country/region.
        /// </summary>
        public string CurrencySymbol { get; }

        /// <summary>
        /// The name, in English, of the currency used in the country/region
        /// </summary>
        public string EnglishName { get; }

        /// <summary>
        /// Gets the three-character ISO 4217 currency symbol associated with the country/region
        /// </summary>
        public string ISOCurrencySymbol { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() => GlobalSetting.ShowISOCurrencySymbol ? ISOCurrencySymbol : CurrencySymbol;

        #region Equality

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(CurrencyCode left, CurrencyCode right) => !(left == right);

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(CurrencyCode left, CurrencyCode right) => left.Equals(right);

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CurrencyCode other)
        {
            return other is not null && (ReferenceEquals(this, other) || string.Equals(ISOCurrencySymbol, other.ISOCurrencySymbol));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            return other is not null && (ReferenceEquals(this, other) || (other.GetType() == GetType() && Equals((CurrencyCode)other)));
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ISOCurrencySymbol.GetHashCode() * 397;
            }
        }

        #endregion Equality

        #region Comparable

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(CurrencyCode other)
        {
            return other is null ? 1 : ReferenceEquals(this, other) ? 0 : string.Compare(ISOCurrencySymbol, other.ISOCurrencySymbol);
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

            return CompareTo((CurrencyCode)other);
        }

        #endregion Comparable

        #region Parse

        /// <summary>
        ///
        /// </summary>
        /// <param name="iSOCurrencySymbol"></param>
        /// <returns></returns>
        /// <exception cref="OverflowException"></exception>
        public static CurrencyCode Parse(string iSOCurrencySymbol)
        {
            if (string.IsNullOrWhiteSpace(iSOCurrencySymbol))
            {
                throw new ArgumentException($"'{nameof(iSOCurrencySymbol)}' cannot be null or whitespace.", nameof(iSOCurrencySymbol));
            }

            var field = typeof(CurrencyCode).GetField(iSOCurrencySymbol);
            if (!field.IsPublic || !field.IsStatic || field.FieldType != typeof(CurrencyCode))
            {
                throw new OverflowException($"Expect: {nameof(iSOCurrencySymbol)} not found");
            }
            var code = field.GetValue(null) as CurrencyCode;

            return code;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="iSOCurrencySymbol"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse(string iSOCurrencySymbol, out CurrencyCode result)
        {
            try
            {
                result = Parse(iSOCurrencySymbol);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        #endregion Parse

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public CurrencyCode DeepCopy()
        {
            return new CurrencyCode(ISOCurrencySymbol, CurrencySymbol, EnglishName);
        }
    }
}