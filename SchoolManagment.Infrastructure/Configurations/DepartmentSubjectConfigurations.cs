using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Data.Configurations
{
	public class DepartmentSubjectConfigurations : IEntityTypeConfiguration<DepartmentSubject>
	{
		public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
		{
			builder.HasOne(d => d.Department)
				.WithMany(d => d.DepartmentSubjects)
				.HasForeignKey(d => d.DeptId);

			builder.HasOne(d => d.Subject)
				.WithMany(d => d.DepartmentSubjects)
				.HasForeignKey(d => d.SubId);

			builder.HasKey(x => new
			{
				x.SubId,
				x.DeptId
			});

		}
	}
}
