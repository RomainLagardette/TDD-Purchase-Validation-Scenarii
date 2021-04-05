using System;
using System.Collections.Generic;
using System.Text;
using TDD.Partiel01.Lib;

namespace TDD.Partiel01.LibTests
{
    public class InMemoryCreditCardPayment : ICreditCardPayment
    {
        public bool Process(CreditCardDetails creditCardDetails)
        {
            return creditCardDetails.Number != "9745965412543654";
        }
    }
}
