using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using System.Reflection;

namespace SchoolManagment.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
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
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<StudentSubject> StudentSubjects { get; set; }
		public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }

	}
}
