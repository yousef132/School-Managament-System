using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Instructor.Commands.Models;
using SchoolManagment.Data.AppMetaData;
using SchoolManagment.Data.Helper;

namespace SchoolManagment.Api.Controllers
{
    [Authorize(Roles = Roles.Admin)]

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
