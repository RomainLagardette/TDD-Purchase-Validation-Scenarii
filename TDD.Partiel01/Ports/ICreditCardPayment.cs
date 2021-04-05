using TDD.Partiel01.Lib.Purchases;

namespace TDD.Partiel01.Lib.Ports
{
    public interface ICreditCardPayment
    {
        bool Process(CreditCardDetails creditCardDetails);
    }
}