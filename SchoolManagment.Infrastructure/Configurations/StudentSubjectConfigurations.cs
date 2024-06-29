using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagment.Data.Entities;
namespace SchoolManagment.Data.Configurations
{
	public class StudentSubjectConfigurations : IEntityTypeConfiguration<StudentSubject>
	{
		public void Configure(EntityTypeBuilder<StudentSubject> builder)
		{
			builder.HasKey(x => new
			{
				x.SubId,
				x.StudId
			});

		}
	}
}
