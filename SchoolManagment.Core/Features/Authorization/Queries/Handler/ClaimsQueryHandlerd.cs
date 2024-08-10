using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authorization.Queries.Model;
using SchoolManagment.Data.Resources;
using SchoolManagment.Data.Responses;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Authorization.Queries.Handler
{
    public class ClaimsQueryHandler : ResponseHandler,
        IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResponse>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IAuthorizationService authorizationService;
        #endregion
        #region Constructor
        public ClaimsQueryHandler(IStringLocalizer<SharedResource> localizer, IAuthorizationService authorizationService) : base(localizer)
        {
            this.localizer = localizer;
            this.authorizationService = authorizationService;
        }

        #endregion

        #region Handlers
        public async Task<Response<ManageUserClaimsResponse>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var result = await authorizationService.GetUserWithClaimsAsync(request.UserId);
            if (result == null)
                return NotFound<ManageUserClaimsResponse>(localizer[SharedResourcesKeys.UserNotFound]);

            return Success(result);
        }
        #endregion
    }
}
