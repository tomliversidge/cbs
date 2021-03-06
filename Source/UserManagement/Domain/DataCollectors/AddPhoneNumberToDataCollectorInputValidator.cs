using System.Linq;
using Concepts.DataCollectors;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class AddPhoneNumberToDataCollectorInputValidator : AbstractValidator<AddPhoneNumberToDataCollector>
    {
        public AddPhoneNumberToDataCollectorInputValidator()
        {
            RuleFor(_ => _.DataCollectorId)
                .NotEmpty().WithMessage("Data Collector Id must be set")
                .SetValidator(new DataCollectorIdValidator());

            RuleFor(_ => _.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required")
                .Must(_ => !_.Contains(" ")).WithMessage("Phone number is not valid");

        }
    }
}