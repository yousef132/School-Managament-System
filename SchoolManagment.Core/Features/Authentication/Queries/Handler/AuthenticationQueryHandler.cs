using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authentication.Queries.Model;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Authentication.Queries.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler,
        IRequestHandler<AuthorizeUserQuery, Response<string>>,
        IRequestHandler<ConfirmEmailQuery, Response<string>>,
        IRequestHandler<ResetPasswordQuery, Response<string>>
    {
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAuthenticationService authenticationService;

        public AuthenticationQueryHandler(IStringLocalizer<SharedResource> localizer,
                                          UserManager<ApplicationUser> userManager,
                                          IAuthenticationService authenticationService)
            : base(localizer)
        {
            this.localizer = localizer;
            this.userManager = userManager;
            this.authenticationService = authenticationService;
        }
        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {

            var valid = await authenticationService.ValidateAccessToken(request.AccessToken);
            if (valid)
                return Success<string>(localizer[SharedResourcesKeys.ValidToken]);

            return Unauthorized<string>(localizer[SharedResourcesKeys.InvalidToken]);

        }

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await authenticationService.ConfirmEmail(request.UserId, request.Code);

            return confirmEmail switch
            {
                "UserNotFount" => BadRequest<string>(localizer[SharedResourcesKeys.UserNotFound]),
                "ErrorWhileConfirmingEmail" => BadRequest<string>(localizer[SharedResourcesKeys.ErrorWhileConfirmingEmail]),
                _ => Success<string>(localizer[SharedResourcesKeys.Success])
            };
        }

        public async Task<Response<string>> Handle(ResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var result = await authenticationService.ResetPassword(request.Code, request.Email);
            return result switch
            {
                "UserNotFound" => BadRequest<string>(localizer[SharedResourcesKeys.UserNotFound]),
                "Failed" => BadRequest<string>(localizer[SharedResourcesKeys.InvalidCode]),
                _ => Success<string>(localizer[SharedResourcesKeys.Success])
            };
        }
    }
}
