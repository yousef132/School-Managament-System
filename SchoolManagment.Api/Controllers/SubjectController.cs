using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Subject.Commands.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagment.Api.Controllers
{

    public class SubjectController : AppControllerBase
    {
        private readonly IMediator mediator;

        public SubjectController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost(Router.Subject.Create)]
        public async Task<IActionResult> Create([FromBody] AddSubjectCommand command)
             => NewResult(await mediator.Send(command));


        [HttpPost(Router.Subject.AddToDepartment)]
        public async Task<IActionResult> AddToDepartment([FromForm] AddSubjectToDepartmentCommand command)
             => NewResult(await mediator.Send(command));


        [HttpPost(Router.Subject.AddInstructor)]
        public async Task<IActionResult> AddInstructorToSubject([FromForm] AddInstructorToSubjectCommand command)
             => NewResult(await mediator.Send(command));


        [HttpDelete(Router.Subject.Delete)]
        public async Task<IActionResult> DeleteSubject([FromRoute] int id)
             => NewResult(await mediator.Send(new DeleteSubjectCommand(id)));

        [HttpPut(Router.Subject.Edit)]
        public async Task<IActionResult> EditSubject([FromBody] EditSubjectCommand command)
             => NewResult(await mediator.Send(command));





    }
}
