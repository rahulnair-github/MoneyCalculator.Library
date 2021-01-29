using MoneyCalculatorLibrary;
using System;
using Xunit;

namespace MoneyCalculatorTest
{
    public class MoneyTest
    {
        [Fact]
        public void NegativeAmountTest()
        {
            Assert.Throws<ArgumentException>(()=>  new Money(-5.34M, "GBP"));            
        }

        [Fact]
        public void InvalidCurrencyTest()
        {   
            Assert.Throws<ArgumentException>(() => new Money(5.34M, "testB"));
        }

        [Fact]
        public void LowerCaseCurrencyTest()
        {
            IMoney money = new Money(5.34M, "gbp");
            Assert.NotNull(money);
        }

        [Fact]
        public void EmptyCurrecyCode()
        {  
            Assert.Throws<ArgumentNullException>(() =>  new Money(5.34M, string.Empty));
        }

        [Fact]
        public void NullCurrecyCode()
        {
            Assert.Throws<ArgumentNullException>(() =>new Money(5.34M, null));
        }


    }
}
