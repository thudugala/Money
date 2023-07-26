using System;
using System.Collections.Generic;

namespace Thudugala.MultiCurrencyMoney.Services;

/// <summary>
///
/// </summary>
public class ExchangeRateQuery
{
    /// <summary>
    ///
    /// </summary>
    public ExchangeRateQuery()
    {
        ToCurrencies = new List<CurrencyCode>();
        RecordedAts = new List<DateTime>();
    }

    /// <summary>
    /// Rates Base Currency
    /// Example USD
    /// </summary>
    public CurrencyCode BaseCurrency { get; set; }

    /// <summary>
    /// Rates To Currencies
    /// </summary>
    public IList<CurrencyCode> ToCurrencies { get; set; }

    /// <summary>
    /// Rates Recorded dates
    /// </summary>
    public IList<DateTime> RecordedAts { get; set; }
}