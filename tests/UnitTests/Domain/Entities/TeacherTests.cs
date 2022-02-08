using API.Integration.TCC.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace API.Integration.TCC.Tests.Domain.Entities
{
    public class TeacherTests
    {

        [Fact(DisplayName = "Dado a criação de um professor, quando criado, retornar um professor válido.")]
        [Trait("CreateTeacher", "Created")]
        public void CreateTeacher_Created_ReturnValid()
        {
            // Arrange

            // Act
            var teacher = GetRandomElement();

            // Assert
            Assert.NotNull(teacher.FullName);
            Assert.NotEmpty(teacher.FullName);
            Assert.IsAssignableFrom<string>(teacher.FullName);

            Assert.NotNull(teacher.Email);
            Assert.NotEmpty(teacher.Email);
            Assert.IsAssignableFrom<string>(teacher.Email);

            Assert.NotNull(teacher.Password);
            Assert.NotEmpty(teacher.Password);
            Assert.IsAssignableFrom<string>(teacher.Password);

            Assert.IsAssignableFrom<DateTime>(teacher.BirthDate);
            Assert.True(teacher.BirthDate < DateTime.Now);

            Assert.NotNull(teacher.Specialty);
            Assert.NotEmpty(teacher.Specialty);
            Assert.IsAssignableFrom<string>(teacher.Specialty);

            Assert.NotNull(teacher.SubjectsTaught);
            Assert.NotEmpty(teacher.SubjectsTaught);
            Assert.IsAssignableFrom<string>(teacher.SubjectsTaught);

            Assert.NotNull(teacher.Role);
            Assert.NotEmpty(teacher.Role);
            Assert.IsAssignableFrom<string>(teacher.Role);
            Assert.Equal("IntegrationTCC_Teacher", teacher.Role);

            Assert.IsAssignableFrom<bool>(teacher.Active);
            Assert.True(teacher.Active);

            Assert.IsAssignableFrom<DateTime>(teacher.CreatedAt);
            Assert.True(teacher.CreatedAt < DateTime.Now);

            Assert.IsAssignableFrom<bool>(teacher.Advisor);

        }

        [Fact(DisplayName = "Dado que um professor já existe, quando atualizado orientador, retornar um professor orinetador ativo.")]
        [Trait("Teacher", "UpdateTeacherAdvisor")]
        public void TeacherExist_UpdateTeacherAdvisor_ReturnValid()
        {
            // Arrange
            var teacher = GetRandomElement();

            // Act
            teacher.UpdateTeacherAdvisor();

            // Assert
            Assert.IsAssignableFrom<bool>(teacher.Advisor);
            Assert.True(teacher.Advisor == true);

        }

        #region Fakes
        private readonly List<Teacher> _teachers = new List<Teacher>()
        {
            new Teacher(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), CreateRandomBirthDate(), GetRandomSpecialty(), GetRandomSubjectsTaught() ),
            new Teacher(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), CreateRandomBirthDate(), GetRandomSpecialty(), GetRandomSubjectsTaught() ),
            new Teacher(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), CreateRandomBirthDate(), GetRandomSpecialty(), GetRandomSubjectsTaught() ),
            new Teacher(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), CreateRandomBirthDate(), GetRandomSpecialty(), GetRandomSubjectsTaught() ),
            new Teacher(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), CreateRandomBirthDate(), GetRandomSpecialty(), GetRandomSubjectsTaught() ),
        };

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
        #endregion
        #region Métodos Auxiliares
        private static DateTime CreateRandomBirthDate()
        {
            DateTime start = new DateTime(1997, 1, 1);
            Random gen = new Random();
            int range = (DateTime.Today - start).Days;

            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }

        private Teacher GetRandomElement()
        {
            var lista = _teachers;
            var rnd = new Random();
            return lista[rnd.Next(lista.Count)];
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

