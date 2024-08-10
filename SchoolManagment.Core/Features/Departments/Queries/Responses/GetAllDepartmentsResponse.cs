namespace SchoolManagment.Core.Features.Departments.Queries.Responses
{
    public class GetAllDepartmentsResponse
    {
        public int DeptId { get; set; }
        public int? ManagerId { get; set; }
        public string Name { get; set; }
    }
}
