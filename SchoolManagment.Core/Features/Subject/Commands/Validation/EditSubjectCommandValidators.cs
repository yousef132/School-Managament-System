using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Subject.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Subject.Commands.Validation
{
    public class EditSubjectCommandValidators : AbstractValidator<EditSubjectCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly ISubjectService subjectService;
        #endregion

        #region Constructors
        public EditSubjectCommandValidators(IStringLocalizer<SharedResource> localizer, ISubjectService subjectService)
        {
            _localizer = localizer;
            this.subjectService = subjectService;
            ApplyValidationsRules();
        }
        #endregion

        #region Actions
        private void ApplyValidationsRules()
        {

            RuleFor(x => x.SubjectId)
                           .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                           .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

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
