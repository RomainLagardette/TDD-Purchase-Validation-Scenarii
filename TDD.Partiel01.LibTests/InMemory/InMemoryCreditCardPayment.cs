using System;
using System.Collections.Generic;
using System.Text;
using TDD.Partiel01.Lib;
using TDD.Partiel01.Lib.Ports;
using TDD.Partiel01.Lib.Purchases;

namespace TDD.Partiel01.LibTests.InMemory
{
    public class InMemoryCreditCardPayment : ICreditCardPayment
    {
        private readonly List<string> accountInTheRedNumber = new List<string>
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
