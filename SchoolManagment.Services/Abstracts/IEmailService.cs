namespace SchoolManagment.Services.Abstracts
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(string email, string message, string? reason);

    }
}
