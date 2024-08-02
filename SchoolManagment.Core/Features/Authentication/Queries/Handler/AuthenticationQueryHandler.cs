using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authentication.Queries.Model;
using SchoolManagment.Core.Resources;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Authentication.Queries.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler, IRequestHandler<AuthorizeUserQuery, Response<string>>
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
    }
}
