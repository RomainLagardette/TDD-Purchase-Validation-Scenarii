using System;

namespace TDD.Partiel01.Lib
{
    public class Purchase
    {
        public static PurchaseResult Confirm()
        {
            return new PurchaseResult("solde insuffisant");
        }
    }
}
