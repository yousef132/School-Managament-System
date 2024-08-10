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
            public const string AddStudentToDepartment = $"{Prefix}Add-Student-To-Department";
            public const string GetById = $"{Prefix}" + "{id}";
            public const string Create = $"{Prefix}" + "Create";
            public const string Edit = $"{Prefix}" + "Edit";
            public const string Delete = $"{Prefix}" + "Delete/{id}";
            public const string Pagination = $"{Prefix}" + "Pagination";


        }
        public static class Instructor
        {
            public const string Prefix = $"{Rule}Instructor/";

            public const string Create = $"{Prefix}" + "Create";
            public const string GetAllInstructors = $"{Prefix}" + "GetAllInstructors";
            public const string GetById = $"{Prefix}" + "GetInstructorById/{id}";
        }
        public static class Subject
        {
            public const string Prefix = $"{Rule}Subject/";

            public const string Create = $"{Prefix}" + "Create";
            public const string AddToDepartment = $"{Prefix}" + "Add-To-Department";
            public const string Edit = $"{Prefix}" + "Edit";
            public const string GetSubjectWithDepartments = $"{Prefix}" + "Get-Subject-With-Departments";
            public const string AddInstructor = $"{Prefix}" + "Add-Instructor";
            public const string GetTopStudentInEachSubject = $"{Prefix}" + "GetTopStudentInEachSubject";
            public const string GetSubjectsStudentsCount = $"{Prefix}" + "Get-Subjects-Students-Count";
            public const string Delete = $"{Prefix}" + "Delete/{id}";
        }

        public static class Department
        {
            public const string Prefix = $"{Rule}Department/";
            public const string GetById = $"{Prefix}" + "{id}";
            public const string Delete = $"{Prefix}" + "Delete/{id}";
            public const string DepartmentStudentCountById = $"{Prefix}Department-Student-Count-ById" + "/{id}";
            public const string DepartmentStudentCount = $"{Prefix}Department-Student-Count";
            public const string GetTop3InstructorByDepartment = $"{Prefix}Get-Top3-Instructor-By-Department";
            public const string Create = $"{Prefix}Create";
            public const string Update = $"{Prefix}Update";
            public const string GetDepartmentsList = $"{Prefix}GetDepartmentsList";

        }

        public static class ApplicationUserRouting
        {
            public const string Prefix = $"{Rule}User/";
            public const string Create = $"{Prefix}Create";
            public const string Delete = $"{Prefix}Delete";
            public const string ChangePassword = $"{Prefix}ChangePassword";
            public const string Edit = $"{Prefix}Edit";
            public const string List = $"{Prefix}List";
            public const string GetById = $"{Prefix}" + "{id}";
        }

        public static class Authentication
        {
            public const string Prefix = $"{Rule}Authentication/";
            public const string SignIn = $"{Prefix}SignIn";
            public const string RefreshToken = $"{Prefix}Refresh-Token";
            public const string ValidateToken = $"{Prefix}Validate-Token";
            public const string ConfirmResetPassword = $"{Prefix}Confirm-Reset-Password";
            public const string ResetPassword = $"{Prefix}Reset-Password";
            public const string SendResetPasswordCode = $"{Prefix}Send-Reset-Password-Code";
            public const string ConfirmEmail = $"{Prefix}Confirm-Email";

        }

        public static class Authorization
        {
            public const string Prefix = $"{Rule}Authorization/";
            public const string AddRole = $"{Prefix}Add-Role";
            public const string EditRole = $"{Prefix}Edit-Role";
            public const string DeleteRole = $"{Prefix}DeleteRole" + "/{id}";
            public const string RolesList = $"{Prefix}Roles-List";
            public const string UpdateUserRoles = $"{Prefix}Update-User-Roles";
            public const string ManageUserClaims = $"{Prefix}" + "Manage-User-Claims/{userId}";
            public const string UpdateUserClaims = $"{Prefix}" + "Update-User-Claims";
            public const string GetById = $"{Prefix}" + "{id}";
            public const string ManageUserRoles = $"{Prefix}" + "Manage-User-Roles/{userId}";


        }

        public static class Email
        {
            public const string Prefix = $"{Rule}Email/";
            public const string SendEmail = $"{Prefix}Send-Email";
        }

    }
}
