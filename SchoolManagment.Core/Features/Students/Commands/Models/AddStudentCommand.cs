using MediatR;
using SchoolManagment.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Features.Students.Commands.Models
{
	public class AddStudentCommand : IRequest<Response<string>>
	{
		[Required]
		public string Name { get; set; }
		[Required]

		public string Address { get; set; }
		public int DepartmentId {  get; set; }

		public string Phone { get; set; }
	}
}
