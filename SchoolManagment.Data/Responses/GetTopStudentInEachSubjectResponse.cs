namespace SchoolManagment.Data.Responses
{
    public class GetTopStudentInEachSubjectResponse
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int? StudentId { get; set; }
        public string? StudentName { get; set; }
        public decimal? Grade { get; set; }
    }
}
