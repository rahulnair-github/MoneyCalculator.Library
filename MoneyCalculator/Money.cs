using MoneyCalculator.Library;
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
        

        public Money(decimal amount, string currencyCode)
        {
            this.amount = MoneyValidator.ValidateAmount(amount);
            this.currencyCode = MoneyValidator.ValidateCurrency(currencyCode).ToUpperInvariant();
        }
       
        public decimal Amount => amount;

        public string Currency => currencyCode;
    }
}
