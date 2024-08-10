using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Data.Configurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(x => x.Instructor)
                .WithOne(x => x.DepartmentManage)
                .HasForeignKey<Department>(x => x.InsId)
                .OnDelete(DeleteBehavior.SetNull);


            builder.HasMany(d => d.Instructors)
                .WithOne(i => i.Department)
                .HasForeignKey(i => i.DeptId)
                .OnDelete(DeleteBehavior.SetNull);


            builder.HasMany(d => d.Students)
                    .WithOne(s => s.Department)
                    .HasForeignKey(s => s.DeptId)
                    .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(d => d.DepartmentSubjects)
                .WithOne(ds => ds.Department)
                .HasForeignKey(ds => ds.DeptId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
