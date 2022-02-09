using API.Integration.TCC.Application.Queries.GetAllProjectTCC;
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
    public class GetAllProjectTCCHandlerTests
    {

        [Fact(DisplayName = "Dado que tr�s projetos existem, quando consultados, retornar tr�s projetos.")]
        [Trait("GetAllProject", "Handle")]
        public async Task ThreeProjectsExist_Fetched_ReturnThreeProjectViewModels()
        {
            //Arrange
            var projectTCCs = new List<ProjectTCC>()
            {
                new ProjectTCC("Titulo do Projeto 1", "Descri��o do projeto 1", 1, CreateFakeDefenseForecast()),
                new ProjectTCC("Titulo do Projeto 2", "Descri��o do projeto 2", 2, CreateFakeDefenseForecast()),
                new ProjectTCC("Titulo do Projeto 3", "Descri��o do projeto 3", 3, CreateFakeDefenseForecast()),
            };

            var repositoryMock = new Mock<IProjectTCCRepository>();
            var loggerMock = new Mock<ILogger<GetAllProjectTCCHandler>>();

            repositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projectTCCs);

            var getAllProjectTCCQuery = new GetAllProjectTCCQuery("");
            var getAllProjectTCCHandler = new GetAllProjectTCCHandler(repositoryMock.Object, loggerMock.Object);

            //Act
            var projectTccViewModelList = await getAllProjectTCCHandler.Handle(getAllProjectTCCQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(projectTccViewModelList);
            Assert.NotEmpty(projectTccViewModelList);
            Assert.Equal(projectTCCs.Count, projectTccViewModelList.Count);

            repositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }

        #region M�todos Auxiliares
        private static DateTime CreateFakeDefenseForecast()
        {
            return DateTime.Now.AddDays(160);
        }
        #endregion
    }
}