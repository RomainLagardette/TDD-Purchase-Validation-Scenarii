namespace TDD.Partiel01.Lib
{
    public interface ICreditCardPayment
    {
        bool Process(CreditCardDetails creditCardDetails);
    }
}