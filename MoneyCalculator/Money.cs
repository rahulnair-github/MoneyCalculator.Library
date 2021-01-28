using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MoneyCalculator
{
    public class Money : IMoney
    {
        private readonly decimal amount;
        private readonly string currencyCode;
        private static readonly IEnumerable<string> CurrencyCodes = GetValidCurrencyCodes();

        public Money(decimal amount, string currencyCode)
        {
            this.amount = ValidateAmount(amount);
            this.currencyCode = ValidateCurrency(currencyCode);
        }
        private static IEnumerable<string> GetValidCurrencyCodes()
        {
            if (CurrencyCodes != null)
            {
                return CurrencyCodes;
            }

            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(reg => new RegionInfo(reg.LCID))
                .Select(cur => cur.ISOCurrencySymbol);

        }

        private string ValidateCurrency(string currencyCode)
        {
            if (string.IsNullOrEmpty(currencyCode))
            {
                throw new ArgumentNullException("currencyCode");
            }

            if (!CurrencyCodes.Any(c => c.Equals(currencyCode)))
            {
                throw new ArgumentException("Currency Code invalid", nameof(currencyCode));
            }

            return currencyCode;
        }

        private decimal ValidateAmount(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Currency Amount cannot be negative", nameof(amount));
            }

            return amount;
        }

        public decimal Amount => amount;

        public string Currency => currencyCode;
    }
}
