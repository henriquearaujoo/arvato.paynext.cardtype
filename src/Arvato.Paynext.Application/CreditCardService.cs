using Arvato.Paynext.CreditCards;

namespace Arvato.Paynext.Application;

public class CreditCardService : ICreditCardService
{
    private readonly ICardTypeProvider _cardTypeProvider;

    public CreditCardService(ICardTypeProvider cardTypeProvider)
    {
        _cardTypeProvider = cardTypeProvider;
    }
    public CreditCardOutput GetCreditCardType(CreditCardInput input)
    {
        var result = new CreditCard(
            _cardTypeProvider,
            input.Owner,
            input.Number,
            input.IssueDate,
            input.Cvc);
        
        return new CreditCardOutput
        {
            CardType = result.CardType.ToString()
        };
    }
}