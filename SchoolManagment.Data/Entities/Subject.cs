using System.ComponentModel.DataAnnotations;

namespace SchoolManagment.Data.Entities
{
	public class Subject
	{
        public Subject()
        {
            DepartmentSubjects = new HashSet<DepartmentSubject>();
        }
		[Key]
        public int SubId { get; set; }
		public string SubjectName { get; set; }

		public DateTime Period { get; set; }

		public ICollection<DepartmentSubject> DepartmentSubjects { get; set; }	

	}
}
