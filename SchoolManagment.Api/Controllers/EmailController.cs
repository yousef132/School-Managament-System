using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Email.Commands.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagment.Api.Controllers
{
    public class EmailController : AppControllerBase
    {
        private readonly IMediator mediator;

        public EmailController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost(Router.Email.SendEmail)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
            => NewResult(await mediator.Send(command));
    }
}
