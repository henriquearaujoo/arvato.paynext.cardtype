namespace Arvato.Paynext.Application;

public interface ICreditCardService
{
    CreditCardOutput GetCreditCardType(CreditCardInput input);
}