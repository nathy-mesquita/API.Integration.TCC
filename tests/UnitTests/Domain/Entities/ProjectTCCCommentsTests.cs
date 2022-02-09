using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Enums;
using System;
using System.Collections.Generic;
using Xunit;

namespace API.Integration.TCC.Tests.Domain.Entities
{
    public class ProjectTCCCommentsTests
    {

        [Fact(DisplayName = "Dado a criação de um comentário, quando criado, retornar um comentário válido.")]
        [Trait("CreateComment", "Created")]
        public void CreateComment_Created_ReturnValid()
        {
            // Arrange

            // Act
            var comments = GetRandomElement();

            // Assert
            Assert.NotNull(comments.Content);
            Assert.NotEmpty(comments.Content);
            Assert.IsAssignableFrom<string>(comments.Content);

            Assert.IsAssignableFrom<int>(comments.IdProjectTCC);
            Assert.IsAssignableFrom<int>(comments.IdUser);

            Assert.Equal(CommentStatusEnum.Created, comments.Status);
            Assert.True(comments.CreatedAt < DateTime.Now);
            Assert.IsAssignableFrom<DateTime>(comments.CreatedAt);
        }

        [Fact(DisplayName = "Dado que um comentário existe, quando atulizado, retornar comentário válido.")]
        [Trait("UpdateComments", "Update")]
        public void UpdateComments_Update_ReturnValid()
        {
            // Arrange
            var comments = GetRandomElement();

            // Act
            comments.Update(GetRandomContent());

            // Assert
            Assert.Equal(CommentStatusEnum.Created, comments.Status);
            Assert.IsAssignableFrom<string>(comments.Content);
            Assert.True(comments.Content!.Length < 250);
        }

        [Fact(DisplayName = "Dado que um comentário existe, quando deletado, retornar statud Deletado.")]
        [Trait("DeleteComments", "Delete")]
        public void DeleteComments_Delete_ReturnStatusDeleted()
        {
            // Arrange
            var comments = GetRandomElement();

            // Act
            comments.Delete();

            // Assert
            Assert.Equal(CommentStatusEnum.Deleted, comments.Status); ;
        }
        #region Fakes
        private readonly List<ProjectTCCComments> _comments = new List<ProjectTCCComments>()
        {
            new ProjectTCCComments(GetRandomContent(), GetRandomId(), GetRandomId()),
            new ProjectTCCComments(GetRandomContent(), GetRandomId(), GetRandomId()),
            new ProjectTCCComments(GetRandomContent(), GetRandomId(), GetRandomId()),
            new ProjectTCCComments(GetRandomContent(), GetRandomId(), GetRandomId()),
            new ProjectTCCComments(GetRandomContent(), GetRandomId(), GetRandomId()),
        };

        private static readonly string[] _content = new string[]
        {
            "Ana Julia", "Maria Beatriz", "João Pedro", "Carlos Alberto", "Dolores Albergues"
        };
        #endregion
        #region Métodos Auxiliares
        private static string GetRandomContent()
        {
            var rnd = new Random();
            var start = rnd.Next(0, _content.Length);
            return _content[start];
        }
        private static int GetRandomId()
        {
            var rnd = new Random();
            return rnd.Next(0, 6);
        }

        private ProjectTCCComments GetRandomElement()
        {
            var lista = _comments;
            var rnd = new Random();
            return lista[rnd.Next(lista.Count)];
        }
        #endregion
    }
}
