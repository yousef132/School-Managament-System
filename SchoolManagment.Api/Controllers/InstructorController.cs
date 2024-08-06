using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Instructor.Commands.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagment.Api.Controllers
{

    public class InstructorController : AppControllerBase
    {
        private readonly IMediator mediator;

        public InstructorController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost(Router.Instructor.Create)]
        public async Task<IActionResult> GetDepartmentById([FromForm] AddInstructorCommand command)
        => NewResult(await mediator.Send(command));

    }
}
