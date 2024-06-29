using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Data.Configurations
{
	public class SubjectInstructorConfigurations : IEntityTypeConfiguration<SubjectInsturctor>
	{
		public void Configure(EntityTypeBuilder<SubjectInsturctor> builder)
		{
			builder.HasKey(x => new
			{
				x.SubId,
				x.InsId
			});

		}
	}
}
