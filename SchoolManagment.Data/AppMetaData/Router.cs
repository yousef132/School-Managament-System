namespace SchoolManagment.Data.AppMetaData
{
    public class Router
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Rule = $"{Root}/{Version}/";
        public static class StudentRouting
        {
            public const string Prefix = $"{Rule}students/";


            public const string List = $"{Prefix}List";
            public const string AddStudentToDepartment = $"{Prefix}add-student-to-department";
            public const string GetById = $"{Prefix}" + "{id}";
            public const string Create = $"{Prefix}" + "create";
            public const string Edit = $"{Prefix}" + "update";
            public const string Delete = $"{Prefix}" + "delete/{id}";
            public const string Pagination = $"{Prefix}" + "pagination";


        }
        public static class InstructorRouting
        {
            public const string Prefix = $"{Rule}instructors/";

            public const string Create = $"{Prefix}" + "create";
            public const string GetAllInstructors = $"{Prefix}list";
            public const string GetById = $"{Prefix}" + "{id}";
            public const string Delete = $"{Prefix}" + "delete/{id}";
        }
        public static class SubjectRouting
        {
            public const string Prefix = $"{Rule}subjects/";

            public const string Create = $"{Prefix}" + "create";
            public const string AddToDepartment = $"{Prefix}" + "add-to-department";
            public const string Edit = $"{Prefix}" + "update";
            public const string GetSubjectWithDepartments = $"{Prefix}" + "list";
            public const string AddInstructor = $"{Prefix}" + "add-instructor-to-department";
            public const string GetTopStudentInEachSubject = $"{Prefix}" + "top-student-in-each-subject";
            public const string GetSubjectsStudentsCount = $"{Prefix}" + "subjects-students-count";
            public const string Delete = $"{Prefix}" + "delete/{id}";
        }

        public static class DepartmentRouting
        {
            public const string Prefix = $"{Rule}departments/";
            public const string GetById = $"{Prefix}" + "{id}";
            public const string Delete = $"{Prefix}" + "delete/{id}";
            public const string DepartmentStudentCountById = $"{Prefix}department-student-count-by-id" + "/{id}";
            public const string DepartmentStudentCount = $"{Prefix}department-student-count";
            public const string GetTop3InstructorByDepartment = $"{Prefix}top3-instructor-by-department";
            public const string Create = $"{Prefix}create";
            public const string Update = $"{Prefix}update";
            public const string GetDepartmentsList = $"{Prefix}list";

        }

        public static class ApplicationUserRouting
        {
            public const string Prefix = $"{Rule}users/";
            public const string Create = $"{Prefix}create";
            public const string Delete = $"{Prefix}delete";
            public const string ChangePassword = $"{Prefix}change-password";
            public const string Edit = $"{Prefix}update";
            public const string List = $"{Prefix}list";
            public const string CurrentUser = $"{Prefix}current-user";
            public const string GetById = $"{Prefix}" + "{id}";
        }

        public static class Authentication
        {
            public const string Prefix = $"{Rule}authentication/";
            public const string SignIn = $"{Prefix}sign-in";
            public const string RefreshToken = $"{Prefix}refresh-token";
            public const string ValidateToken = $"{Prefix}validate-token";
            public const string ConfirmResetPassword = $"{Prefix}confirm-reset-password";
            public const string ResetPassword = $"{Prefix}reset-password";
            public const string SendResetPasswordCode = $"{Prefix}send-reset-password-code";
            public const string ConfirmEmail = $"{Prefix}confirm-email";

        }

        public static class Authorization
        {
            public const string Prefix = $"{Rule}authorization/";
            public const string AddRole = $"{Prefix}create";
            public const string EditRole = $"{Prefix}update";
            public const string DeleteRole = $"{Prefix}delete" + "/{id}";
            public const string RolesList = $"{Prefix}list";
            public const string UpdateUserRoles = $"{Prefix}update-user-roles";
            public const string ManageUserClaims = $"{Prefix}" + "manage-user-claims/{userId}";
            public const string UpdateUserClaims = $"{Prefix}" + "update-user-claims";
            public const string GetById = $"{Prefix}" + "{id}";
            public const string ManageUserRoles = $"{Prefix}" + "manage-user-roles/{userId}";


        }

        public static class Email
        {
            public const string Prefix = $"{Rule}email/";
            public const string SendEmail = $"{Prefix}send-email";
        }
    }



}
