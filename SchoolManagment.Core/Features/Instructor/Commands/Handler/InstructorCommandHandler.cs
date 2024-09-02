using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Instructor.Commands.Models;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Instructor.Commands.Handler
{
    public class InstructorCommandHandler : ResponseHandler,
        IRequestHandler<AddInstructorCommand, Response<string>>,
        IRequestHandler<DeleteInstructorCommand, Response<string>>

    {

        #region Fileds
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IInstructorService _instructorService;
        #endregion
        #region Constructors
        public InstructorCommandHandler(IStringLocalizer<SharedResource> stringLocalizer,
                                        IMapper mapper,
                                        IInstructorService instructorService) : base(stringLocalizer)
        {
            _instructorService = instructorService;
            _mapper = mapper;
            _localizer = stringLocalizer;
        }


        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Data.Entities.Instructor>(request);
            var result = await _instructorService.AddInstructorAsync(instructor, request.Image);

            return result switch
            {
                "NoImage" => BadRequest<string>(_localizer[SharedResourcesKeys.NoImage]),
                "FailedToUploadImage" => BadRequest<string>(_localizer[SharedResourcesKeys.FailedToUploadImage]),
                "FailedToAddInstructor" => BadRequest<string>(_localizer[SharedResourcesKeys.Failed]),
                _ => Success("")
            };
        }

        public async Task<Response<string>> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(request.Id);
            if (instructor == null)
                return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]);

            var result = await _instructorService.DeleteInstructor(instructor);

            return result switch
            {
                "Error" => BadRequest<string>(_localizer[SharedResourcesKeys.Failed]),
                _ => Success<string>(_localizer[SharedResourcesKeys.Success])
            };
        }
        #endregion
    }
}
