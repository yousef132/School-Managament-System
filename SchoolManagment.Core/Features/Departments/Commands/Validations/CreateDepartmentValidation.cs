using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Departments.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Departments.Commands.Validations
{
    public class CreateDepartmentValidation : AbstractValidator<CreateDepartmentCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IInstructorService instructorService;
        private readonly IDepartmentService departmentService;
        #endregion


        #region Constructors
        public CreateDepartmentValidation(IStringLocalizer<SharedResource> localizer,
                                          IInstructorService instructorService,
                                          IDepartmentService departmentService)
        {
            _localizer = localizer;
            this.instructorService = instructorService;
            this.departmentService = departmentService;
            ApplyValidationsRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Actions
        private void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);

            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthIs100]);

        }
        private void ApplyCustomValidationRules()
        {
            When(x => x.InsId.HasValue, () =>
            {
                RuleFor(x => x.InsId)
                    .MustAsync(async (insId, cancellation) =>
                    {
                        var instructor = await instructorService.GetInstructorByIdAsync(insId.Value);
                        return instructor != null;
                    })
                    .WithMessage(_localizer[SharedResourcesKeys.NotFound])
                    .MustAsync(async (insId, cancellation) =>
                    {
                        return !await departmentService.IsInstructorAManager(insId.Value);
                    })
                    .WithMessage(_localizer[SharedResourcesKeys.InstructorIsAlreadyManager]);
            });
        }



        #endregion
    }
}
