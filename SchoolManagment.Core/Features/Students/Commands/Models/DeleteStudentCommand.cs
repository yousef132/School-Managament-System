using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Students.Commands.Models
{
	public class DeleteStudentCommand : IRequest<Response<string>>
	{
		public DeleteStudentCommand(int id)
		{
			Id = id;
		}
		public int Id { get; set; }
	}
}
