namespace Arvato.Paynext.CreditCards;

public interface ICardTypeProvider
{
    CardType GetCardType(string number);
}