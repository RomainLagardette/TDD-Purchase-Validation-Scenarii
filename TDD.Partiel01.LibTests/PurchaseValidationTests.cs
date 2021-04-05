using System;
using System.Collections;
using TDD.Partiel01.Lib;
using Xunit;

namespace TDD.Partiel01.LibTests
{
    public class PurchaseValidationTests
    {
        //Anna a : un panier de 2 articles, s�lectionn� son adresse de livraison, s�lectionn� mode paiement CB.
        //Lorsque Anna valide son achat
        //Mais que sa banque rejette le paiement pour solde insuffisant
        //Alors l�erreur de la banque est retourn�e et l�achat n�est pas valid�


        [Fact]
        public void AnnaBuyButBankRejectPayment()
        {
            PurchaseResult purchaseResult = Purchase.Confirm();

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Error);
        }
    }
}
