using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.AppUser.Commands.Models;
using SchoolManagment.Data.Resources;

namespace SchoolManagment.Core.Features.AppUser.Commands.Validations
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResource> _localizer;
        #endregion

        #region Constructors
        public UpdateUserValidator(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
            //ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        private void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);


            RuleFor(x => x.FullName)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.UserName)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        #endregion

    }

}

