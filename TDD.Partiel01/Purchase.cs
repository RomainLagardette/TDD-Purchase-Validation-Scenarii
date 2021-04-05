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
            PurchaseResult purchaseResult = new PurchaseResult();
            if (items != null && items.Any(_=>_.Name == "tee-shirt rouge"))
                purchaseResult.AddError("tee-shirt rouge" + " indisponible");
            if (address != null && addressProvider.Exist(address.Line1))
                purchaseResult.AddError("adresse inexistante");
            if (creditCardDetails != null && !creditCardPayment.Process(creditCardDetails))
                purchaseResult.AddError("solde insuffisant");
            return purchaseResult;
        }
    }
}
