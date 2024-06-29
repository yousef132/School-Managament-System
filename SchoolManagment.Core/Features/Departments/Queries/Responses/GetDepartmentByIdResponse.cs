using SchoolManagment.Data.Common;
namespace SchoolManagment.Core.Features.Departments.Queries.Responses
{
	public class GetDepartmentByIdResponse : GenerateLocalizableEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ManagerName { get; set; }


		public List<StudentResponse>? Students { get; set; }
		public List<InstructorResponse>? Instructors { get; set; }
		public List<SubjectResponse>? Subjects { get; set; }
	}
}
