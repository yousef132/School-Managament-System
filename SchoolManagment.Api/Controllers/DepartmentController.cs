using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Departments.Queries.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagment.Api.Controllers
{
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
            => NewResult(await mediator.Send(new GetDepartmentByIdQuery(id)));


        [HttpGet(Router.DepartmentRouting.DepartmentStudentCount)]
        public async Task<IActionResult> DepartmentStudentCount()
         => NewResult(await mediator.Send(new GetDepartmentStudentCountListQuery()));
        [HttpGet(Router.DepartmentRouting.DepartmentStudentCountById)]
        public async Task<IActionResult> DepartmentStudentCountById([FromRoute] int id)
         => NewResult(await mediator.Send(new GetDepartmentStudentCountQuery(id)));

    }
}
