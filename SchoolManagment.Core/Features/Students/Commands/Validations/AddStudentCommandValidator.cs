using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;


namespace SchoolManagment.Core.Features.Students.Commands.Validations
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Constructors
        public AddStudentCommandValidator(IStudentService studentService,
                                   IStringLocalizer<SharedResource> localizer,
                                   IDepartmentService departmentService)
        {
            _studentService = studentService;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _departmentService = departmentService;
        }
        #endregion

        #region Actions
        private void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);

            RuleFor(x => x.DepartmentId)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        private void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameArExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameEnExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.DepartmentId)
           .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExist(Key))
           .WithMessage(_localizer[SharedResourcesKeys.DepartmentIsNotExist]);

        }

        #endregion
    }
}
