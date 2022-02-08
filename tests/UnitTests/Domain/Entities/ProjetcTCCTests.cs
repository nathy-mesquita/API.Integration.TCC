using API.Integration.TCC.Domain.Entities;
using PI.Integration.TCC.Domain.Enums;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Domain.Entities
{

    public class ProjetcTCCTests
    {
        private readonly List<ProjectTCC> _projectTCCs = new List<ProjectTCC>()
        {
            new ProjectTCC("Titulo do Projeto 1", "Descrição do projeto 1", 1, CreateFakeDefenseForecast()),
            new ProjectTCC("Titulo do Projeto 2", "Descrição do projeto 2", 2, CreateFakeDefenseForecast()),
            new ProjectTCC("Titulo do Projeto 3", "Descrição do projeto 3", 3, CreateFakeDefenseForecast()),
            new ProjectTCC("Titulo do Projeto 4", "Descrição do projeto 4", 4, CreateFakeDefenseForecast()),
        };

        [Fact(DisplayName = "Dado a criação de um projeto de tcc, quando criado, retornar um projeto de tcc válido.")]
        [Trait("CreateProjectTCC", "Created")]
        public void CreatedProjectTCC_Created_ReturnValid()
        {
            // Arrange

            // Act
            var projectTCC = GetRandomElement();

            // Assert
            Assert.NotNull(projectTCC.Title);
            Assert.NotEmpty(projectTCC.Title);
            Assert.IsAssignableFrom<string>(projectTCC.Title);

            Assert.NotNull(projectTCC.Description);
            Assert.NotEmpty(projectTCC.Description);
            Assert.IsAssignableFrom<string>(projectTCC.Description);

            Assert.IsAssignableFrom<int>(projectTCC.IdStudent);

            Assert.IsAssignableFrom<DateTime>(projectTCC.DefenseForecast);
            Assert.True(projectTCC.DefenseForecast > DateTime.Now);

            Assert.Equal(ProjectStatusEnum.Created, projectTCC.Status);
            Assert.True(projectTCC.CreatedAt < DateTime.Now);
            Assert.IsAssignableFrom<DateTime>(projectTCC.CreatedAt);

        }


        [Fact(DisplayName = "Dado a criação de um projeto de tcc, quando iniciado, retornar status em progresso.")]
        [Trait("CreateProjectTCC", "Start")]
        public void CreatedProjectTCC_Started_ReturnStatusInProgress()
        {
            // Arrange
            var projectTCC = GetRandomElement();

            Assert.Equal(ProjectStatusEnum.Created, projectTCC.Status);


            // Act
            projectTCC.Start();

            // Assert
            Assert.True(projectTCC.CreatedAt < DateTime.Now);
            Assert.Equal(ProjectStatusEnum.InProgress, projectTCC.Status);
            Assert.IsAssignableFrom<DateTime>(projectTCC.StartedAt);
            Assert.True(projectTCC.StartedAt < DateTime.Now);
        }


        [Fact(DisplayName = "Dado que um projeto de tcc existe, quando cancelado, retornar status em cancelado.")]
        [Trait("CreateProjectTCC", "Cancelled")]
        public void OneProjectExist_Cancelled_ReturnStatusCancelled()
        {
            // Arrange
            var projectTCC = GetRandomElement();
            projectTCC.Start();
            Assert.Equal(ProjectStatusEnum.InProgress, projectTCC.Status);


            // Act
            projectTCC.Cancel();

            // Assert
            Assert.Equal(ProjectStatusEnum.Cancelled, projectTCC.Status);
        }

        [Fact(DisplayName = "Dado que um projeto de tcc está em progresso, quando inifinalizado, retornar status em finalizado.")]
        [Trait("ProjectTCCInProgress", "Finished")]
        public void ProjectTCCInProgress_Finished_ReturnStatusFinished()
        {
            // Arrange
            var projectTCC = GetRandomElement();
            projectTCC.Start();


            // Act
            projectTCC.Finish();

            // Assert
            Assert.Equal(ProjectStatusEnum.Finished, projectTCC.Status);
            Assert.IsAssignableFrom<DateTime>(projectTCC.FinishedAt);
            Assert.True(projectTCC.FinishedAt < DateTime.Now);
        }


        [Fact(DisplayName = "Dado que um projeto de tcc existe, quando atulizado, retornar projeto de tcc válido.")]
        [Trait("UpdateProjectTCC", "Update")]
        public void ProjectTCCExist_Update_ReturnProjectTCCValid()
        {
            // Arrange
            var projectTCC = GetRandomElement();

            // Act
            projectTCC.Update("Atualização de Título", "Atualização de Descrição", CreateFakeDefenseForecast());

            // Assert
            Assert.Equal(ProjectStatusEnum.Created, projectTCC.Status);
            Assert.Equal("Atualização de Título", projectTCC.Title);
            Assert.Equal("Atualização de Descrição", projectTCC.Description);
            Assert.IsAssignableFrom<DateTime>(projectTCC.DefenseForecast);
            Assert.True(projectTCC.DefenseForecast > DateTime.Now);
        }

        [Fact(DisplayName = "Dado que um projeto de tcc existe, quando atulizado o professor orientador, retornar projeto de tcc válido.")]
        [Trait("UpdateProjectTCC", "UpdateTeacher")]
        public void ProjectTCCExist_UpdateTeacher_ReturnProjectTCCValid()
        {
            // Arrange
            var projectTCC = GetRandomElement();

            // Act
            projectTCC.UpdateTeacher(1);

            // Assert
            Assert.Equal(ProjectStatusEnum.Created, projectTCC.Status);
            Assert.Equal(1, projectTCC.IdTeacher);
            Assert.IsAssignableFrom<int>(projectTCC.IdTeacher);
        }

        #region Métodos Auxiliares
        private static DateTime CreateFakeDefenseForecast()
        {
            return DateTime.Now.AddDays(160);
        }

        private ProjectTCC GetRandomElement()
        {
            var lista = _projectTCCs;
            var rnd = new Random();
            return lista[rnd.Next(lista.Count)];
        }
        #endregion
    }
}