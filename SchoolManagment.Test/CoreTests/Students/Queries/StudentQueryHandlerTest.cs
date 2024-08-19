using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolManagment.Core.Features.Students.Queries.Handler;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Core.Mapping.Students;
using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Resources;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Test.CoreTests.Students.Queries
{
    public class StudentQueryHandlerTest
    {
        private readonly Mock<IStudentService> studentService;
        private readonly IMapper mapper;
        private readonly Mock<IStringLocalizer<SharedResource>> stringLocalizer;
        private readonly Mock<ILogger<StudentQueryHandler>> loggerr;
        private readonly StudentProfile studentProfile;

        public StudentQueryHandlerTest()
        {
            studentProfile = new StudentProfile();
            studentService = new();
            stringLocalizer = new();
            loggerr = new();
            var mappingConfigs = new MapperConfiguration(c => c.AddProfile(studentProfile));
            mapper = new Mapper(mappingConfigs);
        }

        [Fact]
        public async Task GetStudents_WhenListIsNotNullOrEmpty_ShouldReturnCorrectList()
        {
            // Arrange
            // faking that student list is empty
            studentService.Setup(x => x.GetStudentsAsync()).ReturnsAsync(new List<Student>()
            {
                new Student
                {
                    DeptId = 1,
                    StudId = 2,
                    NameAr = "على",
                    NameEn = "ali",
                }
            });

            var query = new GetStudentsQuery();
            var handler = new StudentQueryHandler(studentService.Object, mapper, stringLocalizer.Object, loggerr.Object);


            // Act 
            var result = await handler.Handle(query, default);

            // Assert 
            result.Data.Should().NotBeNullOrEmpty();

        }
    }
}
