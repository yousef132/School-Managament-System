using System.ComponentModel.DataAnnotations;

namespace SchoolManagment.Data.Entities
{
	public class Department
	{

        public Department()
        {
            Students= new HashSet<Student>();	
			DepartmentSubjects= new HashSet<DepartmentSubject>();
        }
		[Key]
        public int DeptId { get; set; } 
		[MaxLength(300)]
		public string Name { get; set; }

		public ICollection<Student> Students { get; set; }
		public ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
	}
}
