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

		#endregion
		#region Constructor
		public AddStudentCommandValidator(IStudentService studentService, IStringLocalizer<SharedResource> localizer)
		{
			ApplyValidationsRules();
			this.studentService = studentService;
			this.localizer = localizer;
			ApplyCustomValidationsRules();
		}
		#endregion

		#region Actions
		public void ApplyValidationsRules()
		{

			//////TODO : Fluent Validation Exception
			RuleFor(st => st.NameEn)
				.NotEmpty().WithMessage(localizer[SharedResourcesKeys.Required])
				.NotNull().WithMessage(localizer[SharedResourcesKeys.Required])
				.MaximumLength(200);
			//////TODO : Fluent Validation Exception
			RuleFor(st => st.NameAr)
				.NotEmpty().WithMessage(localizer[SharedResourcesKeys.Required])
				.NotNull().WithMessage(localizer[SharedResourcesKeys.Required])
				.MaximumLength(200);

			RuleFor(st => st.Address)
				.NotEmpty().WithMessage(localizer[SharedResourcesKeys.Required])
				.NotNull().WithMessage(localizer[SharedResourcesKeys.Required])
				.MaximumLength(200);
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
		}

		#endregion
	}
}
