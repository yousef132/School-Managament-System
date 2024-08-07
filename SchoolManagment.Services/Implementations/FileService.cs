using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SchoolManagment.Services.Abstracts;
using Serilog;

namespace SchoolManagment.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> UploadFileAsync(string location, IFormFile image)
        {
            var serverPath = webHostEnvironment.WebRootPath;
            var extension = Path.GetExtension(image.FileName);
            var imagePath = $"/{location}/{Guid.NewGuid().ToString().Replace("-", string.Empty)}{extension}";

            var fullPath = serverPath + imagePath;

            if (image.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(serverPath))
                        // if directory not fount so make one
                        Directory.CreateDirectory(serverPath);

                    using (FileStream stream = File.Create(fullPath))
                    {
                        await image.CopyToAsync(stream);
                        await stream.FlushAsync();
                        return imagePath;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("FailedToUploadImage", image.Name);
                    return "FailedToUploadImage";
                    throw;
                }

            }
            else
                return "NoImage";
        }
    }

}
