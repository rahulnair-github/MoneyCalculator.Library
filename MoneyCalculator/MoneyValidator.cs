using System;
using System.Globalization;
using System.Linq;

namespace MoneyCalculatorLibrary
{
    internal  class MoneyValidator
    {
        internal static string ValidateCurrency(string currencyCode)
        {
            if (string.IsNullOrEmpty(currencyCode))
            {
                throw new ArgumentNullException(nameof(currencyCode));
            }
            
            if (!IsValidISOCurrencyCode(currencyCode))
            {
                throw new ArgumentException($" {currencyCode} currency code  is invalid");
            }

            return currencyCode;
        }

        internal static decimal ValidateAmount(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Currency Amount cannot be negative", nameof(amount));
            }

            return amount;
        }

        private  static bool IsValidISOCurrencyCode(string currencyCode)
        {
            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(reg => new RegionInfo(reg.LCID))
                .Any(r => r.ISOCurrencySymbol.Equals(currencyCode,StringComparison.OrdinalIgnoreCase));
                
        }
    }
}
