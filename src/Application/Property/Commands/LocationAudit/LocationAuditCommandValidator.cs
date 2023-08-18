using FluentValidation;

namespace PropertyCore.Application.Property.Commands.LocationAudit
{
    /// <summary>
    /// Implementation of <see cref="AbstractValidator{T}"/> that validates inputs in a <see cref="LocationAuditCommand"/>
    /// </summary>
    public class LocationAuditCommandValidator : AbstractValidator<LocationAuditCommand>
    {
        /// <summary>
        /// Creates a new instance of the validator.
        /// </summary>
        public LocationAuditCommandValidator() 
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
