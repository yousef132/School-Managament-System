using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Students.Commands.Validations
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService studentService;
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IDepartmentService departmentService;

        #endregion
        #region Constructor
        public AddStudentCommandValidator(IStudentService studentService,
                                          IStringLocalizer<SharedResource> localizer,
                                          IDepartmentService departmentService)
        {
            ApplyValidationsRules();
            this.studentService = studentService;
            this.localizer = localizer;
            this.departmentService = departmentService;
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {

            //////TODO : Fluent Validation Exception
            ///
            RuleFor(st => st.NameEn)
                .NotNull().WithMessage("Temp")
                .NotEmpty().WithMessage("Temp")
                .MaximumLength(200);

            //////TODO : Fluent Validation Exception
            RuleFor(st => st.NameAr)
                .NotNull().WithMessage("Temp")
                .NotEmpty().WithMessage("Temp")
                .MaximumLength(200);

            RuleFor(st => st.Address)
                .NotEmpty().WithMessage("Temp")
                .NotNull().WithMessage("Temp")
                .MaximumLength(200);

            RuleFor(st => st.DepartmentId)
                .NotEmpty().WithMessage("Temp")
                .NotNull().WithMessage("Temp");
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(st => st.NameEn)
                // ok if true , error if false 
                .MustAsync(async (key, CancellationToken) => !await studentService.IsNameExist(key))
                .WithMessage("Name is Exist");
            RuleFor(st => st.NameAr)
                // ok if true , error if false 
                .MustAsync(async (key, CancellationToken) => !await studentService.IsNameExist(key))
                .WithMessage("Name is Exist");

            When(p => p?.DepartmentId != null, () =>
            {
                RuleFor(st => st.DepartmentId)
                    .MustAsync(async (key, CancellationToken) => await departmentService.IsDepartmentIdExist(key))
                    .WithMessage(localizer[SharedResourcesKeys.NotFound]);
            });
        }

        #endregion
    }
}
