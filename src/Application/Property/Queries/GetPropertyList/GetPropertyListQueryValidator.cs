using FluentValidation;
using System.Collections.Generic;

namespace PropertyCore.Application.Property.Queries.GetPropertyList
{
    /// <summary>
    /// Implementation of <seealso cref="AbstractValidator{T}"/> used to validate data in the <see cref="GetPropertyListQuery"></see>
    /// </summary>
    public class GetPropertyListQueryValidator : AbstractValidator<GetPropertyListQuery>
    {
        private readonly List<string> _validSortValues;
        /// <summary>
        /// Creates a new instance of the validator.
        /// </summary>
        public GetPropertyListQueryValidator() 
        {
            _validSortValues = new List<string>()
            { 
                "",
                "dateObtained_asc",
                "caseNumber_desc",
                "caseNumber",
                "propertySheet_desc",
                "propertySheet"
            };
            RuleFor(x => x.BarCodeSearch)
                .MaximumLength(100)
                .WithMessage("Bar Code search has a 100 character limit.");
            RuleFor(x => x.CaseNumberSearch)
                .MaximumLength(100)
                .WithMessage("Case Number search has a 100 character limit.");
            RuleFor(x => x.PropertySheetSearch)
                .MaximumLength(100)
                .WithMessage("Property Sheet search has a 100 character limit.");
            RuleFor(x => x.SortOrder)
                .Must(x => _validSortValues.Contains(x))
                .WithMessage("Must be a valid sorting value: " + string.Join(",", _validSortValues));
            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("Page Size must be greater than 0.");
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("Page Number must be greater than 0.");
        }
    }
}
