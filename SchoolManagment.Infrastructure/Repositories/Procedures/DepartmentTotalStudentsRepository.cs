using SchoolManagment.Data.Entities.Procedures;
using SchoolManagment.Infrastructure.Abstracts.Procedures;
using SchoolManagment.Infrastructure.Data;
using StoredProcedureEFCore;

namespace SchoolManagment.Infrastructure.Repositories.Procedures
{
    internal class DepartmentTotalStudentsRepository : IDepartmentTotalStudentsRepository
    {
        private readonly ApplicationDbContext context;

        public DepartmentTotalStudentsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IReadOnlyList<DepartmentTotalStudentsProc>> GetDepartmentTotalStudents(DepartmentTotalStudentsParam param)
        {
            var rows = new List<DepartmentTotalStudentsProc>();
            await context.LoadStoredProc(nameof(DepartmentTotalStudentsProc))
                 .AddParam(nameof(DepartmentTotalStudentsParam.DepartmentId), param.DepartmentId)
                 .ExecAsync(async r => rows = await r.ToListAsync<DepartmentTotalStudentsProc>());
            return rows;
        }
    }
}
