using System;

namespace TDD.Partiel01.Lib
{
    public class Purchase
    {
        private Item item;

        public Purchase(Item item)
        {
            this.item = item;
        }

        public PurchaseResult Confirm()
        {
            if (item != null)
                return new PurchaseResult(item + " indisponible");
            return new PurchaseResult("solde insuffisant");
        }
    }
}
