using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.AppUser.Queries.Models;
using SchoolManagment.Core.Features.AppUser.Queries.Responses;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Resources;

namespace SchoolManagment.Core.Features.AppUser.Queries.Handler
{
    public class UserQueryHandler : ResponseHandler,
            IRequestHandler<GetUserListQuery, Response<List<GetUserListResponse>>>,
            IRequestHandler<GetCurrentUserQuery, Response<GetCurrentUserResponse>>,
            IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<Role> roleManager;
        #endregion

        #region Constructor
        public UserQueryHandler(IStringLocalizer<SharedResource> localizer,
                                IMapper mapper,
                                UserManager<ApplicationUser> userManager,
                                RoleManager<Role> roleManager) : base(localizer)
        {
            this.localizer = localizer;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        #endregion

        #region Handler
        public async Task<Response<List<GetUserListResponse>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await userManager.Users.ToListAsync();
            var mappedUsers = mapper.Map<List<GetUserListResponse>>(users);
            for (int i = 0; i < users.Count; i++)
            {
                var roles = await userManager.GetRolesAsync(users[i]);
                mappedUsers[i].Roles.AddRange(roles);
            }
            return Success(mappedUsers);
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await userManager.FindByIdAsync(request.Id.ToString());


            if (result == null)
                return NotFound<GetUserByIdResponse>(localizer[SharedResourcesKeys.UserNotFound]);

            var mappedUser = mapper.Map<GetUserByIdResponse>(result);

            return Success(mappedUser);

        }

        public async Task<Response<GetCurrentUserResponse>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            return Success(mapper.Map<GetCurrentUserResponse>(user));
        }
        #endregion
    }
}