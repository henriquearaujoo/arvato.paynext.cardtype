using Arvato.Paynext.Validation;

namespace Arvato.Paynext.Tests;

public class CreditCardIssueDateTest
{
    [Theory]
    [InlineData("", false)]
    [InlineData("1", false)]
    [InlineData("2024", false)]
    [InlineData("012024", false)]
    [InlineData("1/24", false)]
    [InlineData("1/2024", false)]
    [InlineData("08/2028", true)]
    [InlineData("01/2024", true)]
    [InlineData("06/2025", true)]
    [InlineData("05/2027", true)]
    public void ShouldValidateGivenACardIssueDate(string issueDate, bool expected)
    {
        var result = CardIssueDateValidator.IsValid(issueDate);
        Assert.Equal(expected, result);
    }
}