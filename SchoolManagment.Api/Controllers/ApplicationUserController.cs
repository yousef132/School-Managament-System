﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.AppUser.Commands.Models;
using SchoolManagment.Core.Features.AppUser.Queries.Models;
using SchoolManagment.Data.AppMetaData;
using SchoolManagment.Data.Helper;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagment.Api.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class ApplicationUserController : AppControllerBase
    {



        [HttpPost]
        [Route(Router.ApplicationUserRouting.Create)]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "إضافة مستخدم")]
        public async Task<IActionResult> Create([FromForm] AddUserCommand command)
             => NewResult(await mediator.Send(command));


        [HttpGet]
        [Route(Router.ApplicationUserRouting.GetById)]
        [SwaggerOperation(Summary = "الحصول على مستخدم بواسطة المعرف")]

        public async Task<IActionResult> GetUserById(int id)
            => NewResult(await mediator.Send(new GetUserByIdQuery(id)));


        [HttpGet]
        [Route(Router.ApplicationUserRouting.List)]
        [SwaggerOperation(Summary = "الحصول على قائمة المستخدمين")]

        public async Task<IActionResult> GetUsersList()
            => NewResult(await mediator.Send(new GetUserListQuery()));


        [HttpPut]
        [Route(Router.ApplicationUserRouting.Edit)]
        [SwaggerOperation(Summary = "تحديث معلومات المستخدم")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
            => NewResult(await mediator.Send(command));


        [HttpDelete]
        [Route(Router.ApplicationUserRouting.Delete)]
        [SwaggerOperation(Summary = "حذف مستخدم")]
        public async Task<IActionResult> DeleteUser(int id)
            => NewResult(await mediator.Send(new DeleteUserCommand(id)));

        [HttpPut]
        [Route(Router.ApplicationUserRouting.ChangePassword)]
        [SwaggerOperation(Summary = "تغيير كلمة مرور المستخدم")]
        [Authorize(Roles = $"{Roles.User},{Roles.Admin}")]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UpdateUserPasswordCommand command)
            => NewResult(await mediator.Send(command));


        [HttpGet(Router.ApplicationUserRouting.CurrentUser)]
        [SwaggerOperation(Summary = "بيانات المستخدم الحالى")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
            => NewResult(await mediator.Send(new GetCurrentUserQuery(GetCurrentUserEmail())));


    }
}
