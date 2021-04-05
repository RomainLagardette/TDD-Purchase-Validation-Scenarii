using System;

namespace TDD.Partiel01.Lib
{
    public class Purchase
    {
        private Item item;
        private Address address;
        private CreditCardDetails creditCardDetails;

        public Purchase()
        {
        }

        public Purchase(Item item)
        {
            this.item = item;
        }

        public Purchase(CreditCardDetails creditCardDetails)
        {
            this.creditCardDetails = creditCardDetails;
        }

        public Purchase(Item item, Address address) : this(item)
        {
            this.address = address;
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
