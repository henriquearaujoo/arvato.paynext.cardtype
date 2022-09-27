using Arvato.Paynext.CreditCards;

namespace Arvato.Paynext.Providers;

public class CardTypeProvider : ICardTypeProvider
{
    public CardType GetCardType(string number)
    {
        var visa = new Visa();
        var american = new AmericanExpress();
        var masterCard = new MasterCard();

        visa.SetNext(american);
        american.SetNext(masterCard);

        return visa.GetCardType(number);
    }
}