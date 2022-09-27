namespace Arvato.Paynext.CreditCards;

public class AmericanExpress : CardType
{
    public override CardType GetCardType(string number)
    {
        if (number.StartsWith("34")
            || number.StartsWith("37"))
            return this;

        if (next != null)
            return next.GetCardType(number);

        return new UnknownType();
    }

    public override string ToString()
    {
        return "American Express";
    }
}