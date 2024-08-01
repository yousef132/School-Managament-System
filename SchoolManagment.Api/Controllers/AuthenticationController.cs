using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Authentication.Commands.Models;
using SchoolManagment.Core.Features.Authentication.Queries.Model;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagment.Api.Controllers
{

    public class AuthenticationController : AppControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IMediator mediator;

        public AuthenticationController(IAuthenticationService authenticationService, IMediator mediator)
        {
            this.authenticationService = authenticationService;
            this.mediator = mediator;
        }

        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand command)
             => NewResult(await mediator.Send(command));



        [HttpPost(Router.Authentication.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
             => NewResult(await mediator.Send(command));

        [HttpGet(Router.Authentication.ValidateToken)]
        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery query)
             => NewResult(await mediator.Send(query));

    }

}
