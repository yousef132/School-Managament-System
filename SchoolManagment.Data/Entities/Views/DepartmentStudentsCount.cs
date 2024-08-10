using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Common;

namespace SchoolManagment.Data.Entities.Views
{
    [Keyless]
    public class DepartmentStudentsCount : GenerateLocalizableEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentNameAr { get; set; }
        public string DepartmentNameEn { get; set; }
        public int Students { get; set; }
    }
}
