using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authorization.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Authorization.Commands.Handler
{
    public class ClaimsCommandHandler : ResponseHandler, IRequestHandler<UpdateUserClaimsCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IAuthorizationService authorizationService;

        #endregion

        #region Constructor

        public ClaimsCommandHandler(IStringLocalizer<SharedResource> localizer,
                                    IAuthorizationService authorizationService) : base(localizer)
        {
            this.localizer = localizer;
            this.authorizationService = authorizationService;
        }

        #endregion
        #region Handlers

        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationService.UpdateUserClaimsAsync(request);
            return result switch
            {
                "UserNotFound" => NotFound<string>(localizer[SharedResourcesKeys.UserNotFound]),
                "FailedToRemoveOldClaims" => BadRequest<string>(localizer[SharedResourcesKeys.FailedToRemoveOldClaims]),
                "FailedToAddNewClaims" => BadRequest<string>(localizer[SharedResourcesKeys.FailedToAddNewClaims]),
                "FailedToUpdateClaims" => BadRequest<string>(localizer[SharedResourcesKeys.FailedToUpdateClaims]),
                _ => Success<string>(localizer[SharedResourcesKeys.Success]),
            };
        }
        #endregion
    }
}
