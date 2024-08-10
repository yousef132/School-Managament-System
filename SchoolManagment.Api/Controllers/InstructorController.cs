using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Instructor.Commands.Models;
using SchoolManagment.Core.Features.Instructor.Queries.Models;
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
        public async Task<IActionResult> CreateInstructor([FromForm] AddInstructorCommand command)
        => NewResult(await mediator.Send(command));


        [HttpGet(Router.Instructor.GetAllInstructors)]
        public async Task<IActionResult> GetAllInstructors()
        => NewResult(await mediator.Send(new GetAllInstructorsQuery()));

        [HttpPost(Router.Instructor.GetById)]
        public async Task<IActionResult> GetInstructorById([FromRoute] int id)
        => NewResult(await mediator.Send(new GetInstructorByIdQuery(id)));

    }
}
