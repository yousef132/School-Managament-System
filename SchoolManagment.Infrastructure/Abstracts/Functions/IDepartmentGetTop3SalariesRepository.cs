using SchoolManagment.Data.Entities.Functions;

namespace SchoolManagment.Infrastructure.Abstracts.Functions
{
    public interface IDepartmentGetTop3SalariesRepository
    {
        Task<List<GetTop3InstructorSalariesByDept>> GetTop3Salaries();
    }
}
