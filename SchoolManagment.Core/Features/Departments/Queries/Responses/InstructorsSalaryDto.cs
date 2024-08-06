namespace SchoolManagment.Core.Features.Departments.Queries.Responses
{
    public class InstructorsSalaryDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentNameEn { get; set; }
        public string DepartmentNameAr { get; set; }
        public IReadOnlyList<InstructorDto> Instructors { get; set; }
        public class InstructorDto
        {
            public int InstructorId { get; set; }
            public string InstructorNameEn { get; set; }
            public string InstructorNameAr { get; set; }
            public decimal Salary { get; set; }
            public int RowNumber { get; set; }
        }
    }
}
