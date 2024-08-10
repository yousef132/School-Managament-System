using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Views;
using SchoolManagment.Infrastructure.Abstracts.Views;
using SchoolManagment.Infrastructure.Data;
using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Repositories.Views
{
    public class DepartmentViewRepository : GenericRepository<DepartmentStudentsCount>, IViewRepository<DepartmentStudentsCount>
    {
        #region Fields & Properties
        private readonly DbSet<DepartmentStudentsCount> departments;

        #endregion



        #region Constructor
        public DepartmentViewRepository(ApplicationDbContext context) :
            base(context)
        {
            departments = context.Set<DepartmentStudentsCount>();
        }
        #endregion



        #region Functions   

        #endregion


    }
}
