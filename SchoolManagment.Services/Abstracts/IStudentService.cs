using SchoolManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Services.Abstracts
{
	public interface IStudentService
	{
		public Task<List<Student>> GetStudentsAsync();
	}
}
