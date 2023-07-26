using System.Globalization;
using System.Reflection;

namespace Thudugala.System.Tests;

public class CurrencyTests
{
    [Fact]
    public void AllCurrencyCodesAreInRegionInfo()
    {
        var iSOCurrencySymbols = new SortedSet<string>();

        foreach (var ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            if (ci.IsNeutralCulture ||
               ci.NativeName == "Invariant Language (Invariant Country)" ||
               ci.CultureTypes.HasFlag(CultureTypes.UserCustomCulture))
            {
                continue;
            }
            var regin = new RegionInfo(ci.LCID);

            if (regin.ISOCurrencySymbol == "¤¤")
            {
                continue;
            }

            iSOCurrencySymbols.Add(regin.ISOCurrencySymbol);
        }

        var existingCurrencyCodes = typeof(CurrencyCode)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
            .Select(x => x.Name)
            .ToHashSet();

        foreach (var iSOCurrencySymbol in iSOCurrencySymbols)
        {
            Assert.Contains(iSOCurrencySymbol, existingCurrencyCodes);
        }
    }        
}
