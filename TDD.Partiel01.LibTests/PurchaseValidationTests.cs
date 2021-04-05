using System;
using System.Collections;
using TDD.Partiel01.Lib;
using Xunit;

namespace TDD.Partiel01.LibTests
{
    public class PurchaseValidationTests
    {
        //Anna a : 
        //- un panier de 2 articles � chemise verte � et � pantalon noir �
        //- s�lectionn� son adresse de livraison � 55 Rue du Faubourg Saint-Honor� �
        //- renseign� sa CB � 9745965412543654 �
        //Lorsque Anna valide son achat
        //Mais que sa banque rejette le paiement pour solde insuffisant
        //Alors l�erreur de la banque est retourn�e et l�achat n�est pas valid�
        [Fact]
        public void AnnaBuyButBankRejectPayment()
        {
            CreditCardDetails creditCardDetails = new CreditCardDetails("9745965412543654");

            PurchaseResult purchaseResult = new Purchase().Confirm(null, null, creditCardDetails);

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Error);
        }

        //Kevin a : 
        //- un panier de 3 articles � tee-shirt rouge � et � short blanc � et � pull violet �
        //- s�lectionn� son adresse de livraison � 1 Avenue du Colonel Henri Rol-Tanguy �
        //- renseign� sa CB � 7895265452543153 �
        //Lorsque Kevin valide son achat
        //Mais que l�article � tee-shirt rouge � n�est plus disponible(apr�s v�rification des donn�es (catalog))
        //Alors le nom de l�article manquant est retourn� et l�achat n�est pas valid�
        [Fact]
        public void KevinBuyButOneArticleIsNoLongerAvailable()
        {
            CreditCardDetails creditCardDetails = new CreditCardDetails("7895265452543153");
            Item item = new Item("tee-shirt rouge");
            Purchase purchase = new Purchase();

            PurchaseResult purchaseResult = purchase.Confirm(item, null, creditCardDetails);

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Error);
            Assert.Equal("tee-shirt rouge indisponible", purchaseResult.Error);
        }

        //John a : 
        //- un panier de 2 articles � pull rouge � et � pull violet �
        //- s�lectionn� son adresse de livraison � 77 Avenue du Jambon �
        //- renseign� sa CB � 7526215354358945 �
        //Lorsque John valide son achat
        //Mais que l�adresse de livraison n�existe pas(v�rification dans un moteur de recherche (provider))
        //Alors un message d�erreur est retourn� et l�achat n�est pas valid�
        [Fact]
        public void JohnBuyButAddressIsInexistant()
        {
            CreditCardDetails creditCardDetails = new CreditCardDetails("7526215354358945");
            Address address = new Address();
            Purchase purchase = new Purchase();

            PurchaseResult purchaseResult = purchase.Confirm(null, address, creditCardDetails);

            Assert.False(purchaseResult.IsValid);
            Assert.NotEmpty(purchaseResult.Error);
            Assert.Equal("adresse inexistante", purchaseResult.Error);
        }

        //Laura a :
        //- un panier de 2 articles � pull rouge � et � pantalon noir �
        //- s�lectionn� son adresse de livraison � 55 Rue du Faubourg Saint-Honor� �
        //- renseign� sa CB � 6546597543445912 �
        //Lorsque Laura valide son achat
        //Que l�adresse de livraison existe
        //Que tous les articles sont disponibles
        //Que la banque confirme le paiement
        //Alors l�achat est valid�
        [Fact]
        public void LauraBuyAndThePurchaseIsValid()
        {
            CreditCardDetails creditCardDetails = new CreditCardDetails("6546597543445912");

            Purchase purchase = new Purchase();

            PurchaseResult purchaseResult = purchase.Confirm(null, null, creditCardDetails);

            Assert.True(purchaseResult.IsValid);
        }
    }
}
