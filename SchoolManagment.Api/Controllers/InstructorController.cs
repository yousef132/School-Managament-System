using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Instructor.Commands.Models;
using SchoolManagment.Core.Features.Instructor.Queries.Models;
using SchoolManagment.Data.AppMetaData;
using SchoolManagment.Data.Helper;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagment.Api.Controllers
{
    [Authorize(Roles = Roles.Admin)]

    public class InstructorController : AppControllerBase
    {

        [HttpPost(Router.Instructor.Create)]
        [SwaggerOperation(Summary = "إضافة مدرب")]

        public async Task<IActionResult> CreateInstructor([FromForm] AddInstructorCommand command)
             => NewResult(await mediator.Send(command));


        [HttpGet(Router.Instructor.GetAllInstructors)]
        [SwaggerOperation(Summary = "الحصول على جميع المدربين")]

        public async Task<IActionResult> GetAllInstructors()
            => NewResult(await mediator.Send(new GetAllInstructorsQuery()));


        [HttpPost(Router.Instructor.GetById)]
        [SwaggerOperation(Summary = "الحصول على مدرب بواسطة المعرف")]

        public async Task<IActionResult> GetInstructorById([FromRoute] int id)
            => NewResult(await mediator.Send(new GetInstructorByIdQuery(id)));


    }
}
