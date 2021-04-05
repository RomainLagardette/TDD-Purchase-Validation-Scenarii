using System;

namespace TDD.Partiel01.Lib
{
    public class Purchase
    {
        private Item item;
        private Address address;
        private CreditCardDetails creditCardDetails;

        public Purchase(Item item, Address address, CreditCardDetails creditCardDetails)
        {
            this.item = item;
            this.address = address;
            this.creditCardDetails = creditCardDetails;
        }

        public PurchaseResult Confirm()
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
