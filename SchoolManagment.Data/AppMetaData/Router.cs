namespace SchoolManagment.Data.AppMetaData
{
    public class Router
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Rule = $"{Root}/{Version}/";
        public static class StudentRouting
        {
            public const string Prefix = $"{Rule}student/";


            public const string List = $"{Prefix}List";
            public const string AddStudentToDepartment = $"{Prefix}add-student-to-department";
            public const string GetById = $"{Prefix}" + "{id}";
            public const string Create = $"{Prefix}" + "create";
            public const string Edit = $"{Prefix}" + "edit";
            public const string Delete = $"{Prefix}" + "delete/{id}";
            public const string Pagination = $"{Prefix}" + "pagination";


        }
        public static class Instructor
        {
            public const string Prefix = $"{Rule}instructor/";

            public const string Create = $"{Prefix}" + "create";
            public const string GetAllInstructors = $"{Prefix}" + "all-instructors";
            public const string GetById = $"{Prefix}" + "instructor-by-id/{id}";
        }
        public static class Subject
        {
            public const string Prefix = $"{Rule}subject/";

            public const string Create = $"{Prefix}" + "create";
            public const string AddToDepartment = $"{Prefix}" + "add-to-department";
            public const string Edit = $"{Prefix}" + "edit";
            public const string GetSubjectWithDepartments = $"{Prefix}" + "subject-with-departments";
            public const string AddInstructor = $"{Prefix}" + "add-instructor";
            public const string GetTopStudentInEachSubject = $"{Prefix}" + "top-student-in-each-subject";
            public const string GetSubjectsStudentsCount = $"{Prefix}" + "subjects-students-count";
            public const string Delete = $"{Prefix}" + "delete/{id}";
        }

        public static class Department
        {
            public const string Prefix = $"{Rule}department/";
            public const string GetById = $"{Prefix}" + "{id}";
            public const string Delete = $"{Prefix}" + "delete/{id}";
            public const string DepartmentStudentCountById = $"{Prefix}department-student-count-by-id" + "/{id}";
            public const string DepartmentStudentCount = $"{Prefix}department-student-count";
            public const string GetTop3InstructorByDepartment = $"{Prefix}top3-instructor-by-department";
            public const string Create = $"{Prefix}create";
            public const string Update = $"{Prefix}update";
            public const string GetDepartmentsList = $"{Prefix}departments-list";

        }

        public static class ApplicationUserRouting
        {
            public const string Prefix = $"{Rule}user/";
            public const string Create = $"{Prefix}create";
            public const string Delete = $"{Prefix}delete";
            public const string ChangePassword = $"{Prefix}change-password";
            public const string Edit = $"{Prefix}edit";
            public const string List = $"{Prefix}list";
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
            public const string AddRole = $"{Prefix}add-role";
            public const string EditRole = $"{Prefix}edit-role";
            public const string DeleteRole = $"{Prefix}delete-role" + "/{id}";
            public const string RolesList = $"{Prefix}roles-list";
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
