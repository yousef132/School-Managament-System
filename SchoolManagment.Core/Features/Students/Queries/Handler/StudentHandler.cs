using MediatR;
using SchoolManagment.Core.Features.Students.Queries.Models;
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
	public class StudentHandler : IRequestHandler<GetStudentsQuery, List<Student>>
	{

		#region Fields
		private readonly IStudentService studentService;

		#endregion
		#region Constructor
		public StudentHandler(IStudentService studentService)
		{
			this.studentService = studentService;
		}
		#endregion
		#region Handler Function

		// method invoked to handle the request
		public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
		=> await studentService.GetStudentsAsync();
		 
		#endregion

	}
}
