using Microsoft.AspNetCore.Http;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Services.Abstracts
{
    public interface IInstructorService
    {

        bool IsNameEnExist(string name);
        bool IsNameArExist(string name);
        Task<bool> IsExist(int id);

        Task<string> AddInstructorAsync(Instructor instructor, IFormFile Image);


        Task<IReadOnlyList<Instructor>> GetAllInstructorsAsync();
        Task<Instructor?> GetInstructorByIdAsync(int id);
    }
}
