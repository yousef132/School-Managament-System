namespace SchoolManagment.Core.Features.Students.Queries.Responses
{
    public class GetStudentsResponse
    {
        public int StudId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? DepartmentName { get; set; }
    }
}
