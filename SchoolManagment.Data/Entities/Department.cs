using SchoolManagment.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
    public class Department : GenerateLocalizableEntity
    {

        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }
        public int? InsId { get; set; }
        [MaxLength(300)]
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        [InverseProperty(nameof(Student.Department))]

        public ICollection<Student> Students { get; set; }



        [InverseProperty(nameof(DepartmentSubject.Department))]
        public ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        //public ICollection<Subject> Subjects { get; set; }



        [InverseProperty(nameof(Instructor.Department))]
        //Instructors teaching in this department
        public ICollection<Instructor> Instructors { get; set; }


        [ForeignKey("InsId")]
        [InverseProperty(nameof(Instructor.DepartmentManage))]
        // Manager
        public Instructor Instructor { get; set; }
    }
}
