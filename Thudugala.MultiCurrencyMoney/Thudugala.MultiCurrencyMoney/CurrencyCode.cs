using System;
using Thudugala.MultiCurrencyMoney.Exceptions;

namespace Thudugala.MultiCurrencyMoney
{
    /// <summary>
    /// Designed to be inherited and ad new currency codes if needed.
    /// </summary>
    public class CurrencyCode : IComparable, IComparable<CurrencyCode>, IEquatable<CurrencyCode>
    {
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode AED = new("AED", "د.إ.‏", "United Arab Emirates Dirham");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode AFN = new("AFN", "؋", "Afghan Afghani");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode ALL = new("ALL", "Lekë", "Albanian Lek");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode AMD = new("AMD", "֏", "Armenian Dram");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode ARS = new("ARS", "$", "Argentine Peso");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode AUD = new("AUD", "$", "Australian Dollar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode AZN = new("AZN", "₼", "Azerbaijani Manat");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode BAM = new("BAM", "КМ", "Bosnia-Herzegovina Convertible Mark");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode BDT = new("BDT", "৳", "Bangladeshi Taka");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode BGN = new("BGN", "лв.", "Bulgarian Lev");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode BHD = new("BHD", "د.ب.‏", "Bahraini Dinar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode BND = new("BND", "$", "Brunei Dollar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode BOB = new("BOB", "Bs", "Bolivian Boliviano");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode BRL = new("BRL", "R$", "Brazilian Real");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode BTN = new("BTN", "Nu.", "Bhutanese Ngultrum");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode BWP = new("BWP", "P", "Botswanan Pula");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode BYN = new("BYN", "Br", "Belarusian Ruble");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode BZD = new("BZD", "$", "Belize Dollar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode CAD = new("CAD", "$", "Canadian Dollar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode CDF = new("CDF", "FC", "Congolese Franc");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode CHF = new("CHF", "CHF", "Swiss Franc");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode CLP = new("CLP", "CLP", "Chilean Peso");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode CNY = new("CNY", "¥", "Chinese Yuan");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode COP = new("COP", "$", "Colombian Peso");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode CRC = new("CRC", "₡", "Costa Rican Colón");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode CUP = new("CUP", "$", "Cuban Peso");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode CZK = new("CZK", "Kč", "Czech Koruna");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode DKK = new("DKK", "kr.", "Danish Krone");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode DOP = new("DOP", "RD$", "Dominican Peso");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode DZD = new("DZD", "د.ج.‏", "Algerian Dinar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode EGP = new("EGP", "ج.م.‏", "Egyptian Pound");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode ERN = new("ERN", "Nfk", "Eritrean Nakfa");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode ETB = new("ETB", "ብር", "Ethiopian Birr");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode EUR = new("EUR", "€", "Euro");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode GBP = new("GBP", "£", "British Pound");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode GEL = new("GEL", "₾", "Georgian Lari");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode GTQ = new("GTQ", "Q", "Guatemalan Quetzal");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode HKD = new("HKD", "HK$", "Hong Kong Dollar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode HNL = new("HNL", "L", "Honduran Lempira");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode HRK = new("HRK", "HRK", "Croatian Kuna");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode HTG = new("HTG", "G", "Haitian Gourde");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode HUF = new("HUF", "Ft", "Hungarian Forint");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode IDR = new("IDR", "IDR", "Indonesian Rupiah");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode ILS = new("ILS", "₪", "Israeli New Shekel");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode INR = new("INR", "₹", "Indian Rupee");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode IQD = new("IQD", "د.ع.‏", "Iraqi Dinar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode IRR = new("IRR", "ریال", "Iranian Rial");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode ISK = new("ISK", "ISK", "Icelandic Króna");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode JMD = new("JMD", "$", "Jamaican Dollar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode JOD = new("JOD", "د.أ.‏", "Jordanian Dinar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode JPY = new("JPY", "￥", "Japanese Yen");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode KES = new("KES", "Ksh", "Kenyan Shilling");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode KGS = new("KGS", "сом", "Kyrgystani Som");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode KHR = new("KHR", "៛", "Cambodian Riel");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode KRW = new("KRW", "₩", "South Korean Won");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode KWD = new("KWD", "د.ك.‏", "Kuwaiti Dinar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode KZT = new("KZT", "₸", "Kazakhstani Tenge");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode LAK = new("LAK", "₭", "Laotian Kip");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode LBP = new("LBP", "ل.ل.‏", "Lebanese Pound");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode LKR = new("LKR", "රු.", "Sri Lankan Rupee");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode LYD = new("LYD", "د.ل.‏", "Libyan Dinar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode MAD = new("MAD", "د.م.‏", "Moroccan Dirham");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode MDL = new("MDL", "L", "Moldovan Leu");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode MKD = new("MKD", "ден.", "Macedonian Denar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode MMK = new("MMK", "K", "Myanmar Kyat");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode MNT = new("MNT", "₮", "Mongolian Tugrik");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode MVR = new("MVR", "ރ.", "Maldivian Rufiyaa");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode MXN = new("MXN", "$", "Mexican Peso");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode MYR = new("MYR", "RM", "Malaysian Ringgit");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode NGN = new("NGN", "NGN", "Nigerian Naira");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode NIO = new("NIO", "C$", "Nicaraguan Córdoba");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode NOK = new("NOK", "kr", "Norwegian Krone");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode NPR = new("NPR", "नेरू", "Nepalese Rupee");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode NZD = new("NZD", "$", "New Zealand Dollar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode OMR = new("OMR", "ر.ع.‏", "Omani Rial");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode PAB = new("PAB", "B/.", "Panamanian Balboa");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode PEN = new("PEN", "S/", "Peruvian Sol");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode PHP = new("PHP", "₱", "Philippine Piso");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode PKR = new("PKR", "ر", "Pakistani Rupee");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode PLN = new("PLN", "zł", "Polish Zloty");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode PYG = new("PYG", "Gs.", "Paraguayan Guarani");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode QAR = new("QAR", "ر.ق.‏", "Qatari Rial");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode RON = new("RON", "RON", "Romanian Leu");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode RSD = new("RSD", "RSD", "Serbian Dinar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode RUB = new("RUB", "RUB", "Russian Ruble");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode RWF = new("RWF", "RF", "Rwandan Franc");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode SAR = new("SAR", "ر.س.‏", "Saudi Riyal");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode SEK = new("SEK", "kr", "Swedish Krona");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode SGD = new("SGD", "$", "Singapore Dollar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode SOS = new("SOS", "S", "Somali Shilling");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode SYP = new("SYP", "ل.س.‏", "Syrian Pound");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode THB = new("THB", "฿", "Thai Baht");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode TMT = new("TMT", "TMT", "Turkmenistani Manat");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode TND = new("TND", "د.ت.‏", "Tunisian Dinar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode TRY = new("TRY", "₺", "Turkish Lira");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode TTD = new("TTD", "$", "Trinidad & Tobago Dollar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode UAH = new("UAH", "₴", "Ukrainian Hryvnia");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode USD = new("USD", "$", "US Dollar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode UYU = new("UYU", "$", "Uruguayan Peso");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode UZS = new("UZS", "сўм", "Uzbekistani Som");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode VES = new("VES", "Bs.S", "Venezuelan Bolívar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode VND = new("VND", "₫", "Vietnamese Dong");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode XAF = new("XAF", "FCFA", "Central African CFA Franc");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode XCD = new("XCD", "EC$", "East Caribbean Dollar");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode XOF = new("XOF", "CFA", "West African CFA Franc");
        /// <summary>
        /// 
        /// </summary>
        public static CurrencyCode YER = new("YER", "ر.ي.‏", "Yemeni Rial");
        /// <summary>
        /// 
        /// </summary>
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