using SchoolManagment.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
	public class Subject : GenerateLocalizableEntity
	{
		public Subject()
		{
			DepartmentSubjects = new HashSet<DepartmentSubject>();
			SubjectInsturctors = new HashSet<SubjectInsturctor>();
			StudentSubjects = new HashSet<StudentSubject>();
		}
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SubId { get; set; }
		public string? SubjectNameAr { get; set; }
		public string? SubjectNameEn { get; set; }

		public DateTime? Period { get; set; }
		[InverseProperty(nameof(DepartmentSubject.Subject))]
		public ICollection<DepartmentSubject> DepartmentSubjects { get; set; }


		[InverseProperty(nameof(SubjectInsturctor.Subject))]
		public ICollection<SubjectInsturctor> SubjectInsturctors { get; set; }



		[InverseProperty(nameof(StudentSubject.Subject))]
		public ICollection<StudentSubject> StudentSubjects { get; set; }

	}
}
