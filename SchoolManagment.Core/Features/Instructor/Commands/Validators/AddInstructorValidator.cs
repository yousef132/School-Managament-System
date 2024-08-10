using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Instructor.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Instructor.Commands.Validators
{
    public class AddInstructorValidator : AbstractValidator<AddInstructorCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _instructorService;
        #endregion

        #region Constructors
        public AddInstructorValidator(IStringLocalizer<SharedResource> localizer,
                                      IDepartmentService departmentService,
                                      IInstructorService instructorService)
        {
            _localizer = localizer;
            _instructorService = instructorService;
            _departmentService = departmentService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.NameEn)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomValidationsRules()
        {

            RuleFor(x => x.NameEn)
                     .Must(NameEn => !_instructorService.IsNameEnExist(NameEn))
                     .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.NameAr)
                     .Must(NameAr => !_instructorService.IsNameArExist(NameAr))
                     .WithMessage(_localizer[SharedResourcesKeys.IsExist]);


            RuleFor(x => x.DepartmentId)
           .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExist(Key))
           .WithMessage(_localizer[SharedResourcesKeys.NotFound]);

        }

        #endregion
    }
}
