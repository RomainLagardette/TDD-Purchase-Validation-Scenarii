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
            if (address != null && (address.Line1 == "98 Avenue du saucisson" || address.Line1 == "77 Avenue du Jambon"))
                return new PurchaseResult("adresse inexistante");
            if (creditCardDetails != null && !creditCardPayment.Process(creditCardDetails))
                return new PurchaseResult("solde insuffisant");
            return new PurchaseResult();
        }
    }
}
