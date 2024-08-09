using SchoolManagment.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
    public class Student : GenerateLocalizableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudId { get; set; }

        [MaxLength(100)]
        public string? NameAr { get; set; }

        [MaxLength(100)]
        public string? NameEn { get; set; }
        [MaxLength(300)]
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public int? DeptId { get; set; }


        [ForeignKey("DeptId")]
        [InverseProperty(nameof(Department.Students))]
        public Department Department { get; set; }


        [InverseProperty(nameof(StudentSubject.Student))]
        public ICollection<StudentSubject> StudentSubjects { get; set; }

    }
}