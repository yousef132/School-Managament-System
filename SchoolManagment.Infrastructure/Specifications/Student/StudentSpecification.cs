namespace SchoolManagment.Infrastructure.Specifications.Student
{
    public class StudentSpecification
    {

        public const int MAXPAGESIZE = 20;
        public string? Sort { get; set; }

        public int PageIndex { get; set; } = 1;

        private int pageSize = 6;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value < MAXPAGESIZE ? value : MAXPAGESIZE;
        }

        private string? search;

        public string? Search
        {
            get => search;
            set => search = value?.Trim().ToLower();
        }
    }
}
