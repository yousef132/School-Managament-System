using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Core.Features.Students.Commands.Handler
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentCommand, Response<string>>,
        IRequestHandler<AddStudentToDepartmentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResource> localizer;
        #endregion

        #region Constructor
        public StudentCommandHandler(IStudentService studentService,
            IMapper mapper,
            IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {
            this.studentService = studentService;
            this.mapper = mapper;
            this.localizer = stringLocalizer;
        }
        #endregion


        #region Fuction
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = mapper.Map<Student>(request);

            string result = await studentService.AddAsync(student);

            if (result == "Success")
                return Created(result);

            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // check for student existence
            var student = await studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<string>("No Student With This Id");

            // map from request to student model
            var mappedStudent = mapper.Map(request, student);

            // call update service

            var result = await studentService.EditStudentAsync(mappedStudent);

            if (result == "Success")
                return Success("Edit Successfully");

            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<string>($"Student with Id {request.Id} Not Found");

            var res = await studentService.DeleteStudentAsync(student);

            if (res == "Success")
                return Deleted<string>("Deleted Successfully");

            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(AddStudentToDepartmentCommand request, CancellationToken cancellationToken)
        {
            var result = await studentService.AddStudentToDepartment(request.StudentId, request.DepartmentId);

            return result switch
            {
                "StudentNotFound" => NotFound<string>(localizer[SharedResourcesKeys.NotFound]),
                "DepartmentNotFound" => NotFound<string>(localizer[SharedResourcesKeys.NotFound]),
                "StudentAlreadyInDepartment" => NotFound<string>(localizer[SharedResourcesKeys.StudentAlreadyInDepartment]),
                "Failed" => NotFound<string>(localizer[SharedResourcesKeys.Failed]),
                _ => Success("")
            };
        }
        #endregion

    }
}
