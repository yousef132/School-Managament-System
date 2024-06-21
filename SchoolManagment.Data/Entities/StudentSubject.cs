using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
	public class StudentSubject
	{
		[Key]
		public int StudSubId { get; set; }

		public int StudId { get; set; }
		public int SubId { get; set; }

		[ForeignKey("StudId")]
		public Student Student { get; set; }

		[ForeignKey("SubId")]
		public Subject Subject { get; set; }
	}
}
