using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Departments.Commands.Models;
using SchoolManagment.Core.Features.Departments.Queries.Models;
using SchoolManagment.Data.AppMetaData;
using SchoolManagment.Data.Helper;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagment.Api.Controllers
{

    [Authorize(Roles = Roles.Admin)]

    public class DepartmentController : AppControllerBase
    {

        [HttpGet(Router.Department.GetDepartmentsList)]
        [SwaggerOperation(Summary = "الحصول على قائمة الأقسام")]

        public async Task<IActionResult> GetDepartmentsList()
            => NewResult(await mediator.Send(new GetAllDepartmentsQuery()));


        [HttpGet(Router.Department.GetById)]
        [SwaggerOperation(Summary = "الحصول على قسم بواسطة المعرف")]

        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
            => NewResult(await mediator.Send(new GetDepartmentByIdQuery(id)));


        [HttpGet(Router.Department.DepartmentStudentCount)]
        [SwaggerOperation(Summary = "عدد الطلاب في كل قسم")]

        public async Task<IActionResult> DepartmentStudentCount()
            => NewResult(await mediator.Send(new GetDepartmentStudentCountListQuery()));


        [HttpGet(Router.Department.DepartmentStudentCountById)]
        [SwaggerOperation(Summary = "عدد الطلاب في قسم معين بواسطة المعرف")]

        public async Task<IActionResult> DepartmentStudentCountById([FromRoute] int id)
            => NewResult(await mediator.Send(new GetDepartmentStudentCountQuery(id)));


        [HttpGet(Router.Department.GetTop3InstructorByDepartment)]
        [SwaggerOperation(Summary = "الحصول على أعلى ثلاثة رواتب مدربين حسب القسم")]

        public async Task<IActionResult> GetTop3InstructorByDepartment()
            => NewResult(await mediator.Send(new GetTop3InstructorSalariesByDeptQuery()));


        [HttpPost(Router.Department.Create)]
        [SwaggerOperation(Summary = "إنشاء قسم")]

        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
            => NewResult(await mediator.Send(command));


        [HttpPut(Router.Department.Update)]
        [SwaggerOperation(Summary = "تحديث معلومات القسم")]

        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentCommand command)
            => NewResult(await mediator.Send(command));


        [HttpDelete(Router.Department.Delete)]
        [SwaggerOperation(Summary = "حذف قسم")]

        public async Task<IActionResult> Delete(int id)
            => NewResult(await mediator.Send(new DeleteDepartmentCommand(id)));

    }
}
