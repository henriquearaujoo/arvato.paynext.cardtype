namespace Arvato.Paynext.CreditCards;

public abstract class CardType
{
    protected CardType next;

    public void SetNext(CardType next)
    {
        this.next = next;
    }

    public abstract CardType GetCardType(string number);
}