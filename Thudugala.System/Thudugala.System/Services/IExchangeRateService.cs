using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thudugala.System.Services;

/// <summary>
///
/// </summary>
public interface IExchangeRateService
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="exchangeRateKeys"></param>
    /// <returns></returns>
    Task<IEnumerable<ExchangeRate>> GetRates(IList<ExchangeRateKey> exchangeRateKeys);
}