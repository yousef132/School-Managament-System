using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.AppUser.Commands.Models;
using SchoolManagment.Core.Features.AppUser.Queries.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagment.Api.Controllers
{

    public class ApplicationUserController : AppControllerBase
    {
        private readonly IMediator mediator;

        public ApplicationUserController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        [Route(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        => NewResult(await mediator.Send(command));


        [HttpGet]
        [Route(Router.ApplicationUserRouting.GetById)]
        public async Task<IActionResult> GetUserById(int id)
            => NewResult(await mediator.Send(new GetUserByIdQuery(id)));


        [HttpGet]
        [Route(Router.ApplicationUserRouting.List)]
        public async Task<IActionResult> GetUsersList()
         => NewResult(await mediator.Send(new GetUserListQuery()));


        [HttpPut]
        [Route(Router.ApplicationUserRouting.Edit)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
         => NewResult(await mediator.Send(command));

        [HttpDelete]
        [Route(Router.ApplicationUserRouting.Delete)]
        public async Task<IActionResult> DeleteUser(int id)
         => NewResult(await mediator.Send(new DeleteUserCommand(id)));
        [HttpPut]
        [Route(Router.ApplicationUserRouting.ChangePassword)]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UpdateUserPasswordCommand command)
         => NewResult(await mediator.Send(command));




    }
}
