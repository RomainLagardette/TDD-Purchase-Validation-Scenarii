using System;
using System.Collections;
using TDD.Partiel01.Lib;
using Xunit;

namespace TDD.Partiel01.LibTests
{
    public class PurchaseValidationTests
    {
        //Anna a : un panier de 2 articles, sélectionné son adresse de livraison, sélectionné mode paiement CB.
        //Lorsque Anna valide son achat
        //Mais que sa banque rejette le paiement pour solde insuffisant
        //Alors l’erreur de la banque est retournée et l’achat n’est pas validé
        [Fact]
        public void AnnaBuyButBankRejectPayment()
        {
            PurchaseResult purchaseResult = new Purchase(null).Confirm();

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Error);
        }

        //Kevin a : un panier de 3 articles, sélectionné son adresse de livraison, sélectionné mode paiement CB.
        //Lorsque Kevin valide son achat
        //Mais qu’un des articles n’est plus disponible (après vérification des données (catalog))
        //Alors le nom de l’article manquant est retourné et l’achat n’est pas validé
        [Fact]
        public void KevinBuyButOneArticleIsNoLongerAvailable()
        {
            Item item = new Item("tee-shirt rouge");
            Purchase purchase = new Purchase(item);

            PurchaseResult purchaseResult = purchase.Confirm();

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Error);
            Assert.Equal("tee-shirt rouge indisponible", purchaseResult.Error);
        }
    }
}
