using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
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
        private readonly IEncryptionProvider encryptionProvider;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            encryptionProvider = new GenerateEncryptionProvider("x7F9rK2LQm6eJpVw3YbN0zZ1A4hTc");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.UseEncryption(encryptionProvider);

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        #region Views
        public DbSet<DepartmentView> DepartmentView { get; set; }
        #endregion

        #region Functions
        public DbSet<GetTop3InstructorSalariesByDept> GetTop3InstructorSalariesByDept { get; set; }
        #endregion

    }
}
