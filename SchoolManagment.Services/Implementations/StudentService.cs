using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.InfrastructureBases;
using SchoolManagment.Infrastructure.Specifications.Student;
using SchoolManagment.Services.Abstracts;
using Serilog;

namespace SchoolManagment.Services.Implementations
{
    public class StudentService : IStudentService
    {

        #region Fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public StudentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Functions
        public async Task<List<Student>> GetStudentsAsync()
        => await unitOfWork.Repository<Student>().GetTableAsNotTracked().Include(s => s.Department).ToListAsync();
        public async Task<Student> GetStudentByIdAsync(int id)
            => await unitOfWork.Repository<Student>()
                    .GetTableAsNotTracked()
                    .FirstOrDefaultAsync(s => s.StudId == id) ?? new();



        public async Task<string> AddAsync(Student student)
        {
            await unitOfWork.Repository<Student>().AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameEnExist(string name)
        {
            // check if nameEn exist or not 
            bool exist = unitOfWork.Repository<Student>().GetTableAsNotTracked().Any(s => s.NameEn == name);
            return exist ? true : false;
        }
        public async Task<bool> IsNameArExist(string name)
        {
            // check if nameAr exist or not 
            bool exist = unitOfWork.Repository<Student>().GetTableAsNotTracked().Any(s => s.NameAr == name);
            return exist ? true : false;
        }

        public async Task<bool> IsNameEnExistExcludeItself(string name, int id)
        {
            bool exist = unitOfWork.Repository<Student>()
                         .GetTableAsNotTracked()
                         .Any(s => s.NameEn == name && !s.StudId.Equals(id));
            return exist ? true : false;


        }
        public async Task<bool> IsNameArExistExcludeItself(string name, int id)
        {
            bool exist = unitOfWork.Repository<Student>()
                         .GetTableAsNotTracked()
                         .Any(s => s.NameAr == name && !s.StudId.Equals(id));
            return exist ? true : false;

        }

        public async Task<string> EditStudentAsync(Student student)
        {
            await unitOfWork.Repository<Student>().UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteStudentAsync(Student student)
        {

            var transaction = unitOfWork.Repository<Student>().BeginTransaction();
            try
            {
                await unitOfWork.Repository<Student>().DeleteAsync(student);
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

            var result = await unitOfWork.Repository<Student>().GetAllWithSpecification(specs);

            return result;
        }
        public async Task<Student> GetStudentByIdWithSpecificationsAsync(int id)
        {
            var specs = new StudentsWithSpecifications(id);
            var students = await unitOfWork.Repository<Student>().GetByIdWithSpecification(specs);
            return students;
        }

        public async Task<string> AddStudentToDepartment(int studentId, int departmentId)
        {
            try
            {

                var student = await unitOfWork.Repository<Student>().GetTableAsTracked().FirstOrDefaultAsync(s => s.StudId == studentId);
                if (student == null)
                    return "StudentNotFound";
                var department = await unitOfWork.Repository<Department>().GetTableAsNotTracked().FirstOrDefaultAsync(d => d.DeptId == departmentId);
                if (department == null)
                    return "DepartmentNotFound";

                if (student.DeptId is not null)
                    return "StudentAlreadyInDepartment";

                student.DeptId = departmentId;

                await unitOfWork.Repository<Student>().SaveChangesAsync();

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
