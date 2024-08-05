using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helper;
using SchoolManagment.Infrastructure.InfrastructureBases;
using SchoolManagment.Services.Abstracts;
using System.Web;

namespace SchoolManagment.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IGenericRepositoryAsync<ApplicationUser> genericRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor context;
        private readonly IEmailService emailService;
        private readonly IUrlHelper urlHelper;

        public UserService(IGenericRepositoryAsync<ApplicationUser> genericRepository,
                           UserManager<ApplicationUser> userManager,
                           IHttpContextAccessor httpContext,
                           IEmailService emailService,
                           IUrlHelper urlHelper)
        {
            this.genericRepository = genericRepository;
            this.userManager = userManager;
            this.context = httpContext;
            this.emailService = emailService;
            this.urlHelper = urlHelper;
        }
        public async Task<string> AddUserAsync(ApplicationUser inputUser, string password)
        {
            var transaction = genericRepository.BeginTransaction();
            try
            {
                var user = await userManager.FindByEmailAsync(inputUser.Email);
                if (user != null)
                    return "EmailAlreadyExists";

                var UserByUserName = await userManager.FindByNameAsync(inputUser.UserName);

                if (UserByUserName != null)
                    return "UserNameAlreadyExists";


                var createResult = await userManager.CreateAsync(inputUser, password);

                if (!createResult.Succeeded)
                    return string.Join("; ", createResult.Errors.Select(e => e.Description));

                await userManager.AddToRoleAsync(inputUser, Roles.User);

                // send confirm email
                var code = await userManager.GenerateEmailConfirmationTokenAsync(inputUser);
                var requestAccess = context.HttpContext.Request;

                var returnUrl = requestAccess.Scheme + "://" + requestAccess.Host + $"/Api/V1/Authentication/Confirm-Email?UserId={inputUser.Id}&code={HttpUtility.UrlEncode(code)}";
                var sendEmailResult = await emailService.SendEmailAsync(inputUser.Email, returnUrl, "Confirming Email");

                if (sendEmailResult == "Failed")
                    return "FailedToSendEmail";

                transaction.Commit();
                return "Success";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return "Failed";
            }
        }
    }
}
