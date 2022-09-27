using Arvato.Paynext.Application;
using FluentValidation;

namespace Arvato.Paynext.WebApi.Validation;

public class CreditCardInputValidator : AbstractValidator<CreditCardInput>
{
    public CreditCardInputValidator()
    {
        RuleFor(x => x.Owner)
            .NotEmpty().WithMessage("Card owner field is required.");
        RuleFor(x => x.Number)
            .NotEmpty().WithMessage("Card number field is required");
        RuleFor(x => x.Cvc)
            .NotEmpty().WithMessage("Card CVC field is required.");
        RuleFor(x => x.IssueDate)
            .NotEmpty().WithMessage("Card issue date field is required.");
    }
}