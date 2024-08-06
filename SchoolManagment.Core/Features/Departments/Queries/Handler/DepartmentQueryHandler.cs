using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Departments.Queries.Models;
using SchoolManagment.Core.Features.Departments.Queries.Responses;
using SchoolManagment.Core.Resources;
using SchoolManagment.Data.Entities.Procedures;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Departments.Queries.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
        IRequestHandler<GetDepartmentStudentCountQuery, Response<GetDepartmentStudentCountListResponse>>,
        IRequestHandler<GetDepartmentStudentCountListQuery, Response<List<GetDepartmentStudentCountListResponse>>>
    {


        #region Fields
        private readonly IStringLocalizer<SharedResource> stringLocalizer;
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;

        #endregion


        #region Constructor
        public DepartmentQueryHandler(IStringLocalizer<SharedResource> stringLocalizer,
            IDepartmentService departmentService,
            IMapper mapper
            )
            : base(stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
            this.departmentService = departmentService;
            this.mapper = mapper;
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

        public async Task<Response<List<GetDepartmentStudentCountListResponse>>> Handle(GetDepartmentStudentCountListQuery request, CancellationToken cancellationToken)
        {
            var result = await departmentService.GetDepartmentViewData();

            var mappedResult = mapper.Map<List<GetDepartmentStudentCountListResponse>>(result);

            return Success(mappedResult);
        }

        public async Task<Response<GetDepartmentStudentCountListResponse>> Handle(GetDepartmentStudentCountQuery request, CancellationToken cancellationToken)
        {
            var result = await departmentService.GetDepartmentTotalStudents(new DepartmentTotalStudentsParam(request.DepartmentId));

            return Success(mapper.Map<GetDepartmentStudentCountListResponse>(result.FirstOrDefault()));

        }
        #endregion

    }
}
