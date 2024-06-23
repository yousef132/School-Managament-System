using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Features.Students.Queries.Responses
{
	public class GetStudentsResponse
	{
		public int StudId { get; set; }

		public string Name { get; set; }

		public string Address { get; set; }
		public int? DepartmentName { get; set; }	
	}
}
