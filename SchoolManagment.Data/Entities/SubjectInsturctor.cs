using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
	public class SubjectInsturctor
	{
		public int SubId { get; set; }
		public int InsId { get; set; }


		[ForeignKey("InsId")]
		[InverseProperty(nameof(Instructor.SubjectInsturctors))]

		public Instructor Instructor { get; set; }
		[ForeignKey("SubId")]
		[InverseProperty(nameof(Subject.SubjectInsturctors))]
		public Subject Subject { get; set; }


	}
}
