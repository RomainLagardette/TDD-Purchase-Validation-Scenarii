using System;
using System.Collections.Generic;
using System.Text;
using TDD.Partiel01.Lib;

namespace TDD.Partiel01.LibTests
{
    public class InMemoryCreditCardPayment : ICreditCardPayment
    {
        private List<string> accountInTheRedNumber = new List<string>
        {
            "9745965412543654",
            "1265599754346544"
        };

        public bool Process(CreditCardDetails creditCardDetails)
        {
            return !accountInTheRedNumber.Contains(creditCardDetails.Number);
        }
    }
}
