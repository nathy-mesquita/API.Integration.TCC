using API.Integration.TCC.Application.Commands.CreateTeacher;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using API.Integration.TCC.Domain.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace UnitTests.Aplication.Command
{
    public class CreateTeacherHandlerTests
    {
        [Fact(DisplayName = "Dado a criação de um aluno, quando executado, retornar um aluno válido diferente de nulo.")]
        [Trait("CreateStudentComment", "Handle")]
        public async void InputCreateStudentComment_Executed_ReturNotNull()
        {
            //Arrange
            var repositoryMock = new Mock<ITeacherRepository>();
            var authServiceMock = new Mock<IAuthService>();
            var loggerMock = new Mock<ILogger<CreateTeacherHandler>>();
            var createTeacherCommand = new CreateTeacherCommand
            {
                FullName = "Nome completo",
                Email = "nome@email.com",
                Password = "Abcd@1234",
                BirthDate = CreateRandomBirthDate(),
                Specialty = "Especialidade",
                SubjectsTaught = "Disciplina de algoritmos"

            };
            var createTeacherHandler = new CreateTeacherHandler(repositoryMock.Object, authServiceMock.Object, loggerMock.Object);

            //Act
            var result = await createTeacherHandler.Handle(createTeacherCommand, CancellationToken.None);


            //Assert
            Assert.True(result >= 0);
            repositoryMock.Verify(r => r.AddAsync(It.IsAny<Teacher>()), Times.Once);

        }

        #region Métodos auxiliares
        private static DateTime CreateRandomBirthDate()
        {
            DateTime start = new DateTime(1997, 1, 1);
            Random gen = new Random();
            int range = (DateTime.Today - start).Days;

            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
        #endregion
    }
}