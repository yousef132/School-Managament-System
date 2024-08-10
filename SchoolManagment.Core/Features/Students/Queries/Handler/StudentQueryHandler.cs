using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Core.Features.Students.Queries.Responses;
using SchoolManagment.Data.Resources;
using SchoolManagment.Infrastructure.Specifications.Student;
using SchoolManagment.Services.Abstracts;
using Serilog;

namespace SchoolManagment.Core.Features.Students.Queries.Handler
{
    // GetStudentsQuery =>  request  , List<Student> =>  response type
    // Handle All Student's Requests
    // Many Request Handled By One Handler
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<GetStudentsQuery, Response<List<GetStudentsResponse>>>,
        IRequestHandler<GetStudentsWithPaginationQuery, Response<PaginatedResult<GetSingleStudentResponse>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>
    {

        #region Fields
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResource> stringLocalizer;
        private readonly ILogger<StudentQueryHandler> loggerr;

        #endregion

        #region Constructor
        public StudentQueryHandler(IStudentService studentService,
            IMapper mapper,
            IStringLocalizer<SharedResource> stringLocalizer,
            ILogger<StudentQueryHandler> loggerr)
            : base(stringLocalizer)
        {
            this.studentService = studentService;
            this.mapper = mapper;
            this.stringLocalizer = stringLocalizer;
            this.loggerr = loggerr;
        }
        #endregion

        #region Handler Function

        // methods invoked to handle the request
        // Department not included
        public async Task<Response<List<GetStudentsResponse>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await studentService.GetStudentsAsync();

            var mappedStudents = mapper.Map<List<GetStudentsResponse>>(students);

            Log.Information("Get students from handler", students.Count());

            return Success(mappedStudents, new { Count = mappedStudents.Count() });
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await studentService.GetStudentByIdWithSpecificationsAsync(request.Id);
            string s = stringLocalizer[SharedResourcesKeys.Required];
            if (student == null)
                return NotFound<GetSingleStudentResponse>(s);
            var mappedStudent = mapper.Map<GetSingleStudentResponse>(student);

            return Success(mappedStudent);
        }

        // Department is included
        public async Task<Response<PaginatedResult<GetSingleStudentResponse>>>
            Handle(GetStudentsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var mappedSpecs = mapper.Map<StudentSpecification>(request);
            var students = await studentService.GetStudentsWithSpecificationsAsync(mappedSpecs);
            // Exception
            var mappedStudents = mapper.Map<List<GetSingleStudentResponse>>(students);
            var paginatedList = new PaginatedResult<GetSingleStudentResponse>(request.PageIndex, request.PageSize, mappedStudents);
            return Success(paginatedList, new { Count = paginatedList.Data.Count() });
        }
        #endregion
    }
}