using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Data.Entities
{
	public class Student
	{
		[Key]
		public int StudId { get; set; }

		[MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(300)]
		public string Address { get; set; }
		public string Phone { get; set; }
		
		public int? DeptId { get; set; }
		[ForeignKey("DeptId")]
		public Department Department { get; set; }

	}
}
