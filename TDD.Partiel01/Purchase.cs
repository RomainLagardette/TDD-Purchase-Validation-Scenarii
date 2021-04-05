using System;
using System.Collections.Generic;
using System.Linq;

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

        public PurchaseResult Confirm(List<Item> items, Address address, CreditCardDetails creditCardDetails)
        {
            if (items != null && items.Any(_=>_.Name == "tee-shirt rouge"))
                return new PurchaseResult("tee-shirt rouge" + " indisponible");
            if (address != null && addressProvider.Exist(address.Line1))
                return new PurchaseResult("adresse inexistante");
            if (creditCardDetails != null && !creditCardPayment.Process(creditCardDetails))
                return new PurchaseResult("solde insuffisant");
            return new PurchaseResult();
        }
    }
}
