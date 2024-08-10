using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Email.Commands.Models;
using SchoolManagment.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagment.Api.Controllers
{
    public class EmailController : AppControllerBase
    {

        [HttpPost(Router.Email.SendEmail)]
        [SwaggerOperation(summary: "ارسال بريد ")]

        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
            => NewResult(await mediator.Send(command));
    }
}
