using SchoolManagment.Data.Common;

namespace SchoolManagment.Data.Entities.Procedures
{
    public class DepartmentTotalStudentsProc : GenerateLocalizableEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentNameAr { get; set; }
        public string DepartmentNameEn { get; set; }
        public int StudentsCount { get; set; }

    }
    public class DepartmentTotalStudentsParam
    {
        public DepartmentTotalStudentsParam(int departmentId)
        {
            DepartmentId = departmentId;
        }

        public int DepartmentId { get; set; }

    }
}
