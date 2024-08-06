using Microsoft.AspNetCore.Http;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Services.Abstracts
{
    public interface IInstructorService
    {

        bool IsNameEnExist(string name);
        bool IsNameArExist(string name);

        Task<string> AddInstructorAsync(Instructor instructor, IFormFile Image);
    }
}
