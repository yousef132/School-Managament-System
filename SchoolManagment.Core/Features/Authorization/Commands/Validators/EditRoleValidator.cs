using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Authorization.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Authorization.Commands.Validators
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IAuthorizationService authorizationService;
        #endregion

        #region Constructors
        public EditRoleValidator(IStringLocalizer<SharedResource> localizer, IAuthorizationService authorizationService)
        {
            _localizer = localizer;
            this.authorizationService = authorizationService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        private void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);

            RuleFor(x => x.Id)
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);


        }
        private void ApplyCustomValidationsRules()
        {

        }



        #endregion
    }
}
