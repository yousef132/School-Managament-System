using AutoMapper;
using MediatR;
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
	public class StudentHandler : IRequestHandler<GetStudentsQuery, List<GetStudentsResponse>>
	{

		#region Fields
		private readonly IStudentService studentService;
		private readonly IMapper mapper;

		#endregion

		#region Constructor
		public StudentHandler(IStudentService studentService , IMapper mapper)
		{
			this.studentService = studentService;
			this.mapper = mapper;
		}
		#endregion

		#region Handler Function

		// method invoked to handle the request
		public async Task<List<GetStudentsResponse>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
		{
			var students = await studentService.GetStudentsAsync();
			var mappedStudents = mapper.Map<List<GetStudentsResponse>>(students);	
			return mappedStudents;
		}
		#endregion

	}
}
