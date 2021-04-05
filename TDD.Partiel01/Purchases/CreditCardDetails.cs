using System;
using System.Collections.Generic;
using System.Text;

namespace TDD.Partiel01.Lib.Purchases
{
    public class CreditCardDetails
    {
        public string Number { get; private set; }

        public CreditCardDetails(string number)
        {
            this.Number = number;
        }
    }
}
