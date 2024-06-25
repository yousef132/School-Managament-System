using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Data.Entities;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Students.Commands.Handler
{
	public class StudentCommandHandler : ResponseHandler, 
		IRequestHandler<AddStudentCommand,Response<string>>
	{
		#region Fields
		private readonly IStudentService studentService;
		private readonly IMapper mapper;
		#endregion

		#region Constructor
		public StudentCommandHandler(IStudentService studentService , IMapper mapper)
        {
			this.studentService = studentService;
			this.mapper = mapper;
		}
		#endregion


		#region Fuction
		public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
		{
			var student = mapper.Map<Student>(request);

			string result = await studentService.AddAsync(student);

			if (result == "Exist")
				return UnprocessableEntity<string>($"{request.Name} Exists");

			else if (result == "Success")
				return Created<string>();

			else return BadRequest<string>();
		}
		#endregion

	}
}
