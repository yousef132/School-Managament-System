using SchoolManagment.Core.Features.Departments.Commands.Models;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void CreateDepartmentCommandMapping()
        {
            CreateMap<CreateDepartmentCommand, Department>();
        }
    }
}
