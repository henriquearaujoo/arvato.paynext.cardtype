using Arvato.Paynext.Validation;

namespace Arvato.Paynext.Tests;

public class CreditCardNumberTest
{
    [Theory]
    [InlineData("", false)]
    [InlineData("1", false)]
    [InlineData("4108636038426649", false)]
    [InlineData("4485444249386075", true)]
    [InlineData("5180731692394449", true)]
    [InlineData("348102426825324", true)]
    [InlineData("3481024268253240", false)]
    public void IsValid_ShouldValidateCardNumber_WhenGivenANumber(string number, bool expected)
    {
        var result = CardNumberValidator.IsValid(number);
        Assert.Equal(expected, result);
    }
}