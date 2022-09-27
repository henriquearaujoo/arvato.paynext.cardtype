namespace Arvato.Paynext.CreditCards;

public class UnknownType : CardType
{
    public override CardType GetCardType(string number)
    {
        return this;
    }

    public override string ToString()
    {
        return "Unknown";
    }
}