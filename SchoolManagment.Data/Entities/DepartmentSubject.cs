using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
    public class DepartmentSubject
    {
        public DepartmentSubject(int deptId, int subId)
        {
            DeptId = deptId;
            SubId = subId;
        }
        public DepartmentSubject()
        {

        }
        public int DeptId { get; set; }
        public int SubId { get; set; }
        [ForeignKey("DeptId")]
        [InverseProperty(nameof(Department.DepartmentSubjects))]

        public Department Department { get; set; }
        [ForeignKey("SubId")]
        [InverseProperty(nameof(Subject.DepartmentSubjects))]

        public Subject Subject { get; set; }

    }
}
