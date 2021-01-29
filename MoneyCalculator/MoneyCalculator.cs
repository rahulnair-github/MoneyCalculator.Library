using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyCalculatorLibrary
{
    public class MoneyCalculator : IMoneyCalculator
    {
        public IMoney Max(IEnumerable<IMoney> monies)
        {
            if (monies == null || !monies.Any())
            {
                throw new ArgumentNullException("IEnumerable<IMoney>","Input money list either null or empty");
            }

            var currencies = monies.Select(m => m.Currency).Distinct();

            if (currencies.Count() > 1)
            {
                throw new ArgumentException("Multiple Currencies not allowed in this method");
            }

            var amount = monies.Max(m => m.Amount);
            return new Money(amount,currencies.First());
        }

        public IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies)
        {
            if (monies == null || !monies.Any())
            {
                throw new ArgumentNullException("IEnumerable<IMoney>", "Input money list either null or empty");
            }

            List<IMoney> sumPerCurrencyList= new List<IMoney>();
            var currencyGroups = monies.GroupBy(x => x.Currency);

            foreach (var item in currencyGroups)
            {
                decimal sum = item.Sum(x => x.Amount);
                sumPerCurrencyList.Add(new Money(sum, item.Key));
            }
            return sumPerCurrencyList;
        }
    }
}
