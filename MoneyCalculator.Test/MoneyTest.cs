using System;
using Xunit;

namespace MoneyCalculator.Test
{
    public class MoneyTest
    {

        IMoney money; 

        [Fact]
        public void NegativeAmountTest()
        {
            IMoney money;
            Assert.Throws<ArgumentException>(()=> money = new Money(-5.34M, "GBP"));            
        }

        [Fact]
        public void InvalidCurrencyTest()
        {
            IMoney money;
            Assert.Throws<ArgumentException>(() => money = new Money(5.34M, "testB"));
        }

        [Fact]
        public void EmptyCurrecyCode()
        {
            IMoney money;
            Assert.Throws<ArgumentException>(() => money = new Money(5.34M, string.Empty));
        }

    }
}
