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
        public const string MBTC = "mBTC";

        public CustomCurrencyCode(string value) : base(value)
        {
        }
    }
}
