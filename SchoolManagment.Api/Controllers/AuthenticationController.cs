using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Api.Bases;
using SchoolManagment.Core.Features.Authentication.Commands.Models;
using SchoolManagment.Core.Features.Authentication.Queries.Model;
using SchoolManagment.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagment.Api.Controllers
{

    public class AuthenticationController : AppControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost(Router.Authentication.SignIn)]
        [SwaggerOperation(Summary = "تسجيل الدخول")]

        public async Task<IActionResult> SignIn([FromForm] SignInCommand command)
         => NewResult(await mediator.Send(command));


        [HttpPost(Router.Authentication.RefreshToken)]
        [SwaggerOperation(Summary = "تحديث الرمز المميز")]

        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
            => NewResult(await mediator.Send(command));


        [HttpGet(Router.Authentication.ValidateToken)]
        [SwaggerOperation(Summary = "التحقق من صحة الرمز المميز")]

        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery query)
            => NewResult(await mediator.Send(query));


        [HttpGet(Router.Authentication.ConfirmEmail)]
        [SwaggerOperation(Summary = "تأكيد البريد الإلكتروني")]

        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
            => NewResult(await mediator.Send(query));


        [HttpPost(Router.Authentication.SendResetPasswordCode)]
        [SwaggerOperation(Summary = "إرسال رمز إعادة تعيين كلمة المرور")]

        public async Task<IActionResult> SendResetPasswordCode([FromQuery] SendResetPasswordCommand command)
            => NewResult(await mediator.Send(command));


        [HttpGet(Router.Authentication.ConfirmResetPassword)]
        [SwaggerOperation(Summary = "تأكيد إعادة تعيين كلمة المرور")]

        public async Task<IActionResult> ConfirmResetPassword([FromQuery] ResetPasswordQuery query)
            => NewResult(await mediator.Send(query));


        [HttpPost(Router.Authentication.ResetPassword)]
        [SwaggerOperation(Summary = "إعادة تعيين كلمة المرور")]

        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordCommand command)
            => NewResult(await mediator.Send(command));



    }

}
