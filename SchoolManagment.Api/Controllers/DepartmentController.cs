using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Departments.Commands.Models;
using SchoolManagment.Core.Features.Departments.Queries.Models;
using SchoolManagment.Data.AppMetaData;
using SchoolManagment.Data.Helper;

namespace SchoolManagment.Api.Controllers
{

    [Authorize(Roles = Roles.Admin)]

    public class DepartmentController : AppControllerBase
    {


        [HttpGet(Router.Department.GetDepartmentsList)]
        public async Task<IActionResult> GetDepartmentsList()
            => NewResult(await mediator.Send(new GetAllDepartmentsQuery()));

        [HttpGet(Router.Department.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
            => NewResult(await mediator.Send(new GetDepartmentByIdQuery(id)));


        [HttpGet(Router.Department.DepartmentStudentCount)]
        public async Task<IActionResult> DepartmentStudentCount()
         => NewResult(await mediator.Send(new GetDepartmentStudentCountListQuery()));

        [HttpGet(Router.Department.DepartmentStudentCountById)]
        public async Task<IActionResult> DepartmentStudentCountById([FromRoute] int id)
         => NewResult(await mediator.Send(new GetDepartmentStudentCountQuery(id)));


        [HttpGet(Router.Department.GetTop3InstructorByDepartment)]
        public async Task<IActionResult> GetTop3InstructorByDepartment()
         => NewResult(await mediator.Send(new GetTop3InstructorSalariesByDeptQuery()));


        [HttpPost(Router.Department.Create)]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
         => NewResult(await mediator.Send(command));

        [HttpPut(Router.Department.Update)]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentCommand command)
         => NewResult(await mediator.Send(command));

        [HttpDelete(Router.Department.Delete)]
        public async Task<IActionResult> Delete(int id)
         => NewResult(await mediator.Send(new DeleteDepartmentCommand(id)));



    }
}
