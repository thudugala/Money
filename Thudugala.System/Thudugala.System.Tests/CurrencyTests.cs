using System.Globalization;
using System.Reflection;
using System.Text;

namespace Thudugala.System.Tests;

public class CurrencyTests
{
    [Fact]
    public void AllCurrencyCodesAreInRegionInfo()
    {
        var allCulturesCurrencyCodes = new SortedSet<CurrencyCode>();

        foreach (var ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            if (ci.IsNeutralCulture ||
               ci.NativeName == "Invariant Language (Invariant Country)" ||
               ci.CultureTypes.HasFlag(CultureTypes.UserCustomCulture))
            {
                continue;
            }
            var region = new RegionInfo(ci.LCID);

            if (region.ISOCurrencySymbol == "¤¤")
            {
                continue;
            }

            allCulturesCurrencyCodes.Add(new CurrencyCode(region.ISOCurrencySymbol, region.CurrencySymbol, region.CurrencyEnglishName));
        }

        //var sb = new StringBuilder();
        //foreach (var currencyCode in allCulturesCurrencyCodes)
        //{
        //    sb.AppendLine($"public static CurrencyCode {currencyCode.ISOCurrencySymbol} = new(\"{currencyCode.ISOCurrencySymbol}\", \"{currencyCode.CurrencySymbol}\", \"{currencyCode.EnglishName}\");");
        //}
        //var text = sb.ToString();

        var existingCurrencyCodes = typeof(CurrencyCode)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi.IsPublic && fi.IsStatic && fi.FieldType == typeof(CurrencyCode))
            .Select(x => x.GetValue(null) as CurrencyCode)
            .ToHashSet();

        foreach (var currencyCode in allCulturesCurrencyCodes)
        {
            Assert.Contains(currencyCode, existingCurrencyCodes);
        }
    }

    [Fact]
    public void CurrencyParse()
    {
        var nzd = CurrencyCode.Parse("NZD");

        Assert.NotNull(nzd);
        Assert.Equal(CurrencyCode.NZD, nzd);
    }
}
