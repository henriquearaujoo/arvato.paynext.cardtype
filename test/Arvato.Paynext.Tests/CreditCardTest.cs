using Arvato.Paynext.CreditCards;
using Arvato.Paynext.Providers;
using Arvato.Paynext.Validation;

namespace Arvato.Paynext.Tests
{
    public class CreditCardTest
    {
        [Theory]
        [InlineData("VICTOR G MUNIZ", "370460574543771", "01/2024", "6161", "American Express")]
        [InlineData("VICTOR G MUNIZ", "4485091335938218", "09/2024", "805", "Visa")]
        [InlineData("VICTOR G MUNIZ", "5427623094110890", "06/2027", "760", "MasterCard")]
        [InlineData("VICTOR G MUNIZ", "3010685692012347", "03/2027", "848", "Unknown")]
        public void ShouldReturnTypeOfCard(
            string owner,
            string number,
            string issueDate,
            string cvc,
            string expected)
        {
            var creditCard = new CreditCard(
                new CardTypeProvider(),
                owner,
                number,
                issueDate,
                cvc);

            Assert.Equal(expected, creditCard.CardType.ToString());
        }
    }
}