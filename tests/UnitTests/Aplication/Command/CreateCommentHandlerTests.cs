using System.Threading;
using API.Integration.TCC.Application.Commands.CreateComment;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace UnitTests.Aplication.Command
{
    public class CreateCommentHandlerTests
    {
        [Fact(DisplayName = "Dado a criação de um comentário, quando executado, retornar um comentário válido diferente de nulo.")]
        [Trait("CreateComment", "Handle")]
        public async void InputComment_Executed_ReturNotNull()
        {
            //Arrange
            var repositoryMock = new Mock<IProjectTCCCommentsRepository>();
            var loggerMock = new Mock<ILogger<CreateCommentHandler>>();
            var createCommentCommand = new CreateCommentCommand
            {
                Content = "Aqui tem um comentário de projeto",
                IdProjectTCC = 3,
                IdUser = 1
            };
            var createCommentCommandHandler = new CreateCommentHandler(repositoryMock.Object, loggerMock.Object);

            //Act
            var result = await createCommentCommandHandler.Handle(createCommentCommand, CancellationToken.None);


            //Assert
            Assert.True(result >= 0);
            repositoryMock.Verify(r => r.AddCommentAsync(It.IsAny<ProjectTCCComments>()), Times.Once);

        }
    }
}