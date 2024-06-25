using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Core.Features.Students.Queries.Responses;
using SchoolManagment.Data.Entities;
using SchoolManagment.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Features.Students.Queries.Handler
{
	// GetStudentsQuery =>  request  , List<Student> =>  response type
	// Handle All Student's Requests
	// Many Request Handled By One Handler
	public class StudentQueryHandler : ResponseHandler,
		IRequestHandler<GetStudentsQuery, Response<List<GetStudentsResponse>>>,
		IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>
	{

		#region Fields
		private readonly IStudentService studentService;
		private readonly IMapper mapper;

		#endregion

		#region Constructor
		public StudentQueryHandler(IStudentService studentService , IMapper mapper)
		{
			this.studentService = studentService;
			this.mapper = mapper;
		}
		#endregion

		#region Handler Function

		// methods invoked to handle the request
		public async Task<Response<List<GetStudentsResponse>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
		{
			var students = await studentService.GetStudentsAsync();
			var mappedStudents = mapper.Map<List<GetStudentsResponse>>(students);	

			return Success(mappedStudents);
		}

		public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
		{
			var student = await studentService.GetStudentByIdAsync(request.Id);
			
			if (student == null)
				return NotFound<GetSingleStudentResponse>("Student Not Found");

			var mappedStudent = mapper.Map<GetSingleStudentResponse>(student);

			return Success(mappedStudent);
		}
		#endregion

	}
}
