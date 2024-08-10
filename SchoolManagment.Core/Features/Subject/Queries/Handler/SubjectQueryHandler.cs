using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Subject.Queries.Models;
using SchoolManagment.Core.Features.Subject.Responses;
using SchoolManagment.Data.Resources;
using SchoolManagment.Data.Responses;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Subject.Queries.Handler
{
    internal class SubjectQueryHandler : ResponseHandler,
        IRequestHandler<GetSubjectWithDepartmentsQuery, Response<IReadOnlyList<GetSubjectWithDepartments>>>,
        IRequestHandler<GetNumberOfStudentsForSubjectsQuery, Response<IReadOnlyList<GetNumberOfStudentsForSubjectResponse>>>,
        IRequestHandler<GetTopStudentInEachSubjectQuery, Response<IReadOnlyList<GetTopStudentInEachSubjectResponse>>>

    {

        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly ISubjectService subjectService;
        private readonly IMapper mapper;
        public SubjectQueryHandler(IStringLocalizer<SharedResource> localizer,
                                     ISubjectService subjectService,
                                     IMapper mapper) : base(localizer)
        {
            this.localizer = localizer;
            this.subjectService = subjectService;
            this.mapper = mapper;
        }
        public async Task<Response<IReadOnlyList<GetSubjectWithDepartments>>> Handle(GetSubjectWithDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var subjects = await subjectService.GetAllSubjectsIncludingDepartments();
            var mappedResult = mapper.Map<IReadOnlyList<GetSubjectWithDepartments>>(subjects);
            return Success(mappedResult);
        }

        public async Task<Response<IReadOnlyList<GetNumberOfStudentsForSubjectResponse>>> Handle(GetNumberOfStudentsForSubjectsQuery request, CancellationToken cancellationToken)
        {
            var result = await subjectService.GetNumberOfStudentsForSubjects();
            return Success(result);
        }

        public async Task<Response<IReadOnlyList<GetTopStudentInEachSubjectResponse>>> Handle(GetTopStudentInEachSubjectQuery request, CancellationToken cancellationToken)
        {
            var result = await subjectService.GetTopStudentInEachSubject();
            return Success(result);
        }
    }
}
