using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Subject.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Subject.Commands.Handler
{
    public class SubjectCommandHandler : ResponseHandler,
        IRequestHandler<AddSubjectCommand, Response<string>>,
        IRequestHandler<EditSubjectCommand, Response<string>>,
        IRequestHandler<AddSubjectToDepartmentCommand, Response<string>>,
        IRequestHandler<DeleteSubjectCommand, Response<string>>,
        IRequestHandler<AddInstructorToSubjectCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly ISubjectService subjectService;
        private readonly IMapper mapper;
        private readonly IDepartmentService departmentService;

        public SubjectCommandHandler(IStringLocalizer<SharedResource> localizer,
                                     ISubjectService subjectService,
                                     IMapper mapper,
                                     IDepartmentService departmentService) : base(localizer)
        {
            this.localizer = localizer;
            this.subjectService = subjectService;
            this.mapper = mapper;
            this.departmentService = departmentService;
        }
        public async Task<Response<string>> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            var mappedSubject = mapper.Map<Data.Entities.Subject>(request);
            var result = await subjectService.AddSubject(mappedSubject);

            return result switch
            {
                true => Success(""),
                _ => BadRequest<string>(localizer[SharedResourcesKeys.Failed])
            };
        }

        public async Task<Response<string>> Handle(EditSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await subjectService.GetSubjectById(request.SubjectId);
            if (subject == null)
                return BadRequest<string>(localizer[SharedResourcesKeys.NotFound]);

            var mappedSubject = mapper.Map(request, subject);

            var result = await subjectService.EditSubject(mappedSubject);

            return result switch
            {
                false => BadRequest<string>(localizer[SharedResourcesKeys.Failed]),
                _ => Success<string>(localizer[SharedResourcesKeys.Edited])
            };
        }

        public async Task<Response<string>> Handle(AddSubjectToDepartmentCommand request, CancellationToken cancellationToken)
        {
            var result = await subjectService.AddSubjectToDepartment(request.SubjectId, request.DepartmentId);

            return result switch
            {
                false => BadRequest<string>(localizer[SharedResourcesKeys.Failed]),
                _ => Success("")
            };
        }

        public async Task<Response<string>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await subjectService.GetSubjectById(request.Id); ;
            if (subject == null)
                return BadRequest<string>(localizer[SharedResourcesKeys.NotFound]);
            var result = await subjectService.DeleteSubject(subject);

            return result switch
            {
                false => BadRequest<string>(localizer[SharedResourcesKeys.Failed]),
                _ => Success("")
            };
        }

        public async Task<Response<string>> Handle(AddInstructorToSubjectCommand request, CancellationToken cancellationToken)
        {
            var result = await subjectService.AddInstructorToSubject(request.SubjectId, request.InstructorId);

            return result switch
            {
                false => BadRequest<string>(localizer[SharedResourcesKeys.Failed]),
                _ => Success("")
            };
        }
    }




}
