using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authorization.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Authorization.Commands.Handler
{
    public class RoleCommandHandler : ResponseHandler,
        IRequestHandler<AddRoleCommand, Response<string>>,
        IRequestHandler<EditRoleCommand, Response<string>>,
         IRequestHandler<UpdateUserRolesCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IAuthorizationService authorizationService;

        public RoleCommandHandler(IStringLocalizer<SharedResource> localizer,
                                 IAuthorizationService authorizationService) : base(localizer)
        {
            this.localizer = localizer;
            this.authorizationService = authorizationService;
        }
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
            switch (result)
            {
                case "UserIsNull": return NotFound<string>(localizer[SharedResourcesKeys.UserNotFound]);
                case "FailedToRemoveOldRoles": return BadRequest<string>(localizer[SharedResourcesKeys.FailedToRemoveOldRoles]);
                case "FailedToAddNewRoles": return BadRequest<string>(localizer[SharedResourcesKeys.FailedToAddNewRoles]);
                case "FailedToUpdateUserRoles": return BadRequest<string>(localizer[SharedResourcesKeys.FailedToUpdateUserRoles]);
            }
            return Success<string>(localizer[SharedResourcesKeys.Success]);
        }
    }
}
