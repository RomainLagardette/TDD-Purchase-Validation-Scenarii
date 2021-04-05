using System;

namespace TDD.Partiel01.Lib
{
    public class Purchase
    {
        private Item item;
        private Address address;

        public Purchase(Item item)
        {
            this.item = item;
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
            return new PurchaseResult("solde insuffisant");
        }
    }
}
