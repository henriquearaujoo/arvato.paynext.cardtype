using Arvato.Paynext.Providers;
using Arvato.Paynext.Validation;
using FluentValidation;

namespace Arvato.Paynext.CreditCards;

public class CreditCard
{
    private readonly ICardTypeProvider _cardTypeProvider;

    public CreditCard(
        ICardTypeProvider cardTypeProvider,
        IDateTimeProvider dateTimeProvider,
        string owner,
        string number,
        string issueDate,
        string cvc)
    {
        _cardTypeProvider = cardTypeProvider;
        Owner = owner;
        Number = number;
        IssueDate = issueDate;
        Cvc = cvc;
        CardType = _cardTypeProvider.GetCardType(Number);

        new CreditCardValidator(dateTimeProvider)
            .ValidateAndThrow(this);
    }

    public string Owner { get; }
    public string Number { get; }
    public string IssueDate { get; }
    public string Cvc { get; }
    public CardType CardType { get; }
}