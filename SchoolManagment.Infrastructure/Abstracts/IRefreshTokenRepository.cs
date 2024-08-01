using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Abstracts
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
        //Task<Department> GetDepartmentById(int id);
    }
}
