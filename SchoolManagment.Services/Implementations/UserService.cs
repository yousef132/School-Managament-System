using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helper;
using SchoolManagment.Infrastructure.InfrastructureBases;
using SchoolManagment.Services.Abstracts;
using Serilog;

namespace SchoolManagment.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<ApplicationUser> genericRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor context;
        private readonly IEmailService emailService;
        private readonly IUrlHelper urlHelper;
        private readonly IDataProtector protector;

        public UserService(IGenericRepository<ApplicationUser> genericRepository,
                           UserManager<ApplicationUser> userManager,
                           IHttpContextAccessor httpContext,
                           IEmailService emailService,
                           IUrlHelper urlHelper,
                           IDataProtectionProvider protector)
        {
            this.genericRepository = genericRepository;
            this.userManager = userManager;
            this.context = httpContext;
            this.emailService = emailService;
            this.urlHelper = urlHelper;
            this.protector = protector.CreateProtector(Encryptor.Key);
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

                code = protector.Protect(code); // encoding token

                var requestAccess = context.HttpContext.Request;
                var helper = urlHelper.Action("ConfirmEmail", "Authentication", new { userId = inputUser.Id, code = code });

                var returnUrl = requestAccess.Scheme + "://" + requestAccess.Host + helper;
                // generate message with encoded url
                var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Confirm</a>";

                var sendEmailResult = await emailService.SendEmailAsync(inputUser.Email, message, "Confirming Email");

                if (sendEmailResult == "Failed")
                    return "FailedToSendEmail";

                transaction.Commit();
                return "Success";
            }
            catch (Exception ex)
            {
                Log.Error("Failed To Add User");
                transaction.Rollback();
                return "Failed";
            }
        }
    }
}
