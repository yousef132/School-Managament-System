using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
	public class DepartmentSubject
	{
		[Key]
		public int DeptSubId {get;set;}

		public int DeptId { get; set; }
		public int SubId { get; set; }

		[ForeignKey("DeptId")]

		public Department Department { get; set; }
		[ForeignKey("StudId")]

		public Subject Subject { get; set; }	

	}
}
