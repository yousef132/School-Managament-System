using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Views;
using SchoolManagment.Infrastructure.Abstracts.Views;
using SchoolManagment.Infrastructure.Data;
using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Repositories.Views
{
    public class DepartmentViewRepository : GenericRepositoryAsync<DepartmentView>, IViewRepository<DepartmentView>
    {
        #region Fields & Properties
        private readonly DbSet<DepartmentView> departments;

        #endregion



        #region Constructor
        public DepartmentViewRepository(ApplicationDbContext context) :
            base(context)
        {
            departments = context.Set<DepartmentView>();
        }
        #endregion



        #region Functions   

        #endregion


    }
}
