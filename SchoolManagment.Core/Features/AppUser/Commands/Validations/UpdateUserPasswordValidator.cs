using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.AppUser.Commands.Models;
using SchoolManagment.Data.Resources;

namespace SchoolManagment.Core.Features.AppUser.Commands.Validations
{
    public class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _localizer;
        #endregion

        #region Constructors
        public UpdateUserPasswordValidator(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
            //ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        private void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);


            RuleFor(x => x.CurrentPassword)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.NewPassword)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                  .Must((model, newPassword) => newPassword != model.CurrentPassword)
            .WithMessage(_localizer[SharedResourcesKeys.NewPasswordCannotMatchCurrentPassword]);


            RuleFor(x => x.ConfirmNewPassword)
                    .Equal(x => x.NewPassword)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        #endregion
    }
}
