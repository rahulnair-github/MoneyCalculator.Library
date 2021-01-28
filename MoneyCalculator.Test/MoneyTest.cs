using System;
using Xunit;

namespace MoneyCalculator.Test
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
