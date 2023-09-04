using FluentValidation;

namespace PropertyCore.Application.Property.Queries.GetAuditFile
{
    internal class GetAuditFileQueryValidator : AbstractValidator<GetAuditFileQuery>
    {
        /// <summary>
        /// Creates a new instance of the validator.
        /// </summary>
        public GetAuditFileQueryValidator()
        {
            RuleFor(x => x.LocationId)
                .NotEmpty()
                    .WithMessage("Please select a Location.");
            RuleFor(x => x.BarCodes)
                .NotEmpty()
                    .WithMessage("Please provide at least 1 barcode.");
        }
    }
}
