namespace SchoolManagment.Core.Features.Instructor.Queries.Response
{
    public class GetInstructorResponse
    {
        public int InstId { get; set; }

        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public string Address { get; set; }

        public string Position { get; set; }
        public string? ImagePath { get; set; }
        public int? SupervisorId { get; set; }

        public double? Salary { get; set; }
        public int? DeptId { get; set; }
    }
}
