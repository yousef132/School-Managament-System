using SchoolManagment.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
    public class Instructor : GenerateLocalizableEntity
    {
        public Instructor()
        {
            SupervisedInstructors = new HashSet<Instructor>();
            SubjectInsturctors = new HashSet<SubjectInsturctor>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstId { get; set; }

        public string? NameAr { get; set; }
        public string? NameEn { get; set; }

        public string? Address { get; set; }

        public string? Position { get; set; }
        public string? ImagePath { get; set; }

        public int? SupervisorId { get; set; }

        public double? Salary { get; set; }

        public int? DeptId { get; set; }



        [ForeignKey("DeptId")]
        [InverseProperty(nameof(Department.Instructors))]
        public Department Department { get; set; }



        [InverseProperty(nameof(Department.Instructor))]
        public Department DepartmentManage { get; set; }




        [ForeignKey("SupervisorId")]
        [InverseProperty("SupervisedInstructors")]
        public Instructor Supervisor { get; set; }



        [InverseProperty("Supervisor")]
        public ICollection<Instructor> SupervisedInstructors { get; set; }


        [InverseProperty("Instructor")]
        public ICollection<SubjectInsturctor> SubjectInsturctors { get; set; }
    }
}
