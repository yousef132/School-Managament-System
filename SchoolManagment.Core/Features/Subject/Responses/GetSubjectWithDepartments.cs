namespace SchoolManagment.Core.Features.Subject.Responses
{
    public class GetSubjectWithDepartments
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public IReadOnlyList<SubjectWithDepartment> Departments { get; set; }
        public class SubjectWithDepartment
        {
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; }
        }

    }

}
