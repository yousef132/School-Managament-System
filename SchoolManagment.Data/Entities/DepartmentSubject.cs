using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Data.Entities
{
	public class DepartmentSubject
	{
		[Key]
		public int DeptSubId {get;set;}
		[ForeignKey("DeptId")]

		public int DeptId { get; set; }
		[ForeignKey("StudId")]
		public int SubId { get; set; }


		public Department Department { get; set; }
		public Subject Subject { get; set; }	

	}
}
