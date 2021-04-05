using System;

namespace TDD.Partiel01.Lib
{
    public class Purchase
    {
        private ICreditCardPayment creditCardPayment;
        private IAddressProvider addressProvider;

        public Purchase(ICreditCardPayment creditCardPayment, IAddressProvider addressProvider)
        {
            this.creditCardPayment = creditCardPayment;
            this.addressProvider = addressProvider;
        }

        public PurchaseResult Confirm(Item item, Address address, CreditCardDetails creditCardDetails)
        {
            if (item != null)
                return new PurchaseResult(item + " indisponible");
            if (address != null && addressProvider.Exist(address.Line1))
                return new PurchaseResult("adresse inexistante");
            if (creditCardDetails != null && !creditCardPayment.Process(creditCardDetails))
                return new PurchaseResult("solde insuffisant");
            return new PurchaseResult();
        }
    }
}
