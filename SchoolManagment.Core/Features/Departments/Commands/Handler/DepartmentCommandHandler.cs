using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Departments.Commands.Models;
using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Departments.Commands.Handler
{
    internal class DepartmentCommandHandler : ResponseHandler,
        IRequestHandler<CreateDepartmentCommand, Response<string>>,
        IRequestHandler<DeleteDepartmentCommand, Response<string>>,
        IRequestHandler<UpdateDepartmentCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IMapper mapper;
        private readonly IDepartmentService departmentService;
        private readonly IInstructorService instructorService;

        public DepartmentCommandHandler(IStringLocalizer<SharedResource> localizer,
                                        IMapper mapper,
                                        IDepartmentService departmentService,
                                        IInstructorService instructorService) : base(localizer)
        {
            this.localizer = localizer;
            this.mapper = mapper;
            this.departmentService = departmentService;
            this.instructorService = instructorService;
        }
        public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var result = await departmentService.DeleteDepartmentAsync(request.DepartmentId);
            return result switch
            {
                "DepartmentNotFound" => NotFound<string>(localizer[SharedResourcesKeys.NotFound]),
                "Failed" => NotFound<string>(localizer[SharedResourcesKeys.Failed]),
                _ => Success<string>(localizer[SharedResourcesKeys.Success])
            };
        }

        public async Task<Response<string>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var mappedDepartment = mapper.Map<Department>(request);

            var result = await departmentService.CreateDepartment(mappedDepartment);
            return result switch
            {
                "Failed" => NotFound<string>(localizer[SharedResourcesKeys.Failed]),
                _ => Success<string>(localizer[SharedResourcesKeys.Success])
            };
        }

        public async Task<Response<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await departmentService.GetDepartmentByIdWithoutIncludes(request.DepartmentId);

            if (department == null)
                return NotFound<string>(localizer[SharedResourcesKeys.NotFound]);


            var mappedDepartment = mapper.Map(request, department);

            var result = await departmentService.EditDepartment(mappedDepartment);

            return result switch
            {
                "Failed" => NotFound<string>(localizer[SharedResourcesKeys.Failed]),
                _ => Success<string>(localizer[SharedResourcesKeys.Success])
            };
        }
    }
}
