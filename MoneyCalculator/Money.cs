using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCalculator
{
    public class Money : IMoney
    {
        private readonly decimal amount;
        private readonly string currencyCode;
        public Money(decimal amount, string currencyCode )
        {
           
        }
        
       public decimal Amount => amount;

        public string Currency => currencyCode;
    }
}
