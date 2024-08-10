using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Departments.Queries.Models;
using SchoolManagment.Core.Features.Departments.Queries.Responses;
using SchoolManagment.Data.Entities.Functions;
using SchoolManagment.Data.Entities.Procedures;
using SchoolManagment.Data.Resources;
using SchoolManagment.Infrastructure.Abstracts.Functions;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Departments.Queries.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
        IRequestHandler<GetDepartmentStudentCountQuery, Response<GetDepartmentStudentCountListResponse>>,
        IRequestHandler<GetTop3InstructorSalariesByDeptQuery, Response<IReadOnlyList<InstructorsSalaryDto>>>,
        IRequestHandler<GetDepartmentStudentCountListQuery, Response<IReadOnlyList<GetDepartmentStudentCountListResponse>>>,
        IRequestHandler<GetAllDepartmentsQuery, Response<IReadOnlyList<GetAllDepartmentsResponse>>>
    {


        #region Fields
        private readonly IStringLocalizer<SharedResource> stringLocalizer;
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;
        private readonly IDepartmentGetTop3SalariesRepository departmentGetTop3SalariesRepository;

        #endregion


        #region Constructor
        public DepartmentQueryHandler(IStringLocalizer<SharedResource> stringLocalizer,
            IDepartmentService departmentService,
            IMapper mapper,
            IDepartmentGetTop3SalariesRepository departmentGetTop3SalariesRepository)
            : base(stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
            this.departmentService = departmentService;
            this.mapper = mapper;
            this.departmentGetTop3SalariesRepository = departmentGetTop3SalariesRepository;
        }
        #endregion


        #region Handlers
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await departmentService.GetDepartmentById(request.Id);

            if (department == null)
                return NotFound<GetDepartmentByIdResponse>(stringLocalizer[SharedResourcesKeys.NotFound]);
            var mappedDepartment = mapper.Map<GetDepartmentByIdResponse>(department);

            return Success(mappedDepartment);
        }

        public async Task<Response<IReadOnlyList<GetDepartmentStudentCountListResponse>>> Handle(GetDepartmentStudentCountListQuery request, CancellationToken cancellationToken)
        {
            var result = await departmentService.GetDepartmentViewData();

            var mappedResult = mapper.Map<IReadOnlyList<GetDepartmentStudentCountListResponse>>(result);

            return Success(mappedResult);
        }

        public async Task<Response<GetDepartmentStudentCountListResponse>> Handle(GetDepartmentStudentCountQuery request, CancellationToken cancellationToken)
        {
            var result = await departmentService.GetDepartmentTotalStudents(new DepartmentTotalStudentsParam(request.DepartmentId));

            return Success(mapper.Map<GetDepartmentStudentCountListResponse>(result.FirstOrDefault()));

        }

        public async Task<Response<IReadOnlyList<InstructorsSalaryDto>>> Handle(GetTop3InstructorSalariesByDeptQuery request, CancellationToken cancellationToken)
        {
            var result = await departmentGetTop3SalariesRepository.GetTop3Salaries();

            // TODO : Mapping Error
            var mappedResult = MapFunctionResult(result);

            return Success(mappedResult);
        }

        public async Task<Response<IReadOnlyList<GetAllDepartmentsResponse>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await departmentService.GetAllDepartmentsAsync();
            var mappedDepartments = mapper.Map<IReadOnlyList<GetAllDepartmentsResponse>>(result);
            return Success(mappedDepartments);
        }
        #endregion


        #region Helper
        private IReadOnlyList<InstructorsSalaryDto> MapFunctionResult(List<GetTop3InstructorSalariesByDept> lst)
        {
            var result = lst.GroupBy(item => new { item.DepartmentId, item.DepartmentNameEn, item.DepartmentNameAr })
                .Select(group => new InstructorsSalaryDto()
                {
                    DepartmentId = group.Key.DepartmentId,
                    DepartmentNameEn = group.Key.DepartmentNameEn,
                    DepartmentNameAr = group.Key.DepartmentNameAr,
                    Instructors = group.Select(instructor => new InstructorsSalaryDto.InstructorDto()
                    {
                        InstructorId = instructor.InstructorId,
                        InstructorNameEn = instructor.InstructorNameEn,
                        InstructorNameAr = instructor.InstructorNameAr,
                        Salary = instructor.Salary,
                        RowNumber = instructor.rn
                    }).ToList()
                }).ToList();

            return result;
        }
        #endregion


    }
}
