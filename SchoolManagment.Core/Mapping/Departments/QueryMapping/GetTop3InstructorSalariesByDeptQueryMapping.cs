using SchoolManagment.Core.Features.Departments.Queries.Responses;
using SchoolManagment.Data.Entities.Functions;

namespace SchoolManagment.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetTop3InstructorSalariesByDeptQueryMapping()
        {
            CreateMap<GetTop3InstructorSalariesByDept, InstructorsSalaryDto>()
                .ForMember(dest => dest.Instructors, opt => opt.MapFrom(src => new List<InstructorsSalaryDto.InstructorDto> { new InstructorsSalaryDto.InstructorDto
            {
                InstructorId = src.InstructorId,
                InstructorNameEn = src.InstructorNameEn,
                InstructorNameAr = src.InstructorNameAr,
                Salary = src.Salary,
                RowNumber = src.rn
            }}));

            CreateMap<GetTop3InstructorSalariesByDept, InstructorsSalaryDto.InstructorDto>()
                .ForMember(dest => dest.RowNumber, opt => opt.MapFrom(src => src.rn));

        }



    }

}
