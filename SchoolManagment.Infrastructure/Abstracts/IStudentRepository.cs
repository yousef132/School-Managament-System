using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Infrastructure.Abstracts
{
	public interface IStudentRepository:IGenericRepositoryAsync<Student>
	{
		public Task<List<Student>> GetStudentsAsync();
	}
}
