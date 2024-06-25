using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Data.AppMetaData;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Api.Controllers
{
	[ApiController]
	public class StudentController : AppControllerBase
	{


        [HttpGet(Router.StudentRouting.List)]

        public async Task<ActionResult<List<Student>>> GetAllStudents()
		{

			// send request of type GetStudentQuery and return response of type List<Student>
			var response = await mediator.Send(new GetStudentsQuery());
			return NewResult(response);
			return Ok(response);
		}
		[HttpGet(Router.StudentRouting.GetById)]

        public async Task<ActionResult<List<Student>>> GetStudentById([FromRoute]int id )
		{
			return NewResult(await mediator.Send(new GetStudentByIdQuery(id)));
		}

		[HttpPost(Router.StudentRouting.Create)]

		public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
		{
			return NewResult(await mediator.Send(command));
		}

	}
}
