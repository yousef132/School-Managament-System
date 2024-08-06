using Microsoft.AspNetCore.Http;

namespace SchoolManagment.Services.Abstracts
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(string Location, IFormFile image);
    }
}
