namespace Arvato.Paynext.CreditCards;

public class Visa : CardType
{
    public override CardType GetCardType(string number)
    {
        if (number.StartsWith("4"))
            return this;

        if (next != null)
            return next.GetCardType(number);

        return new UnknownType();
    }

    public override string ToString()
    {
        return "Visa";
    }
}