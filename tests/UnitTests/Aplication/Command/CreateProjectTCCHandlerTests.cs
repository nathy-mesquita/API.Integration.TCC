using API.Integration.TCC.Application.Commands.CreateProjectTCC;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace UnitTests.Aplication.Command
{
    public class CreateProjectTCCHandlerTests
    {
        [Fact(DisplayName = "Dado a criação de um projeto, quando executado, retornar um projeto válido diferente de nulo.")]
        [Trait("CreateProjectTCCCommand", "Handle")]
        public async void InputCreateProjectTCCCommand_Executed_ReturNotNull()
        {
            //Arrange
            var repositoryMock = new Mock<IProjectTCCRepository>();
            var loggerMock = new Mock<ILogger<CreateProjectTCCHandler>>();
            var createProjectTCCCommand = new CreateProjectTCCCommand
            {
                Title = "Aqui tem um título de projeto de tcc",
                Description = "Uma descrição de projeto de tcc",
                IdStudent = 1,
                DefenseForecast = CreateFakeDefenseForecast()

            };
            var createProjectTCCHandler = new CreateProjectTCCHandler(repositoryMock.Object, loggerMock.Object);

            //Act
            var result = await createProjectTCCHandler.Handle(createProjectTCCCommand, CancellationToken.None);


            //Assert
            Assert.True(result >= 0);
            repositoryMock.Verify(r => r.AddAsync(It.IsAny<ProjectTCC>()), Times.Once);

        }

        #region Métodos Auxiliares
        private static DateTime CreateFakeDefenseForecast()
        {
            return DateTime.Now.AddDays(160);
        }
        #endregion
    }
}