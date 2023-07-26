using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thudugala.System.Services;

/// <summary>
/// Should return list of rates on different dates that all meantained relative to base Currency in query
/// </summary>
public interface IExchangeRateReader
{
    /// <summary>
    /// Should return list of rates on different dates that all meantained relative to base Currency in query
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<ExchangeRate>> GetBaseCurrencyRates(ExchangeRateQuery query);
}