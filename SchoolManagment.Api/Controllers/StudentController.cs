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
		}

		[HttpGet(Router.StudentRouting.GetById)]
		public async Task<ActionResult<List<Student>>> GetStudentById([FromRoute] int id)
		{
			return NewResult(await mediator.Send(new GetStudentByIdQuery(id)));
		}

		[HttpPost(Router.StudentRouting.Create)]
		public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
		{
			var response = await mediator.Send(command);
			return NewResult(response);
		}

		[HttpPut(Router.StudentRouting.Edit)]
		public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
		{
			var response = await mediator.Send(command);
			return NewResult(response);
		}

		[HttpDelete(Router.StudentRouting.Delete)]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var response = await mediator.Send(new DeleteStudentCommand(id));
			return NewResult(response);
		}
		[HttpGet(Router.StudentRouting.Pagenation)]
		public async Task<IActionResult> GetAllStudentsWithPagenation([FromQuery] GetStudentsWithPaginationQuery specs)
		{
			var response = await mediator.Send(specs);
			return NewResult(response);
		}
	}
}
