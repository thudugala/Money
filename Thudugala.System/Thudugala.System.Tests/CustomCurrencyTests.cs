namespace Thudugala.System.Tests
{
    public class CustomCurrencyTests
    {
        [Fact]
        public void MoneyIsEqual()
        {
            var m1 = new Money(1m, CustomCurrencyCode.MBTC);
            var m2 = new Money(1m, CustomCurrencyCode.MBTC);
            Assert.Equal(m1, m2);
        }
    }

    public class CustomCurrencyCode : CurrencyCode
    {
        public static CustomCurrencyCode MBTC = new("mBTC", "B", "Bitcoin", "Bitcoin Currency");

        public string Description { get; }

        public CustomCurrencyCode(string iSOCurrencySymbol, string currencySymbol, string englishName, string description) : base(iSOCurrencySymbol, currencySymbol, englishName)
        {
            Description = description;
        }
    }
}
