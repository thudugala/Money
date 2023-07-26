using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thudugala.MultiCurrencyMoney.Services;

/// <summary>
///
/// </summary>
public class ExchangeRateService : IExchangeRateService
{
    private readonly IExchangeRateReader _exchangeRateReader;

    /// <summary>
    ///
    /// </summary>
    /// <param name="exchangeRateReader"></param>
    public ExchangeRateService(IExchangeRateReader exchangeRateReader)
    {
        _exchangeRateReader = exchangeRateReader;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="exchangeRateKeys"></param>
    /// <returns></returns>
    public async Task<IEnumerable<ExchangeRate>> GetRates(IList<ExchangeRateKey> exchangeRateKeys)
    {
        var query = new ExchangeRateQuery
        {
            BaseCurrency = GlobalSetting.BaseCurrencyCode
        };

        var valideRateKeys = exchangeRateKeys.Where(r => r.FromCurrency != r.ToCurrency && (r.FromCurrency != query.BaseCurrency || r.ToCurrency != query.BaseCurrency));
        foreach (var key in valideRateKeys)
        {
            query.RecordedAts.Add(key.RecordedAt);

            if (key.FromCurrency != query.BaseCurrency)
            {
                query.ToCurrencies.Add(key.FromCurrency);
            }
            if (key.ToCurrency != query.BaseCurrency)
            {
                query.ToCurrencies.Add(key.ToCurrency);
            }
        }

        // baseRates, all records FromCurrency must equal query.BaseCurrency
        var baseRates = await _exchangeRateReader.GetBaseCurrencyRates(query);

        if (!baseRates.Any())
        {
            return Enumerable.Empty<ExchangeRate>();
        }

        var rates = new List<ExchangeRate>();

        foreach (var key in exchangeRateKeys)
        {
            if (key.FromCurrency == query.BaseCurrency)
            {
                var baseRate = baseRates.FirstOrDefault(r => r.ToCurrency == key.ToCurrency && r.RecordedAt == key.RecordedAt);

                var rate = new ExchangeRate(key.FromCurrency,
                    key.ToCurrency,
                    Math.Round(baseRate.Rate, GlobalSetting.ExchangeRateRoundingDecimalPlacesCount),
                    key.RecordedAt);

                rates.Add(rate);
            }
            else if (key.ToCurrency == query.BaseCurrency)
            {
                var baseRate = baseRates.FirstOrDefault(r => r.ToCurrency == key.FromCurrency && r.RecordedAt == key.RecordedAt);

                var rate = new ExchangeRate(key.FromCurrency,
                    key.ToCurrency,
                    Math.Round(1 / baseRate.Rate, GlobalSetting.ExchangeRateRoundingDecimalPlacesCount),
                    key.RecordedAt);

                rates.Add(rate);
            }
            else
            {
                var fromBaseRate = baseRates.FirstOrDefault(r => r.ToCurrency == key.FromCurrency && r.RecordedAt == key.RecordedAt);
                var toBaseRate = baseRates.FirstOrDefault(r => r.ToCurrency == key.ToCurrency && r.RecordedAt == key.RecordedAt);

                var rate = new ExchangeRate(key.FromCurrency,
                    key.ToCurrency,
                    Math.Round(toBaseRate.Rate / fromBaseRate.Rate, GlobalSetting.ExchangeRateRoundingDecimalPlacesCount),
                    key.RecordedAt);

                rates.Add(rate);
            }
        }

        return rates;
    }
}