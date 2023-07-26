<img src="https://raw.githubusercontent.com/thudugala/Money/main/Screenshots/icon.png" width="128px"/>

[![NuGet](https://img.shields.io/nuget/v/Thudugala.MultiCurrencyMoney.svg)](https://www.nuget.org/packages/Thudugala.MultiCurrencyMoney/) 
[![NuGet](https://img.shields.io/nuget/dt/Thudugala.MultiCurrencyMoney.svg)](https://www.nuget.org/packages/Thudugala.MultiCurrencyMoney/)

# Money
A Money class with multi-currency arithmetic for.Net

## Usage

### Money

```cs
var m1 = new Money(0m, CurrencyCode.NZD);

// When CurrencyCode is not specified.
// CurrencyCode will default to GlobalSetting.DefaultCurrencyCode.
var m2 = new Money(0m);

// When the amount and CurrencyCode are not specified.
// The amount will default to zero, and CurrencyCode will default to GlobalSetting.DefaultCurrencyCode.
var m3 = new Money();

// Money.Empty is the same as new Money()
var m4 = Money.Empty;

var m5 = Money.Parse("1.06 NZD");
```

### CurrencyCode

Default CurrencyCode is GlobalSetting.DefaultCurrencyCode and can be changed

```cs
GlobalSetting.DefaultCurrencyCode = CurrencyCode.AUD
```
CurrencyCode class can be to be inherited and ad new currency codes if needed

### ExchangeRate

Money can be multiplied by ExchangeRate and changed to different Currency

```cs
var m1 = new Money(1m, CurrencyCode.USD);
var rate = new ExchangeRate(CurrencyCode.USD, CurrencyCode.NZD, 1.6m, DateTime.Today);

var result = m1 * rate;
Assert.Equal(new Money(1.6m, CurrencyCode.NZD), result);
```

## Rules

1. Money can only be added or Subtract using the same currency Money
2. Money can only be multiplied using decimal or ExchangeRate
3. Money can only be divided and checked remainder using decimal

## Thank you
- Thank you for the Icons by [Paomedia](https://www.iconfinder.com/paomedia)
