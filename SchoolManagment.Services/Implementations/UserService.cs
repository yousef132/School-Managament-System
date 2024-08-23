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
        private readonly IHttpContextAccessor httpContext;
        private readonly IEmailService emailService;
        private readonly IUrlHelper urlHelper;
        private readonly IFileService fileService;
        private readonly IDataProtector protector;

        public UserService(IGenericRepository<ApplicationUser> genericRepository,
                           UserManager<ApplicationUser> userManager,
                           IHttpContextAccessor httpContext,
                           IEmailService emailService,
                           IUrlHelper urlHelper,
                           IDataProtectionProvider protector,
                           IFileService fileService)
        {
            this.genericRepository = genericRepository;
            this.userManager = userManager;
            this.httpContext = httpContext;
            this.emailService = emailService;
            this.urlHelper = urlHelper;
            this.fileService = fileService;
            this.protector = protector.CreateProtector(Encryptor.Key);
        }
        public async Task<string> AddUserAsync(ApplicationUser inputUser, string password, IFormFile image)
        {
            var transaction = genericRepository.BeginTransaction();
            try
            {
                #region Validate UserName & Email
                var user = await userManager.FindByEmailAsync(inputUser.Email);
                if (user != null)
                    return "EmailAlreadyExists";

                var UserByUserName = await userManager.FindByNameAsync(inputUser.UserName);

                if (UserByUserName != null)
                    return "UserNameAlreadyExists";
                #endregion

                #region Upload Image
                if (image is not null)
                {

                    var request = httpContext.HttpContext.Request;
                    var baseUrl = $"{request.Scheme}://{request.Host}";

                    // Upload the image file and get the image path
                    string imagePath = await fileService.UploadFileAsync("UserImages", image);

                    // Check if the image upload was successful
                    if (imagePath == "NoImage" || imagePath == "FailedToUploadImage")
                        return imagePath;
                    // Set the image path for the instructor
                    inputUser.ImagePath = $"{baseUrl}{imagePath}";
                }

                #endregion

                #region Create User
                var createResult = await userManager.CreateAsync(inputUser, password);

                if (!createResult.Succeeded)
                    return string.Join("; ", createResult.Errors.Select(e => e.Description));

                await userManager.AddToRoleAsync(inputUser, Roles.User);
                #endregion


                #region Email Confirmation
                // send confirm email
                var code = await userManager.GenerateEmailConfirmationTokenAsync(inputUser);

                code = protector.Protect(code); // encoding token

                var requestAccess = httpContext.HttpContext.Request;
                var helper = urlHelper.Action("ConfirmEmail", "Authentication", new { userId = inputUser.Id, code = code });

                var returnUrl = requestAccess.Scheme + "://" + requestAccess.Host + helper;
                // generate message with encoded url
                var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Confirm</a>";

                var sendEmailResult = await emailService.SendEmailAsync(inputUser.Email, message, "Confirming Email");

                if (sendEmailResult == "Failed")
                    return "FailedToSendEmail";
                #endregion

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
