using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Students.Commands.Validations
{
    public class EditStudentCommandValidator : AbstractValidator<EditStudentCommand>
    {


        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResource> _localizer;
        #endregion



        #region Constructors
        public EditStudentCommandValidator(IStudentService studentService,
                                   IStringLocalizer<SharedResource> localizer,
                                   IDepartmentService departmentService)
        {
            _studentService = studentService;
            _localizer = localizer;
            // assign value for the fields before calling validation methods 
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion


        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(st => st.NameEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);

            RuleFor(st => st.NameAr)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);

            RuleFor(st => st.Address)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(st => st.NameEn)
                // ok if true , error if false 
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameEnExistExcludeItself(key, model.Id))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(st => st.NameAr)
                // ok if true , error if false 
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameArExistExcludeItself(key, model.Id))
                 .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }

        #endregion
    }
}
