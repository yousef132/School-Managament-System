using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.AppUser.Commands.Models;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.AppUser.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>,
        IRequestHandler<UpdateUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<UpdateUserPasswordCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly IUserService userService;
        #endregion


        #region Constructor
        public UserCommandHandler(IStringLocalizer<SharedResource> localizer,
                                  UserManager<ApplicationUser> userManager,
                                  IMapper mapper,
                                  IUserService userService)
          : base(localizer)
        {
            this.localizer = localizer;
            this.userManager = userManager;
            this.mapper = mapper;
            this.userService = userService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var mappedUser = mapper.Map<ApplicationUser>(request);
            var result = await userService.AddUserAsync(mappedUser, request.Password);
            return result switch
            {
                "UserNameAlreadyExists" => BadRequest<string>(localizer[SharedResourcesKeys.UserNameAlreadyExists]),
                "EmailAlreadyExists" => BadRequest<string>(localizer[SharedResourcesKeys.EmailAlreadyExists]),
                "FailedToSendEmail" => BadRequest<string>(localizer[SharedResourcesKeys.FailedToSendEmail]),
                "Success" => Created<string>(localizer[SharedResourcesKeys.Created]),
                _ => BadRequest<string>(result)

            };
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
                return NotFound<string>(localizer[SharedResourcesKeys.UserNotFound]);

            var mappedUser = mapper.Map(request, user);

            var result = await userManager.UpdateAsync(mappedUser);

            if (!result.Succeeded)
                return BadRequest<string>(string.Join("; ", result.Errors.Select(e => e.Description)));

            return Success((string)localizer[SharedResourcesKeys.Edited]);

        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
                return NotFound<string>(localizer[SharedResourcesKeys.UserNotFound]);

            var result = await userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return BadRequest<string>(string.Join("; ", result.Errors.Select(e => e.Description)));

            return Deleted<string>(localizer[SharedResourcesKeys.Deleted]);
        }

        public async Task<Response<string>> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
                return NotFound<string>(localizer[SharedResourcesKeys.UserNotFound]);

            var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);


            if (!result.Succeeded)
                return BadRequest<string>(string.Join("; ", result.Errors.Select(e => e.Description)));

            return Success<string>(localizer[SharedResourcesKeys.PasswordChangedSuccessfully]);

        }
        #endregion
    }
}
