using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.AppUser.Commands.Models;
using SchoolManagment.Data.Resources;

namespace SchoolManagment.Core.Features.AppUser.Commands.Validations
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _localizer;
        #endregion

        #region Constructors
        public AddUserValidator(IStringLocalizer<SharedResource> localizer)
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

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordDisMatch])
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

        //private void ApplyCustomValidationsRules()
        //{
        //    RuleFor(x => x.NameAr)
        //        .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameArExist(Key))
        //        .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        //    RuleFor(x => x.NameEn)
        //       .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameEnExist(Key))
        //       .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

        //    RuleFor(x => x.DepartmentId)
        //   .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExist(Key))
        //   .WithMessage(_localizer[SharedResourcesKeys.DepartmentIsNotExist]);

        //}

        #endregion
    }
}
