using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Authentication.Commands.Models;
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
        public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
             => NewResult(await mediator.Send(command));

    }
}
