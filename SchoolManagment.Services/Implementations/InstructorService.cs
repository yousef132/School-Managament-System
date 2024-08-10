using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Services.Abstracts;
using Serilog;

namespace SchoolManagment.Services.Implementations
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository instructorRepository;
        private readonly IFileService fileService;
        private readonly IHttpContextAccessor httpContext;

        public InstructorService(IInstructorRepository instructorRepository, IFileService fileService, IHttpContextAccessor httpContext)
        {
            this.instructorRepository = instructorRepository;
            this.fileService = fileService;
            this.httpContext = httpContext;
        }
        public bool IsNameEnExist(string name)
            => instructorRepository.GetTableAsNotTracked().Any(x => x.NameEn == name);
        public bool IsNameArExist(string name)
            => instructorRepository.GetTableAsNotTracked().Any(x => x.NameAr == name);

        public async Task<string> AddInstructorAsync(Instructor instructor, IFormFile image)
        {
            // Construct the base URL for the current request
            var request = httpContext.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";

            // Upload the image file and get the image path
            string imagePath = await fileService.UploadFileAsync("InstructorImages", image);

            // Check if the image upload was successful
            if (imagePath == "NoImage" || imagePath == "FailedToUploadImage")
                return imagePath;

            try
            {
                // Set the image path for the instructor
                instructor.ImagePath = $"{baseUrl}{imagePath}";

                // Add the instructor to the repository
                await instructorRepository.AddAsync(instructor);

                return "Success";
            }
            catch (Exception ex)
            {
                Log.Error("Failed To Add Instructor", ex.Message);

                return "FailedToAddInstructor";
            }
        }

        public Task<bool> IsExist(int id)
            => instructorRepository.GetTableAsNotTracked().AnyAsync(x => x.InstId == id);

        public async Task<IReadOnlyList<Instructor>> GetAllInstructorsAsync()
            => await instructorRepository.GetTableAsNotTracked().ToListAsync();

        public async Task<Instructor?> GetInstructorByIdAsync(int id)
            => await instructorRepository.GetByIdAsync(id);
    }
}