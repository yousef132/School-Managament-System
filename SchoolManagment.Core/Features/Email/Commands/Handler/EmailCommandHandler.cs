using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Email.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Email.Commands.Handler
{
    public class EmailCommandHandler : ResponseHandler, IRequestHandler<SendEmailCommand, Response<string>>
    {
        #region Fields

        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IEmailService emailService;

        #endregion
        #region Constructor
        public EmailCommandHandler(IStringLocalizer<SharedResource> localizer, IEmailService emailService) : base(localizer)
        {
            this.localizer = localizer;
            this.emailService = emailService;
        }
        #endregion
        #region Handlers
        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await emailService.SendEmailAsync(request.Email, request.Message, null);

            if (result == "Success")
                return Success("");
            return BadRequest<string>(localizer[SharedResourcesKeys.FailedToSendEmail]);
        }
        #endregion
    }
}
