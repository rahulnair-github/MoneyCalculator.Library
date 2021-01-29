using MoneyCalculatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MoneyCalculatorTest
{
    public class MoneyCalculatorTest
    {
        [Fact]
        public void MaxMoneyTest()
        {
            IMoneyCalculator moneyCalculator = new MoneyCalculatorLibrary.MoneyCalculator();
            var monies = GetMoneyList();
            var expected = monies.Max(x => x.Amount);
            var result = moneyCalculator.Max(monies);
            Assert.Equal(expected, result.Amount);
        }

        [Fact]
        public void MaxforMoniesinDifferentCurrenciesTest()
        {
            IMoneyCalculator moneyCalculator = new MoneyCalculator();
            var monies = GetMoneyListWithMultipleCurrencies();
            Assert.Throws<ArgumentException>(() => moneyCalculator.Max(monies));
        }
        [Fact]
        public void MaxTestforNullMonies()
        {
            IMoneyCalculator moneyCalculator = new MoneyCalculator();
            Assert.Throws<ArgumentNullException>(() => moneyCalculator.Max(null));
        }

        [Fact]
        public void SumPerCurrencyTest()
        {
            IMoneyCalculator moneyCalculator = new MoneyCalculator ();
            IEnumerable<IMoney> monies = GetMoneyListWithMultipleCurrencies();
            var actual = moneyCalculator.SumPerCurrency(monies);
            var expected = new List<IMoney> {
                new Money(currencyCode:"GBP",amount:300.00M),
                new Money(currencyCode:"USD",amount:350.00M)
            };

            var equality = CheckMoneyListEquality(actual, expected);

            Assert.True(equality);

        }

        [Fact]
        public void SumPerCurrencyNullTest()
        {
            IMoneyCalculator moneyCalculator = new MoneyCalculator();
            Assert.Throws<ArgumentNullException>(()=> moneyCalculator.SumPerCurrency(null));

        }

        [Fact]
        public void SumPerCurrencyEmptyListTest()
        {
            IMoneyCalculator moneyCalculator = new MoneyCalculator();
            Assert.Throws<ArgumentNullException>(() => moneyCalculator.SumPerCurrency(new List<IMoney>()));

        }




        #region Private Methods

        private bool CheckMoneyListEquality(IEnumerable<IMoney> actual, IEnumerable<IMoney> expected)
        {
            if (actual.Count() != expected.Count())
            {
                return false;
            }

            foreach (var item in actual)
            {
                var expectedItem = expected.FirstOrDefault(i => i.Currency == item.Currency);
                if (expectedItem == null)
                {
                    return false;
                }

                if (expectedItem.Amount != item.Amount)
                {
                    return false;
                }
            }
            return true;
        }
        private IEnumerable<IMoney> GetMoneyListWithMultipleCurrencies()
        {
            return new List<IMoney> {
                new Money(100.00M, "GBP"),
                new Money(200.00M, "GBP"),

                new Money(100.00M, "USD"),
                new Money(250.00M, "USD"),

            };
        }

        private IEnumerable<IMoney> GetMoneyList()
        {
            return new List<IMoney> {
                new Money(100.00M, "GBP"),
                new Money(200.00M, "GBP"),
                new Money(300.00M, "GBP"),
            };
        }
        #endregion
    }
}

