using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Instructor.Queries.Models;
using SchoolManagment.Core.Features.Instructor.Queries.Response;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Instructor.Queries.Handler
{
    internal class InstructorQueryHandler : ResponseHandler,
        IRequestHandler<GetAllInstructorsQuery, Response<IReadOnlyList<GetInstructorResponse>>>,
        IRequestHandler<GetInstructorByIdQuery, Response<GetInstructorResponse>>
    {
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IInstructorService instructorService;
        private readonly IMapper mapper;

        public InstructorQueryHandler(IStringLocalizer<SharedResource> localizer,
                                      IInstructorService instructorService,
                                      IMapper mapper) : base(localizer)
        {
            this.localizer = localizer;
            this.instructorService = instructorService;
            this.mapper = mapper;
        }
        public async Task<Response<GetInstructorResponse>> Handle(GetInstructorByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await instructorService.GetInstructorByIdAsync(request.Id);
            if (result == null)
                return BadRequest<GetInstructorResponse>(localizer[SharedResourcesKeys.NotFound]);

            var mappedResult = mapper.Map<GetInstructorResponse>(result);

            return Success(mappedResult);
        }

        public async Task<Response<IReadOnlyList<GetInstructorResponse>>> Handle(GetAllInstructorsQuery request, CancellationToken cancellationToken)
        {
            var result = await instructorService.GetAllInstructorsAsync();
            var mappedResult = mapper.Map<IReadOnlyList<GetInstructorResponse>>(result);
            return Success(mappedResult);
        }
    }
}
