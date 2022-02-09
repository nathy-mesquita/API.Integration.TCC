using API.Integration.TCC.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace API.Integration.TCC.Tests.Domain.Entities
{
    public class StudentTests
    {
        [Fact(DisplayName = "Dado a criação de um aluno, quando criado, retornar um aluno válido.")]
        [Trait("CreateStudent", "Created")]
        public void CreateStudent_Created_ReturnValid()
        {
            // Arrange

            // Act
            var student = GetRandomElement();

            // Assert
            Assert.NotNull(student.FullName);
            Assert.NotEmpty(student.FullName);
            Assert.IsAssignableFrom<string>(student.FullName);

            Assert.NotNull(student.Email);
            Assert.NotEmpty(student.Email);
            Assert.IsAssignableFrom<string>(student.Email);

            Assert.NotNull(student.Password);
            Assert.NotEmpty(student.Password);
            Assert.IsAssignableFrom<string>(student.Password);

            Assert.NotNull(student.Course);
            Assert.NotEmpty(student.Course);
            Assert.IsAssignableFrom<string>(student.Course);

            Assert.IsAssignableFrom<DateTime>(student.BirthDate);
            Assert.True(student.BirthDate < DateTime.Now);

            Assert.NotNull(student.Role);
            Assert.NotEmpty(student.Role);
            Assert.IsAssignableFrom<string>(student.Role);
            Assert.Equal("IntegrationTCC_Student", student.Role);

            Assert.IsAssignableFrom<bool>(student.Active);
            Assert.True(student.Active);

            Assert.IsAssignableFrom<DateTime>(student.CreatedAt);
            Assert.True(student.CreatedAt < DateTime.Now);

            Assert.IsAssignableFrom<Guid>(student.Enrollment);
        }

        #region Fakes
        private readonly List<Student> _students = new List<Student>()
        {
            new Student(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), GetRandomCouse(), CreateRandomBirthDate()),
            new Student(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), GetRandomCouse(), CreateRandomBirthDate()),
            new Student(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), GetRandomCouse(), CreateRandomBirthDate()),
            new Student(GetRandomFullName(), GetRandomEmail(), GetRandomPassword(), GetRandomCouse(), CreateRandomBirthDate()),

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

        private static readonly string[] _course = new string[]
        {
            "Engenharia de Computação", "Desing", "Pedagogia", "Odontoligia", "Enfermagem"
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

        private Student GetRandomElement()
        {
            var lista = _students;
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
        private static string GetRandomCouse()
        {
            var rnd = new Random();
            var start = rnd.Next(0, _course.Length);
            return _course[start];
        }
        #endregion
    }
}
