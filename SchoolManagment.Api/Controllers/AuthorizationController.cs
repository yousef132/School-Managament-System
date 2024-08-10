using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Authorization.Commands.Models;
using SchoolManagment.Core.Features.Authorization.Queries.Model;
using SchoolManagment.Data.AppMetaData;
using SchoolManagment.Data.Helper;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagment.Api.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AuthorizationController : AppControllerBase
    {
        private readonly IAuthorizationService authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        [HttpPost(Router.Authorization.AddRole)]
        [SwaggerOperation(summary: "اضافه صلاحيه")]

        public async Task<IActionResult> AddRole([FromQuery] string role)
           => NewResult(await mediator.Send(new AddRoleCommand(role)));


        [HttpPut(Router.Authorization.EditRole)]
        [SwaggerOperation(summary: "تعديل صلاحيه")]

        public async Task<IActionResult> EditRole([FromForm] EditRoleCommand command)
           => NewResult(await mediator.Send(command));

        [HttpGet(Router.Authorization.RolesList)]
        [SwaggerOperation(summary: "قائمه الصلاحيات")]

        public async Task<IActionResult> GetRolesList()
           => NewResult(await mediator.Send(new GetRolesListQuery()));

        [HttpGet(Router.Authorization.GetById)]
        [SwaggerOperation(summary: "الصلاحيه عن طريق ال ID", OperationId = "GetById")]
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
           => NewResult(await mediator.Send(new GetRoleByIdQuery(id)));


        [HttpDelete(Router.Authorization.DeleteRole)]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
             => NewResult(await mediator.Send(new DeleteRoleCommand(id)));



        [SwaggerOperation(Summary = " ادارة صلاحيات المستخدمين", OperationId = "ManageUserRoles")]
        [HttpGet(Router.Authorization.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] int userId)
        => NewResult(await mediator.Send(new ManageUserRolesQuery(userId)));


        [SwaggerOperation(Summary = " تعديل صلاحيات المستخدمين", OperationId = "UpdateUserRoles")]
        [HttpPut(Router.Authorization.UpdateUserRoles)]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand command)
        => NewResult(await mediator.Send(command));


        [SwaggerOperation(Summary = " ادارة صلاحيات الاستخدام للمستخدمين", OperationId = "ManageUserClaims")]
        [HttpGet(Router.Authorization.ManageUserClaims)]
        public async Task<IActionResult> ManageUserClaims([FromRoute] int userId)
        => NewResult(await mediator.Send(new ManageUserClaimsQuery(userId)));



        [SwaggerOperation(Summary = " تعديل صلاحيات  الاستخدام المستخدمين", OperationId = "UpdateUserClaims")]
        [HttpPut(Router.Authorization.UpdateUserClaims)]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
               => NewResult(await mediator.Send(command));


    }
}
