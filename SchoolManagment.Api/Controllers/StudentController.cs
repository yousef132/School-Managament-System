using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Core.Filters;
using SchoolManagment.Data.AppMetaData;
using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Helper;

namespace SchoolManagment.Api.Controllers
{
    [Authorize(Roles = Roles.Admin)]

    public class StudentController : AppControllerBase
    {

        [HttpGet(Router.StudentRouting.List)]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
            => NewResult(await mediator.Send(new GetStudentsQuery()));

        [HttpGet(Router.StudentRouting.GetById)]
        [Auth]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
            => NewResult(await mediator.Send(new GetStudentByIdQuery(id)));


        [HttpPost(Router.StudentRouting.Create)]
        [Authorize(Policy = Policies.CreateStudent)]
        public async Task<IActionResult> Create([FromBody] AddStudentCommand command)
         => NewResult(await mediator.Send(command));


        [HttpPut(Router.StudentRouting.Edit)]
        [Authorize(Policy = Policies.EditStudent)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
            => NewResult(await mediator.Send(command));

        [HttpDelete(Router.StudentRouting.Delete)]
        [Authorize(Policy = Policies.DeleteStudent)]
        public async Task<IActionResult> Delete([FromRoute] int id)
            => NewResult(await mediator.Send(new DeleteStudentCommand(id)));

        [HttpGet(Router.StudentRouting.Pagination)]
        public async Task<IActionResult> GetAllStudentsWithPagination([FromQuery] GetStudentsWithPaginationQuery specs)
            => NewResult(await mediator.Send(specs));
    }
}
