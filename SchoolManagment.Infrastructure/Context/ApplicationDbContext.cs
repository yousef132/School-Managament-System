using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Entities.Functions;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Entities.Views;
using System.Reflection;

namespace SchoolManagment.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        #region Views
        public DbSet<DepartmentStudentsCount> DepartmentStudentsCount { get; set; }
        #endregion

        #region Functions
        public DbSet<GetTop3InstructorSalariesByDept> GetTop3InstructorSalariesByDept { get; set; }
        #endregion

    }
}
