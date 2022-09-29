using System.Text.RegularExpressions;
using Arvato.Paynext.CreditCards;
using Arvato.Paynext.Providers;
using FluentValidation;

namespace Arvato.Paynext.Validation;

public class CreditCardValidator : AbstractValidator<CreditCard>
{
    public CreditCardValidator(IDateTimeProvider dateTimeProvider)
    {
        RuleFor(x => x.Owner)
            .NotEmpty().WithMessage("Card owner field is required.");
        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("Card number field is required");
        RuleFor(x => x.Cvc)
            .NotEmpty().WithMessage("Card CVC field is required.");
        RuleFor(x => x.IssueDate)
            .NotEmpty().WithMessage("Card issue date field is required.");

        RuleFor(x => x.Owner)
            .Matches("^[A-Za-z\\s]*$").WithMessage("Card owner is invalid.");
        RuleFor(x => x.Cvc)
            .Matches("^[0-9]{3,4}$").WithMessage("Card CVC is invalid.");
        RuleFor(x => x.Number)
            .Custom((number, context) =>
            {
                if (!CardNumberValidator.IsValid(number))
                    context.AddFailure("Card number is invalid.");
            });
        RuleFor(x => x.IssueDate)
            .Custom((issueDate, context) =>
            {
                var isValid = new CardIssueDateValidator(dateTimeProvider).IsValid(issueDate);
                if (!isValid)
                    context.AddFailure("Card issue date is invalid.");
            });
        RuleFor(x => x)
            .Custom((card, context) =>
            {
                var message = $"CVC is invalid for {card.CardType} card type.";
                if (card.Cvc.Length == 3
                    && card.CardType is AmericanExpress)
                    context.AddFailure(message);

                if (card.Cvc.Length == 4
                    && card.CardType is not AmericanExpress)
                    context.AddFailure(message);
            });
    }
}