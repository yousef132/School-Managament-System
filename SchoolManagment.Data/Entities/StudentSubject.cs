using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
	public class StudentSubject
	{
		public int StudId { get; set; }
		public int SubId { get; set; }

		[ForeignKey("StudId")]
		[InverseProperty(nameof(Student.StudentSubjects))]
		public Student Student { get; set; }

		[ForeignKey("SubId")]
		[InverseProperty(nameof(Subject.StudentSubjects))]
		public Subject Subject { get; set; }

		public decimal? Grade { get; set; }
	}
}
