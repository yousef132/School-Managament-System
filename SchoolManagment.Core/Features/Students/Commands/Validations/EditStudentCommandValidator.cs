using FluentValidation;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Students.Commands.Validations
{
	public class EditStudentCommandValidator : AbstractValidator<EditStudentCommand>
	{
		#region Fields
		private readonly IStudentService studentService;

		#endregion
		#region Constructor
		public EditStudentCommandValidator(IStudentService studentService)
		{
			ApplyValidationsRules();
			this.studentService = studentService;
			ApplyCustomValidationsRules();
		}
		#endregion

		#region Actions
		public void ApplyValidationsRules()
		{
			RuleFor(st => st.Name)
				.NotEmpty().WithMessage("Should Have A Name")
				.NotNull().WithMessage("Should Not Be Null")
				.MaximumLength(200);

			RuleFor(st => st.Address)
				.NotEmpty().WithMessage("Should Have an {PropertyName}")
				.NotNull().WithMessage("{PropertyName }Should Not Be Null")
				.MaximumLength(200);
		}
		public void ApplyCustomValidationsRules()
		{
			RuleFor(st => st.Name)
				// ok if true , error if false 
				.MustAsync(async (model, key, CancellationToken) => !await studentService.IsNameExistExcludeItself(key, model.Id))
				.WithMessage("Name is Exist");
		}

		#endregion
	}
}
