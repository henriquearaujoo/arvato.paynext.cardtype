using Arvato.Paynext.CreditCards;
using Arvato.Paynext.Providers;

namespace Arvato.Paynext.Application;

public class CreditCardService : ICreditCardService
{
    private readonly ICardTypeProvider _cardTypeProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreditCardService(
        ICardTypeProvider cardTypeProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _cardTypeProvider = cardTypeProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public CreditCardOutput GetCreditCardType(CreditCardInput input)
    {
        var result = new CreditCard(
            _cardTypeProvider,
            _dateTimeProvider,
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