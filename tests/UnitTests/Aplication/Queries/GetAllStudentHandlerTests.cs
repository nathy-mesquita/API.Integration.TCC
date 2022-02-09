using API.Integration.TCC.Application.Queries.GetAllStudent;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Aplication.Queries
{
    public class GetAllStudentHandlerTests
    {
        [Fact(DisplayName = "Dado que quatro alunos existem, quando consultados, retornar quatro alunos.")]
        [Trait("GetAllStudent", "Handler")]
        public async Task FourStudentExist_Fetched_ReturnFourStudentViewModels()
        {
            //Arrange
            var students = new List<Student>()
            {
                new Student(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), GetRandomCouse(), CreateRandomBirthDate()),
                new Student(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), GetRandomCouse(), CreateRandomBirthDate()),
                new Student(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), GetRandomCouse(), CreateRandomBirthDate()),
                new Student(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), GetRandomCouse(), CreateRandomBirthDate()),

            };

            var repositoryMock = new Mock<IStudentRepository>();
            var loggerMock = new Mock<ILogger<GetAllStudentHandler>>();

            repositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(students);

            var getAllStudentQuery = new GetAllStudentQuery("");
            var getAllStudentHandler = new GetAllStudentHandler(repositoryMock.Object, loggerMock.Object);

            //Act
            var studentViewModelList = await getAllStudentHandler.Handle(getAllStudentQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(studentViewModelList);
            Assert.NotEmpty(studentViewModelList);
            Assert.Equal(students.Count, studentViewModelList.Count);

            repositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
        #region Métodos auxiliares
        private static readonly string[] _fullNames = new string[]
        {
            "Ana Julia", "Maria Beatriz", "João Pedro", "Carlos Alberto", "Dolores Albergues"
        };

        private static readonly string[] _emails = new string[]
        {
            "ab@email.com", "cd@email.com", "ef@email.com", "gh@email.com", "ij@email.com"
        };

        private static readonly string[] _passwords = new string[]
        {
            "Abcd@1234", "Senha@1234"
        };

        private static readonly string[] _course = new string[]
        {
            "Engenharia de Computação", "Desing", "Pedagogia", "Odontoligia", "Enfermagem"
        };
        private static DateTime CreateRandomBirthDate()
        {
            DateTime start = new DateTime(1997, 1, 1);
            Random gen = new Random();
            int range = (DateTime.Today - start).Days;

            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
        private static string GetRandomFullName()
        {
            var rnd = new Random();
            var start = rnd.Next(0, _fullNames.Length);
            return _fullNames[start];
        }
        private static string GetRandomEmail()
        {
            var rnd = new Random();
            var start = rnd.Next(0, _emails.Length);
            return _emails[start];
        }
        private static string GetRandomPassword()
        {
            var rnd = new Random();
            var start = rnd.Next(0, _passwords.Length);
            return _passwords[start];
        }
        private static string GetRandomCouse()
        {
            var rnd = new Random();
            var start = rnd.Next(0, _course.Length);
            return _course[start];
        }
        #endregion
    }
}