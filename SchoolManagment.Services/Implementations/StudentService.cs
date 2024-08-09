using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Specifications.Student;
using SchoolManagment.Services.Abstracts;
using Serilog;

namespace SchoolManagment.Services.Implementations
{
    public class StudentService : IStudentService
    {

        #region Fields
        private readonly IStudentRepository studentRepository;
        private readonly IDepartmentRepository departmentRepository;
        #endregion

        #region Constructor
        public StudentService(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            this.studentRepository = studentRepository;
            this.departmentRepository = departmentRepository;
        }
        #endregion

        #region Functions
        public async Task<List<Student>> GetStudentsAsync()
        => await studentRepository.GetStudentsAsync();
        public async Task<Student> GetStudentByIdAsync(int id)
            => await studentRepository
                    .GetTableAsNotTracked()
                    .FirstOrDefaultAsync(s => s.StudId == id) ?? new();



        public async Task<string> AddAsync(Student student)
        {
            await studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameEnExist(string name)
        {
            // check if nameEn exist or not 
            bool exist = studentRepository.GetTableAsNotTracked().Any(s => s.NameEn == name);
            return exist ? true : false;
        }
        public async Task<bool> IsNameArExist(string name)
        {
            // check if nameAr exist or not 
            bool exist = studentRepository.GetTableAsNotTracked().Any(s => s.NameAr == name);
            return exist ? true : false;
        }

        public async Task<bool> IsNameEnExistExcludeItself(string name, int id)
        {
            bool exist = studentRepository
                         .GetTableAsNotTracked()
                         .Any(s => s.NameEn == name && !s.StudId.Equals(id));
            return exist ? true : false;


        }
        public async Task<bool> IsNameArExistExcludeItself(string name, int id)
        {
            bool exist = studentRepository
                         .GetTableAsNotTracked()
                         .Any(s => s.NameAr == name && !s.StudId.Equals(id));
            return exist ? true : false;

        }

        public async Task<string> EditStudentAsync(Student student)
        {
            await studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteStudentAsync(Student student)
        {

            var transaction = studentRepository.BeginTransaction();
            try
            {
                await studentRepository.DeleteAsync(student);
                transaction.Commit();
                return "Success";

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<List<Student>> GetStudentsWithSpecificationsAsync(StudentSpecification inputSpecs)
        {
            var specs = new StudentsWithSpecifications(inputSpecs);

            var result = await studentRepository.GetAllWithSpecification(specs);

            return result;
        }

        public async Task<Student> GetStudentByIdWithSpecificationsAsync(int id)
        {
            var specs = new StudentsWithSpecifications(id);
            var students = await studentRepository.GetByIdWithSpecification(specs);
            return students;
        }

        public async Task<string> AddStudentToDepartment(int studentId, int departmentId)
        {
            try
            {

                var student = await studentRepository.GetTableAsTracked().FirstOrDefaultAsync(s => s.StudId == studentId);
                if (student == null)
                    return "StudentNotFound";
                var department = await departmentRepository.GetTableAsNotTracked().FirstOrDefaultAsync(d => d.DeptId == departmentId);
                if (department == null)
                    return "DepartmentNotFound";

                if (student.DeptId is not null)
                    return "StudentAlreadyInDepartment";

                student.DeptId = departmentId;

                await studentRepository.SaveChangesAsync();

                return "Success";
            }
            catch (Exception ex)
            {
                Log.Error("Failed To Add Student To Department");
                return "Failed";
            }


        }
        #endregion



    }
}
