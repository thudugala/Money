using System.Globalization;
using Thudugala.System.Exceptions;

namespace Thudugala.System.Tests;

public class MoneyTests
{   
    [Fact]
    public void MoneyCurrencyIsNotEqual()
    {
        var m1 = new Money(1m, CurrencyCode.NZD);
        var m2 = new Money(1m, CurrencyCode.AUD);
        Assert.NotEqual(m1, m2);
    }

    [Fact]
    public void MoneyIsNotEqualAmount()
    {
        var m1 = new Money(1m, CurrencyCode.NZD);
        var m2 = new Money(2m, CurrencyCode.NZD);
        Assert.NotEqual(m1, m2);
    }

    [Fact]
    public void MoneyIsEqual()
    {
        var m1 = new Money(1m, CurrencyCode.NZD);
        var m2 = new Money(1m, CurrencyCode.NZD);
        Assert.Equal(m1, m2);
    }

    [Fact]
    public void DefualtMoney()
    {
        var m1 = new Money();
        Assert.Equal(0, m1.Amount);
        Assert.Equal(GlobalSetting.DefaultISOCurrencySymbol, m1.Currency);
    }

    [Fact]
    public void SetGlobalDefualtCurrencyToNull()
    {
        var defultCurrency = GlobalSetting.DefaultISOCurrencySymbol;       
        GlobalSetting.DefaultISOCurrencySymbol = null;

        var m1 = new Money();
        Assert.Equal(0, m1.Amount);
        Assert.Equal(GlobalSetting.DefaultISOCurrencySymbol, m1.Currency);
    }

    [Fact]
    public void CurrencyNullMoney()
    {
        var m1 = new Money(1m, null);
        Assert.Equal(1, m1.Amount);
        Assert.Equal(GlobalSetting.DefaultISOCurrencySymbol, m1.Currency);
    }

    [Fact]
    public void DefualtCurrencyMoneyIsEqual()
    {
        var m1 = new Money(1m);
        Assert.Equal(1m, m1.Amount);
        Assert.Equal(GlobalSetting.DefaultISOCurrencySymbol, m1.Currency);
    }

    [Fact]
    public void MoneyAddMoney()
    {
        var m1 = new Money(1m, CurrencyCode.NZD);
        var m2 = new Money(1m, CurrencyCode.NZD);

        var result = m1 + m2;
        Assert.Equal(new Money(2m, CurrencyCode.NZD), result);
    }

    [Fact]
    public void MoneySubtractMoney()
    {
        var m1 = new Money(2m, CurrencyCode.NZD);
        var m2 = new Money(1m, CurrencyCode.NZD);

        var result = m1 - m2;
        Assert.Equal(new Money(1m, CurrencyCode.NZD), result);
    }
    
    
    [Fact]
    public void MoneyMultiplyDecimal()
    {
        var m1 = new Money(1m, CurrencyCode.NZD);

        var result = m1 * 1.5m;
        Assert.Equal(new Money(1.5m, CurrencyCode.NZD), result);

        result = 1.5m * m1;
        Assert.Equal(new Money(1.5m, CurrencyCode.NZD), result);
    }

    [Fact]
    public void MoneyMultiplyExchangeRate()
    {
        var m1 = new Money(1m, CurrencyCode.USD);
        var rate = new ExchangeRate(CurrencyCode.USD, CurrencyCode.NZD, 1.6m);

        var result = m1 * rate;
        Assert.Equal(new Money(1.6m, CurrencyCode.NZD), result);

        result = rate * m1;
        Assert.Equal(new Money(1.6m, CurrencyCode.NZD), result);
    }

    [Fact]
    public void MoneyDivideDecimal()
    {
        var m1 = new Money(1.5m, CurrencyCode.NZD);

        var result = m1 / 1.5m;
        Assert.Equal(new Money(1m, CurrencyCode.NZD), result);

        result = 1.5m / m1;
        Assert.Equal(new Money(1m, CurrencyCode.NZD), result);
    }

    [Fact]
    public void MoneyRemainderDecimal()
    {
        var m1 = new Money(3m, CurrencyCode.NZD);

        var result = m1 % 2m;
        Assert.Equal(new Money(1m, CurrencyCode.NZD), result);

        result = 4m % m1;
        Assert.Equal(new Money(1m, CurrencyCode.NZD), result);
    }

    [Fact]
    public void MoneyUnaryPlus()
    {
        var m1 = new Money(1m, CurrencyCode.NZD);

        var result = +m1;
        Assert.Equal(new Money(1m, CurrencyCode.NZD), result);
    }

    [Fact]
    public void MoneyUnaryMinus()
    {
        var m1 = new Money(1m, CurrencyCode.NZD);

        var result = -m1;
        Assert.Equal(new Money(-1m, CurrencyCode.NZD), result);
    }

    [Fact]
    public void MoneyUnaryIncrement()
    {
        var m1 = new Money(1m, CurrencyCode.NZD);

        var result = ++m1;
        Assert.Equal(new Money(2m, CurrencyCode.NZD), result);
    }

    [Fact]
    public void MoneyUnaryDecrement()
    {
        var m1 = new Money(2m, CurrencyCode.NZD);

        var result = --m1;
        Assert.Equal(new Money(1m, CurrencyCode.NZD), result);
    }

    [Fact]
    public void MoneyGreaterThan()
    {
        var m1 = new Money(2m, CurrencyCode.NZD);
        var m2 = new Money(1m, CurrencyCode.NZD);

        var result = m1 > m2;
        Assert.True(result);
    }


    [Fact]
    public void MoneyGreaterThanCheckDifferentCurrencyThrowsException()
    {
        var m1 = new Money(2m, CurrencyCode.NZD);
        var m2 = new Money(1m, CurrencyCode.AUD);

        Assert.Throws<CurrencyMismatchException>(() => m1 > m2);
    }

    [Fact]
    public void MoneyLessThan()
    {
        var m1 = new Money(1m, CurrencyCode.NZD);
        var m2 = new Money(2m, CurrencyCode.NZD);

        Assert.True(m1 < m2);
    }

    [Fact]
    public void MoneyGreaterThanOrEqual()
    {
        var m1 = new Money(2m, CurrencyCode.NZD);
        var m2 = new Money(1m, CurrencyCode.NZD);

        Assert.True(m1 >= m2);
    }

    [Fact]
    public void MoneyLessThanOrEqual()
    {
        var m1 = new Money(1m, CurrencyCode.NZD);
        var m2 = new Money(1m, CurrencyCode.NZD);

        Assert.True(m1 <= m2);
    }
}