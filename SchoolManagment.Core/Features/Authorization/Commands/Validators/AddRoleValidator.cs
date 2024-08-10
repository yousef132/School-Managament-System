using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Authorization.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Authorization.Commands.Validators
{
    public class AddRoleValidator : AbstractValidator<AddRoleCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IAuthorizationService authorizationService;
        #endregion

        #region Constructors
        public AddRoleValidator(IStringLocalizer<SharedResource> localizer, IAuthorizationService authorizationService)
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
            RuleFor(x => x.Role)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);


        }
        private void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Role)
               .MustAsync(async (Key, CancellationToken) => !await authorizationService.IsRoleExistsAsync(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }



        #endregion
    }
}
