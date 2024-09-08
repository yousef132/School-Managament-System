using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Subject.Commands.Models;
using SchoolManagment.Core.Features.Subject.Queries.Models;
using SchoolManagment.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagment.Api.Controllers
{

    public class SubjectController : AppControllerBase
    {

        [HttpPost(Router.SubjectRouting.Create)]
        [SwaggerOperation(Summary = "إضافة مادة")]
        public async Task<IActionResult> Create([FromBody] AddSubjectCommand command)
            => NewResult(await mediator.Send(command));


        [HttpPost(Router.SubjectRouting.AddToDepartment)]
        [SwaggerOperation(Summary = "إضافة مادة إلى قسم")]
        public async Task<IActionResult> AddToDepartment([FromForm] AddSubjectToDepartmentCommand command)
            => NewResult(await mediator.Send(command));


        [HttpPost(Router.SubjectRouting.AddInstructor)]
        [SwaggerOperation(Summary = "إضافة مدرب إلى مادة")]

        public async Task<IActionResult> AddInstructorToSubject([FromForm] AddInstructorToSubjectCommand command)
            => NewResult(await mediator.Send(command));


        [HttpDelete(Router.SubjectRouting.Delete)]
        [SwaggerOperation(Summary = "حذف مادة")]

        public async Task<IActionResult> DeleteSubject([FromRoute] int id)
            => NewResult(await mediator.Send(new DeleteSubjectCommand(id)));


        [HttpPut(Router.SubjectRouting.Edit)]
        [SwaggerOperation(Summary = "تحديث معلومات المادة")]

        public async Task<IActionResult> EditSubject([FromBody] EditSubjectCommand command)
            => NewResult(await mediator.Send(command));


        [HttpGet(Router.SubjectRouting.GetSubjectWithDepartments)]
        [SwaggerOperation(Summary = "الحصول على المواد مع الأقسام المرتبطة بها")]

        public async Task<IActionResult> GetSubjectWithDepartments()
            => NewResult(await mediator.Send(new GetSubjectWithDepartmentsQuery()));


        [HttpGet(Router.SubjectRouting.GetSubjectsStudentsCount)]
        [SwaggerOperation(Summary = "الحصول على عدد الطلاب لكل مادة")]

        public async Task<IActionResult> GetSubjectsStudentsCount()
            => NewResult(await mediator.Send(new GetNumberOfStudentsForSubjectsQuery()));


        [HttpGet(Router.SubjectRouting.GetTopStudentInEachSubject)]
        [SwaggerOperation(Summary = "الحصول على الطالب المتفوق في كل مادة")]

        public async Task<IActionResult> GetTopStudentInEachSubject()
            => NewResult(await mediator.Send(new GetTopStudentInEachSubjectQuery()));

        [HttpGet(Router.SubjectRouting.GetById)]
        [SwaggerOperation(Summary = "الحصول على الماده بواسطه المعرف")]

        public async Task<IActionResult> GetSubjectById(int id)
            => NewResult(await mediator.Send(new GetSubjectByIdQuery(id)));


    }
}
