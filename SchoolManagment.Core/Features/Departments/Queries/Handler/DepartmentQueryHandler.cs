﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Departments.Queries.Models;
using SchoolManagment.Core.Features.Departments.Queries.Responses;
using SchoolManagment.Core.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Departments.Queries.Handler
{
	public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
	{


		#region Fields
		private readonly IStringLocalizer<SharedResource> stringLocalizer;
		private readonly IDepartmentService departmentService;
		private readonly IMapper mapper;

		#endregion


		#region Constructor
		public DepartmentQueryHandler(IStringLocalizer<SharedResource> stringLocalizer,
			IDepartmentService departmentService,
			IMapper mapper)
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
		#endregion

	}
}
