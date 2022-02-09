using API.Integration.TCC.Application.Queries.GetAllTeacher;
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
    public class GetAllTeacherHandlerTests
    {
        [Fact(DisplayName = "Dado que cinco professores existem, quando consultados, retornar cinco professores.")]
        [Trait("GetAllTeacher", "Handler")]
        public async Task FiveTeachersExist_Fetched_ReturnFiveTeachersViewModels()
        {
            //Arrange
            var teachers = new List<Teacher>()
            {
                new Teacher(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), CreateRandomBirthDate(), GetRandomSpecialty(), GetRandomSubjectsTaught() ),
                new Teacher(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), CreateRandomBirthDate(), GetRandomSpecialty(), GetRandomSubjectsTaught() ),
                new Teacher(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), CreateRandomBirthDate(), GetRandomSpecialty(), GetRandomSubjectsTaught() ),
                new Teacher(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), CreateRandomBirthDate(), GetRandomSpecialty(), GetRandomSubjectsTaught() ),
                new Teacher(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), CreateRandomBirthDate(), GetRandomSpecialty(), GetRandomSubjectsTaught() ),
            };

            var repositoryMock = new Mock<ITeacherRepository>();
            var loggerMock = new Mock<ILogger<GetAllTeacherHandler>>();

            repositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(teachers);

            var getAllTeacherQuery = new GetAllTeacherQuery("");
            var getAllTeacherHandler = new GetAllTeacherHandler(repositoryMock.Object, loggerMock.Object);

            //Act
            var teacherViewModelList = await getAllTeacherHandler.Handle(getAllTeacherQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(teacherViewModelList);
            Assert.NotEmpty(teacherViewModelList);
            Assert.Equal(teachers.Count, teacherViewModelList.Count);

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

        private static readonly string[] _specialitys = new string[]
        {
            "Computação em nuvem", "Desing de interiores", "Pediatria", "Ortodontia", "Intrumentação"
        };

        private static readonly string[] _subjectsTaughts = new string[]
        {
            "Computação aplicada", "Desenho técnico", "Introdução a pediatria", "Introdução a ortodontia", "Intrumentação cirurgica"
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
        private static string GetRandomSpecialty()
        {
            var rnd = new Random();
            var start = rnd.Next(0, _specialitys.Length);
            return _specialitys[start];
        }
        private static string GetRandomSubjectsTaught()
        {
            var rnd = new Random();
            var start = rnd.Next(0, _subjectsTaughts.Length);
            return _subjectsTaughts[start];
        }
        #endregion
    }
}