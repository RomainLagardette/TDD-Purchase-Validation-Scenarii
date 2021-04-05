using System;

namespace TDD.Partiel01.Lib
{
    public class Purchase
    {
        private ICreditCardPayment creditCardPayment;

        public Purchase(ICreditCardPayment creditCardPayment)
        {
            this.creditCardPayment = creditCardPayment;
        }

        public PurchaseResult Confirm(Item item, Address address, CreditCardDetails creditCardDetails)
        {
            if (item != null)
                return new PurchaseResult(item + " indisponible");
            if (address != null)
                return new PurchaseResult("adresse inexistante");
            if (creditCardDetails != null && !creditCardPayment.Process(creditCardDetails))
                return new PurchaseResult("solde insuffisant");
            return new PurchaseResult();
        }
    }
}
