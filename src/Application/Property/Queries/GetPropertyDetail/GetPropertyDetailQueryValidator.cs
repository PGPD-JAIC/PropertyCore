using FluentValidation;

namespace PropertyCore.Application.Property.Queries.GetPropertyDetail
{
    /// <summary>
    /// Implementation of <seealso cref="AbstractValidator{T}"/> used to validate data in the <see cref="GetPropertyDetailQuery"></see>
    /// </summary>
    public class GetPropertyDetailQueryValidator : AbstractValidator<GetPropertyDetailQuery>
    {
        /// <summary>
        /// Creates a new instance of the validator.
        /// </summary>
        public GetPropertyDetailQueryValidator() 
        {
            RuleFor(x => x.InstanceId)
                .NotEmpty()
                .WithMessage("InstanceId is required.");
            RuleFor(x => x.SeqNo1)
                .GreaterThan(-1)
                .WithMessage("SeqNo1 is required.");
        }
    }
}
