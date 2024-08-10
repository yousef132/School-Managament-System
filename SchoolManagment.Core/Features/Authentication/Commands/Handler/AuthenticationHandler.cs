using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authentication.Commands.Models;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helper;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Authentication.Commands.Handler
{
    internal class AuthenticationCommandHandler : ResponseHandler,
        IRequestHandler<SignInCommand, Response<JwtAuthModel>>,
        IRequestHandler<RefreshTokenCommand, Response<JwtAuthModel>>,
        IRequestHandler<SendResetPasswordCommand, Response<string>>,
        IRequestHandler<ResetPasswordCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAuthenticationService authenticationService;

        #endregion

        #region Constructor
        public AuthenticationCommandHandler(IStringLocalizer<SharedResource> localizer,
                                            SignInManager<ApplicationUser> signInManager,
                                            UserManager<ApplicationUser> userManager,
                                             IAuthenticationService authenticationService
                                            )
            : base(localizer)
        {
            this.localizer = localizer;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.authenticationService = authenticationService;
            this.authenticationService = authenticationService;
        }
        #endregion

        #region Handlers
        public async Task<Response<JwtAuthModel>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return BadRequest<JwtAuthModel>((string)localizer[SharedResourcesKeys.UserNameNotExist]);

            if (!user.EmailConfirmed)
                return BadRequest<JwtAuthModel>((string)localizer[SharedResourcesKeys.ConfirmEmail]);

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
                return BadRequest<JwtAuthModel>((string)localizer[SharedResourcesKeys.WrongPassword]);

            // generate token
            return Success(await authenticationService.GenerateJWTTokenWithRefreshToken(user));
        }

        public async Task<Response<JwtAuthModel>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await authenticationService.GetRefreshToken(request.AccessToken, request.RefreshToken);
            return Success(result);
        }

        public async Task<Response<string>> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await authenticationService.SendResetPasswordCode(request.Email);
            return result switch
            {
                "UserNotFound" => BadRequest<string>(localizer[SharedResourcesKeys.UserNotFound]),
                "ErrorInUpdateUser" => BadRequest<string>(localizer[SharedResourcesKeys.TryAgainInAnotherTime]),
                "Failed" => BadRequest<string>(localizer[SharedResourcesKeys.TryAgainInAnotherTime]),
                "Success" => Success<string>(""),
                _ => BadRequest<string>(localizer[SharedResourcesKeys.TryAgainInAnotherTime])
            };
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await authenticationService.UpdatePassword(request.Email, request.Password);
            return result switch
            {
                "UserNotFound" => BadRequest<string>(localizer[SharedResourcesKeys.UserNotFound]),
                "Failed" => BadRequest<string>(localizer[SharedResourcesKeys.Failed]),
                _ => Success("")
            };
        }
        #endregion
    }
}
