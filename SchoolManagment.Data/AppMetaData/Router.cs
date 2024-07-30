namespace SchoolManagment.Data.AppMetaData
{
    public class Router
    {
        public const string Root = "Api";
        public const string Version = "V1";
        public const string Rule = $"{Root}/{Version}/";


        public static class StudentRouting
        {
            public const string Prefix = $"{Rule}Student/";


            public const string List = $"{Prefix}List";
            public const string GetById = $"{Prefix}" + "{id}";
            public const string Create = $"{Prefix}" + "Create";
            public const string Edit = $"{Prefix}" + "Edit";
            public const string Delete = $"{Prefix}" + "Delete/{id}";
            public const string Pagenation = $"{Prefix}" + "Pagenation";


        }


        public static class DepartmentRouting
        {
            public const string Prefix = $"{Rule}Department/";
            public const string GetById = $"{Prefix}" + "{id}";

        }

        public static class ApplicationUserRouting
        {
            public const string Prefix = $"{Rule}User/";
            public const string Create = $"{Prefix}Create";
        }

    }
}
