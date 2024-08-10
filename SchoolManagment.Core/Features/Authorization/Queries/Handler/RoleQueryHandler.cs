using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authorization.Queries.Model;
using SchoolManagment.Core.Features.Authorization.Queries.Response;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Resources;
using SchoolManagment.Data.Responses;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Authorization.Queries.Handler
{
    public class RoleQueryHandler : ResponseHandler,
        IRequestHandler<GetRolesListQuery, Response<IReadOnlyList<GetRolesListResponse>>>,
        IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResponse>>,
        IRequestHandler<GetRoleByIdQuery, Response<GetRolesListResponse>>

    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;
        private readonly IAuthorizationService authorizationService;

        #endregion
        #region Constructor
        public RoleQueryHandler(IStringLocalizer<SharedResource> localizer,
                               RoleManager<Role> roleManager,
                               IMapper mapper,
                               IAuthorizationService authorizationService) : base(localizer)
        {
            this.localizer = localizer;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.authorizationService = authorizationService;
        }


        #endregion
        #region Handlers
        public async Task<Response<IReadOnlyList<GetRolesListResponse>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await authorizationService.GetRolesAsync();
            var mappedRoles = mapper.Map<IReadOnlyList<GetRolesListResponse>>(roles);
            return Success(mappedRoles);
        }

        public async Task<Response<GetRolesListResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await authorizationService.GetRoleByIdAsync(request.Id);
            if (role == null)
                return BadRequest<GetRolesListResponse>((string)localizer[SharedResourcesKeys.NotFound]);

            var mappedRole = mapper.Map<GetRolesListResponse>(role);
            return Success(mappedRole);
        }

        public async Task<Response<ManageUserRolesResponse>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var result = await authorizationService.GetUserWithRolesAsync(request.UserId);
            if (result == null)
                return NotFound<ManageUserRolesResponse>(localizer[SharedResourcesKeys.UserNotFound]);

            return Success(result);
        }
        #endregion
    }
}
