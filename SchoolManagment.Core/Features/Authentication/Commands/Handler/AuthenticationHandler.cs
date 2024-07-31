﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authentication.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Authentication.Commands.Handler
{
    internal class AuthenticationCommandHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<string>>
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
        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return BadRequest<string>((string)localizer[SharedResourcesKeys.UserNameNotExist]);

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
                return BadRequest<string>((string)localizer[SharedResourcesKeys.WrongPassword]);

            // generate token
            return Success(await authenticationService.GenerateJWTToken(user));
        }
        #endregion
    }
}
