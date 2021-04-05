using System;
using System.Collections;
using System.Collections.Generic;
using TDD.Partiel01.Lib;
using Xunit;

namespace TDD.Partiel01.LibTests
{
    public class PurchaseValidationTests
    {
        //Anna a : 
        //- un panier de 2 articles « chemise verte » et « pantalon noir »
        //- sélectionné son adresse de livraison « 55 Rue du Faubourg Saint-Honoré »
        //- renseigné sa CB « 9745965412543654 »
        //Lorsque Anna valide son achat
        //Mais que sa banque rejette le paiement pour solde insuffisant
        //Alors l’erreur de la banque est retournée et l’achat n’est pas validé
        [Fact]
        public void AnnaBuyButBankRejectPayment()
        {
            List<Item> items = new List<Item>
            {
                new Item("chemise verte"),
                new Item("pantalon noir"),
            };
            CreditCardDetails creditCardDetails = new CreditCardDetails("9745965412543654");
            Address address = new Address("55 Rue du Faubourg Saint-Honoré");

            Purchase purchase = new Purchase(new InMemoryCreditCardPayment(), new InMemoryAddressProvider());

            PurchaseResult purchaseResult = purchase.Confirm(items, address, creditCardDetails);

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Errors);
            Assert.Equal("solde insuffisant", purchaseResult.Errors.First());
        }

        //Kevin a : 
        //- un panier de 3 articles « tee-shirt rouge » et « short blanc » et « pull violet »
        //- sélectionné son adresse de livraison « 1 Avenue du Colonel Henri Rol-Tanguy »
        //- renseigné sa CB « 7895265452543153 »
        //Lorsque Kevin valide son achat
        //Mais que l’article « tee-shirt rouge » n’est plus disponible(après vérification des données (catalog))
        //Alors le nom de l’article manquant est retourné et l’achat n’est pas validé
        [Fact]
        public void KevinBuyButOneArticleIsNoLongerAvailable()
        {
            List<Item> items = new List<Item>
            {
                new Item("tee-shirt rouge"),
                new Item("short blanc"),
                new Item("pull violet"),
            };
            CreditCardDetails creditCardDetails = new CreditCardDetails("7895265452543153");
            Address address = new Address("1 Avenue du Colonel Henri Rol-Tanguy");

            Purchase purchase = new Purchase(new InMemoryCreditCardPayment(), new InMemoryAddressProvider());

            PurchaseResult purchaseResult = purchase.Confirm(items, address, creditCardDetails);

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Errors);
            Assert.Equal("tee-shirt rouge indisponible", purchaseResult.Errors.First());
        }

        //John a : 
        //- un panier de 2 articles « pull rouge » et « pull violet »
        //- sélectionné son adresse de livraison « 77 Avenue du Jambon »
        //- renseigné sa CB « 7526215354358945 »
        //Lorsque John valide son achat
        //Mais que l’adresse de livraison n’existe pas(vérification dans un moteur de recherche (provider))
        //Alors un message d’erreur est retourné et l’achat n’est pas validé
        [Fact]
        public void JohnBuyButAddressIsInexistant()
        {
            List<Item> items = new List<Item>
            {
                new Item("pull rouge"),
                new Item("pull violet"),
            };
            CreditCardDetails creditCardDetails = new CreditCardDetails("7526215354358945");
            Address address = new Address("77 Avenue du Jambon");

            Purchase purchase = new Purchase(new InMemoryCreditCardPayment(), new InMemoryAddressProvider());

            PurchaseResult purchaseResult = purchase.Confirm(items, address, creditCardDetails);

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Errors);
            Assert.Equal("adresse inexistante", purchaseResult.Errors.First());
        }

        //Laura a :
        //- un panier de 2 articles « pull rouge » et « pantalon noir »
        //- sélectionné son adresse de livraison « 55 Rue du Faubourg Saint-Honoré »
        //- renseigné sa CB « 6546597543445912 »
        //Lorsque Laura valide son achat
        //Que l’adresse de livraison existe
        //Que tous les articles sont disponibles
        //Que la banque confirme le paiement
        //Alors l’achat est validé
        [Fact]
        public void LauraBuyAndThePurchaseIsValid()
        {
            List<Item> items = new List<Item>
            {
                new Item("pull rouge"),
                new Item("pantalon noir")
            };
            CreditCardDetails creditCardDetails = new CreditCardDetails("6546597543445912");
            Address address = new Address("55 Rue du Faubourg Saint-Honoré");

            Purchase purchase = new Purchase(new InMemoryCreditCardPayment(), new InMemoryAddressProvider());

            PurchaseResult purchaseResult = purchase.Confirm(items, address, creditCardDetails);

            Assert.True(purchaseResult.IsValid);
        }

        //Marie a : 
        //- un panier de 2 articles « tee-shirt rouge » et « pull rose » 
        //- sélectionné son adresse de livraison « 98 Avenue du saucisson » 
        //- renseigné sa CB « 1265599754346544 »
        //Lorsque Marie valide son achat
        //Mais que sa banque rejette le paiement pour solde insuffisant
        //Et que les 2 articles ne sont plus disponible(après vérification des données (catalog))
        //Et que l’adresse de livraison n’existe pas(vérification dans un moteur de recherche (provider))
        //Alors tous les messages d’erreur sont retourné et l’achat n’est pas validé

        [Fact]
        public void MarieBuyButAddressIsInexistantAndOneArticleIsNoLongerAvailableAndBankRejectPayment()
        {
            List<Item> items = new List<Item>
            {
                new Item("tee-shirt rouge"),
                new Item("pull rose"),
            };
            CreditCardDetails creditCardDetails = new CreditCardDetails("1265599754346544");
            Address address = new Address("98 Avenue du saucisson");

            Purchase purchase = new Purchase(new InMemoryCreditCardPayment(), new InMemoryAddressProvider());

            PurchaseResult purchaseResult = purchase.Confirm(items, address, creditCardDetails);

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Errors);
            Assert.True(purchaseResult.Errors.Any(_=>_ == "adresse inexistante"));
        }
    }
}
