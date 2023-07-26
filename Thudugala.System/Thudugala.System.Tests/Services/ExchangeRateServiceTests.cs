using Moq;
using Thudugala.System.Services;

namespace Thudugala.System.Tests.Services
{
    public class ExchangeRateServiceTests
    {
        private readonly Mock<IExchangeRateReader> _exchangeRateReader;

        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateServiceTests()
        {
            _exchangeRateReader = new Mock<IExchangeRateReader>();

            _exchangeRateReader.Setup(r => r.GetBaseCurrencyRates(It.IsAny<ExchangeRateQuery>()))
                .ReturnsAsync(new List<ExchangeRate>
                {
                    new ExchangeRate(GlobalSetting.BaseCurrencyCode, CurrencyCode.GBP, 0.77m, DateTime.Today),
                    new ExchangeRate(GlobalSetting.BaseCurrencyCode, CurrencyCode.NZD, 1.61m, DateTime.Today),
                });

            _exchangeRateService = new ExchangeRateService(_exchangeRateReader.Object);
        }

        [Fact]
        public async void FromIsBaseCurrency()
        {
            var rates = await _exchangeRateService.GetRates(new List<ExchangeRateKey>
            {
                new ExchangeRateKey(GlobalSetting.BaseCurrencyCode, CurrencyCode.NZD, DateTime.Today),
            });

            Assert.NotNull(rates);
            Assert.True(rates.Any());
            Assert.Single(rates);
            Assert.Equal(1.61m, rates.Single().Rate);
        }

        [Fact]
        public async void ToIsBaseCurrency()
        {
            var rates = await _exchangeRateService.GetRates(new List<ExchangeRateKey>
            {
                new ExchangeRateKey(CurrencyCode.NZD, GlobalSetting.BaseCurrencyCode, DateTime.Today),
            });

            Assert.NotNull(rates);
            Assert.True(rates.Any());
            Assert.Single(rates);
            Assert.Equal(0.6211m, rates.Single().Rate);
        }

        [Fact]
        public async void NonIsBaseCurrency()
        {
            var rates = await _exchangeRateService.GetRates(new List<ExchangeRateKey>
            {
                new ExchangeRateKey(CurrencyCode.GBP, CurrencyCode.NZD, DateTime.Today),
            });

            Assert.NotNull(rates);
            Assert.True(rates.Any());
            Assert.Single(rates);
            Assert.Equal(2.0909m, rates.Single().Rate);
        }
    }
}