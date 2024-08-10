using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authorization.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Authorization.Commands.Handler
{
    public class RoleCommandHandler : ResponseHandler,
        IRequestHandler<AddRoleCommand, Response<string>>,
        IRequestHandler<EditRoleCommand, Response<string>>,
         IRequestHandler<UpdateUserRolesCommand, Response<string>>,
         IRequestHandler<DeleteRoleCommand, Response<string>>
    {
        #region Fields

        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IAuthorizationService authorizationService;
        #endregion

        #region Constructor
        public RoleCommandHandler(IStringLocalizer<SharedResource> localizer,
                                IAuthorizationService authorizationService) : base(localizer)
        {
            this.localizer = localizer;
            this.authorizationService = authorizationService;
        }
        #endregion
        #region Handlers
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationService.AddRoleAsync(request.Role);
            return result ? Success("") : BadRequest<string>(localizer[SharedResourcesKeys.Failed]); ;
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            bool result = await authorizationService.EditRoleAsync(request);
            if (result)
                return Success((string)localizer[SharedResourcesKeys.Success]);

            return BadRequest<string>(localizer[SharedResourcesKeys.Failed]);
        }

        public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationService.UpdateUserRoles(request);
            return result switch
            {
                "InvalidRole" => BadRequest<string>(localizer[SharedResourcesKeys.InvalidRole]),
                "UserIsNull" => NotFound<string>(localizer[SharedResourcesKeys.UserNotFound]),
                "FailedToRemoveOldRoles" => BadRequest<string>(localizer[SharedResourcesKeys.FailedToRemoveOldRoles]),
                "FailedToAddNewRoles" => BadRequest<string>(localizer[SharedResourcesKeys.FailedToAddNewRoles]),
                "FailedToUpdateUserRoles" => BadRequest<string>(localizer[SharedResourcesKeys.FailedToUpdateUserRoles]),
                _ => Success<string>(localizer[SharedResourcesKeys.Success])
            };
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationService.DeleteRole(request.Id);
            if (!result)
                return NotFound<string>(localizer[SharedResourcesKeys.NotFound]);

            return Success<string>(localizer[SharedResourcesKeys.Deleted]);
        }
        #endregion
    }
}
