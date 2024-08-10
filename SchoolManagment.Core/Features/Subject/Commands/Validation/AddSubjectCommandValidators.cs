using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Subject.Commands.Models;
using SchoolManagment.Data.Resources;

namespace SchoolManagment.Core.Features.Subject.Commands.Validation
{
    public class AddSubjectCommandValidators : AbstractValidator<AddSubjectCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _localizer;
        #endregion

        #region Constructors
        public AddSubjectCommandValidators(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
        }
        #endregion

        #region Actions
        private void ApplyValidationsRules()
        {
            RuleFor(x => x.SubjectNameAr)
                           .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                           .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                           .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);

            RuleFor(x => x.SubjectNameEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);

            RuleFor(x => x.Period)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        #endregion
    }
}
