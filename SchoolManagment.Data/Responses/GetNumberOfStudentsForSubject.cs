namespace SchoolManagment.Data.Responses
{
    public class GetNumberOfStudentsForSubjectResponse
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int NumberOfStudents { get; set; }
    }
}
