using FluentValidation;
using MediatR;

namespace SchoolManagment.Core.Bahaviors
{
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			this.validators = validators;
		}
		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			// check for any validations
			if (validators.Any())
			{
				// for example [AddStudentCommand]
				var context = new ValidationContext<TRequest>(request);
				var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
				var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

				if (failures.Count() != 0)
				{
					string message = failures.Select(x => $" {x.ErrorMessage}").FirstOrDefault();
					throw new ValidationException(message);
				}
			}
			return await next();
		}
	}
}
