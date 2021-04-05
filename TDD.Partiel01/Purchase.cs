﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD.Partiel01.Lib
{
    public class Purchase
    {
        private ICreditCardPayment creditCardPayment;
        private IAddressProvider addressProvider;
        private IItemCatalog itemCatalog;

        public Purchase(ICreditCardPayment creditCardPayment, IAddressProvider addressProvider, IItemCatalog itemCatalog)
        {
            this.creditCardPayment = creditCardPayment;
            this.addressProvider = addressProvider;
            this.itemCatalog = itemCatalog;
        }

        public PurchaseResult Confirm(List<Item> items, Address address, CreditCardDetails creditCardDetails)
        {
            PurchaseResult purchaseResult = new PurchaseResult();
            if (items != null && itemCatalog.IsUnavailable(items))
                purchaseResult.AddError(itemCatalog.GetUnavailables(items).Select(_=>_.Name + " indisponible").ToList());
            if (address != null && addressProvider.Exist(address.Line1))
                purchaseResult.AddError("adresse inexistante");
            if (creditCardDetails != null && !creditCardPayment.Process(creditCardDetails))
                purchaseResult.AddError("solde insuffisant");
            return purchaseResult;
        }
    }
}
