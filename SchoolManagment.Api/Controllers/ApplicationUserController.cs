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
        {
            var result = await mediator.Send(command);
            return NewResult(result);

        }

        [HttpGet]

        [Route(Router.ApplicationUserRouting.GetById)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await mediator.Send(new GetUserByIdQuery(id));
            return NewResult(result);

        }

        [HttpGet]

        [Route(Router.ApplicationUserRouting.List)]
        public async Task<IActionResult> GetUsersList()
        {
            var result = await mediator.Send(new GetUserListQuery());
            return NewResult(result);

        }


    }
}
