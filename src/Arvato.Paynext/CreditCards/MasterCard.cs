namespace Arvato.Paynext.CreditCards;

public class MasterCard : CardType
{
    public override CardType GetCardType(string number)
    {
        if (number.StartsWith("51")
            || number.StartsWith("52")
            || number.StartsWith("53")
            || number.StartsWith("54")
            || number.StartsWith("55"))
            return this;

        if (next != null)
            return next.GetCardType(number);
            
        return new UnknownType();
    }

    public override string ToString()
    {
        return "MasterCard";
    }
}