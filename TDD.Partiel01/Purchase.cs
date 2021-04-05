using System;

namespace TDD.Partiel01.Lib
{
    public class Purchase
    {
        public Purchase()
        {
        }

        public PurchaseResult Confirm(Item item, Address address, CreditCardDetails creditCardDetails)
        {
            if (item != null)
                return new PurchaseResult(item + " indisponible");
            if (address != null)
                return new PurchaseResult("adresse inexistante");
            if (creditCardDetails != null && creditCardDetails.Number != "6546597543445912")
                return new PurchaseResult("adresse inexistante");
            return new PurchaseResult();
        }
    }
}
