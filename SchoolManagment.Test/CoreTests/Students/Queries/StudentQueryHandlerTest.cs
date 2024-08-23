using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolManagment.Core.Features.Students.Queries.Handler;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Core.Features.Students.Queries.Responses;
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
        private readonly Mock<ILogger<StudentQueryHandler>> logger;
        private readonly StudentProfile studentProfile;

        public StudentQueryHandlerTest()
        {
            studentProfile = new StudentProfile();
            studentService = new();
            stringLocalizer = new();
            logger = new();
            var mappingConfigs = new MapperConfiguration(c => c.AddProfile(studentProfile));
            mapper = new Mapper(mappingConfigs);
        }

        #region Testing

        [Fact]
        public async Task HandleStudentList_WhenListIsNotNullOrEmpty_ShouldReturnCorrectList()
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
            var handler = new StudentQueryHandler(studentService.Object, mapper, stringLocalizer.Object, logger.Object);
            // Act 
            var result = await handler.Handle(query, default);

            // Assert 
            result.Data.Should().NotBeNullOrEmpty();
            result.Data.Should().BeOfType<List<GetStudentsResponse>>();
        }


        [Theory]
        [InlineData(39045)]
        public async Task HandleGetStudentById_WhenStudentNotFound_ShouldReturn404StatusCode(int id)
        {
            // Arrange
            var studentList = new List<Student>()
           {
                 new Student
                 {
                    DeptId = 1,
                    StudId = 2,
                    NameAr = "على",
                    NameEn = "ali",
                 },
                 new Student
                 {
                    DeptId = 1,
                    StudId = 3124,
                    NameAr = "على",
                    NameEn = "mohamed",
                    Department = new Department()
                    {
                        DeptId = 2,
                        NameEn = "cs"
                    }
                 }
           };



            studentService.Setup(s => s.GetStudentByIdWithSpecificationsAsync(id))
                        .Returns(Task.FromResult(studentList.FirstOrDefault(s => s.StudId == id)));


            var query = new GetStudentByIdQuery(id);
            var handler = new StudentQueryHandler(studentService.Object, mapper, stringLocalizer.Object, logger.Object);


            // Act 
            var result = await handler.Handle(query, default);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData(3124)]
        public async Task HandleGetStudentById_WhenStudentFound_ShouldReturn200StatusCode(int id)
        {
            // Arrange 
            var studentList = new List<Student>()
            {
                 new Student
                 {
                    DeptId = 1,
                    StudId = 2,
                    NameAr = "على",
                    NameEn = "ali",
                 },
                 new Student
                 {
                    DeptId = 1,
                    StudId = 3124,
                    NameAr = "على",
                    NameEn = "mohamed",
                    Department = new Department()
                    {
                        DeptId = 2,
                        NameEn = "cs"
                    }
                 }
            };

            studentService.Setup(s => s.GetStudentByIdWithSpecificationsAsync(id))
                        .Returns(Task.FromResult(studentList.FirstOrDefault(s => s.StudId == id)));
            var query = new GetStudentByIdQuery(id);
            var handler = new StudentQueryHandler(studentService.Object, mapper, stringLocalizer.Object, logger.Object);


            // Act 
            var result = await handler.Handle(query, default);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
        #endregion
    }
}
