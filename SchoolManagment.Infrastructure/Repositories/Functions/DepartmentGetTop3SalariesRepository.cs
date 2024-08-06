using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Functions;
using SchoolManagment.Infrastructure.Abstracts.Functions;
using SchoolManagment.Infrastructure.Data;

namespace SchoolManagment.Infrastructure.Repositories.Functions
{
    public class DepartmentGetTop3SalariesRepository : IDepartmentGetTop3SalariesRepository
    {
        private readonly ApplicationDbContext context;

        public DepartmentGetTop3SalariesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<GetTop3InstructorSalariesByDept>> GetTop3Salaries()
        {
            // used FromSqlInterpolated for sql injection 
            return await context.GetTop3InstructorSalariesByDept
                                .FromSqlInterpolated($"SELECT * FROM dbo.GetTop3InstructorSalariesByDept()")
                                .ToListAsync();
        }
    }
}
