using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IMediator mediator;
		public StudentController(IMediator mediator)
        {
			this.mediator = mediator;
		}
		[HttpGet]

        public async Task<ActionResult<List<Student>>> GetAllStudents()
		{

			// send request of type GetStudentQuery and return response of type List<Student>
			var response = await mediator.Send(new GetStudentsQuery());

			return Ok(response);
		}

	}
}
