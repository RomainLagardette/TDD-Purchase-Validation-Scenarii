using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TDD.Partiel01.Lib;
using TDD.Partiel01.Lib.Purchases;
using TDD.Partiel01.LibTests.InMemory;
using Xunit;

namespace TDD.Partiel01.LibTests
{
    public class PurchaseValidationTests
    {
        private Purchase NewPurchase => new Purchase(new InMemoryCreditCardPayment(), new InMemoryAddressProvider(), new InMemoryItems());

        private List<Item> NewItems(params string[] itemsName)
        {
            return itemsName.Select(_ => new Item(_)).ToList();
        }

        //Anna a : 
        //- un panier de 2 articles ? chemise verte ? et ? pantalon noir ?
        //- s?lectionn? son adresse de livraison ? 55 Rue du Faubourg Saint-Honor? ?
        //- renseign? sa CB ? 9745965412543654 ?
        //Lorsque Anna valide son achat
        //Mais que sa banque rejette le paiement pour solde insuffisant
        //Alors l?erreur de la banque est retourn?e et l?achat n?est pas valid?
        [Fact]
        public void AnnaBuyButBankRejectPayment()
        {
            List<Item> items = NewItems("chemise verte", "pantalon noir");
            CreditCardDetails creditCardDetails = new CreditCardDetails("9745965412543654");
            Address address = new Address("55 Rue du Faubourg Saint-Honor?");

            PurchaseResult purchaseResult = NewPurchase.Confirm(items, address, creditCardDetails);

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Errors);
            Assert.Equal("solde insuffisant", purchaseResult.Errors.First());
        }

        //Kevin a : 
        //- un panier de 3 articles ? tee-shirt rouge ? et ? short blanc ? et ? pull violet ?
        //- s?lectionn? son adresse de livraison ? 1 Avenue du Colonel Henri Rol-Tanguy ?
        //- renseign? sa CB ? 7895265452543153 ?
        //Lorsque Kevin valide son achat
        //Mais que l?article ? tee-shirt rouge ? n?est plus disponible(apr?s v?rification des donn?es (catalog))
        //Alors le nom de l?article manquant est retourn? et l?achat n?est pas valid?
        [Fact]
        public void KevinBuyButOneArticleIsNoLongerAvailable()
        {
            List<Item> items = NewItems("tee-shirt rouge", "short blanc", "pull violet");
            CreditCardDetails creditCardDetails = new CreditCardDetails("7895265452543153");
            Address address = new Address("1 Avenue du Colonel Henri Rol-Tanguy");

            PurchaseResult purchaseResult = NewPurchase.Confirm(items, address, creditCardDetails);

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Errors);
            Assert.Equal("tee-shirt rouge indisponible", purchaseResult.Errors.First());
        }

        //John a : 
        //- un panier de 2 articles ? pull rouge ? et ? pull violet ?
        //- s?lectionn? son adresse de livraison ? 77 Avenue du Jambon ?
        //- renseign? sa CB ? 7526215354358945 ?
        //Lorsque John valide son achat
        //Mais que l?adresse de livraison n?existe pas(v?rification dans un moteur de recherche (provider))
        //Alors un message d?erreur est retourn? et l?achat n?est pas valid?
        [Fact]
        public void JohnBuyButAddressIsInexistant()
        {
            List<Item> items = NewItems("pull rouge", "pull violet");
            CreditCardDetails creditCardDetails = new CreditCardDetails("7526215354358945");
            Address address = new Address("77 Avenue du Jambon");

            PurchaseResult purchaseResult = NewPurchase.Confirm(items, address, creditCardDetails);

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Errors);
            Assert.Equal("adresse inexistante", purchaseResult.Errors.First());
        }

        //Laura a :
        //- un panier de 2 articles ? pull rouge ? et ? pantalon noir ?
        //- s?lectionn? son adresse de livraison ? 55 Rue du Faubourg Saint-Honor? ?
        //- renseign? sa CB ? 6546597543445912 ?
        //Lorsque Laura valide son achat
        //Que l?adresse de livraison existe
        //Que tous les articles sont disponibles
        //Que la banque confirme le paiement
        //Alors l?achat est valid?
        [Fact]
        public void LauraBuyAndThePurchaseIsValid()
        {
            List<Item> items = NewItems("pull rouge", "pantalon noir");
            CreditCardDetails creditCardDetails = new CreditCardDetails("6546597543445912");
            Address address = new Address("55 Rue du Faubourg Saint-Honor?");

            PurchaseResult purchaseResult = NewPurchase.Confirm(items, address, creditCardDetails);

            Assert.True(purchaseResult.IsValid);
        }

        //Marie a : 
        //- un panier de 2 articles ? tee-shirt rouge ? et ? pull rose ? 
        //- s?lectionn? son adresse de livraison ? 98 Avenue du saucisson ? 
        //- renseign? sa CB ? 1265599754346544 ?
        //Lorsque Marie valide son achat
        //Mais que sa banque rejette le paiement pour solde insuffisant
        //Et que les 2 articles ne sont plus disponible(apr?s v?rification des donn?es (catalog))
        //Et que l?adresse de livraison n?existe pas(v?rification dans un moteur de recherche (provider))
        //Alors tous les messages d?erreur sont retourn? et l?achat n?est pas valid?

        [Fact]
        public void MarieBuyButAddressIsInexistantAndOneArticleIsNoLongerAvailableAndBankRejectPayment()
        {
            List<Item> items = NewItems("tee-shirt rouge", "pull rose");
            CreditCardDetails creditCardDetails = new CreditCardDetails("1265599754346544");
            Address address = new Address("98 Avenue du saucisson");

            PurchaseResult purchaseResult = NewPurchase.Confirm(items, address, creditCardDetails);

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Errors);
            Assert.Contains(purchaseResult.Errors, _ => _ == "tee-shirt rouge indisponible");
            Assert.Contains(purchaseResult.Errors, _ => _ == "pull rose indisponible");
            Assert.Contains(purchaseResult.Errors, _ => _ == "adresse inexistante");
            Assert.Contains(purchaseResult.Errors, _ => _ == "solde insuffisant");
        }
    }
}
