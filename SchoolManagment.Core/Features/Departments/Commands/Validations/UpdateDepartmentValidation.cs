using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Departments.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Departments.Commands.Validations
{
    public class UpdateDepartmentValidation : AbstractValidator<UpdateDepartmentCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IDepartmentService departmentService;
        private readonly IInstructorService instructorService;
        #endregion

        #region Constructors
        public UpdateDepartmentValidation(IStringLocalizer<SharedResource> localizer,
                                          IDepartmentService departmentService,
                                          IInstructorService instructorService)
        {
            _localizer = localizer;
            this.departmentService = departmentService;
            this.instructorService = instructorService;
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

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        private void ApplyCustomValidationRules()
        {
            When(x => x.InsId.HasValue, () =>
            {
                RuleFor(x => x)
                .MustAsync(async (request, cancellation) =>
                {
                    var instructor = await instructorService.GetInstructorByIdAsync(request.InsId.Value);
                    return instructor != null;
                })
                .WithMessage(_localizer[SharedResourcesKeys.NotFound])
                .MustAsync(async (request, cancellation) =>
                {
                    return !await departmentService.IsInstructorAManagerForOtherDepartment(request.InsId.Value, request.DepartmentId);
                })
                .WithMessage(_localizer[SharedResourcesKeys.InstructorIsAlreadyManager]);
            });
        }


        #endregion
    }


}
