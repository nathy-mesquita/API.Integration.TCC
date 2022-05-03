using API.Integration.TCC.Domain.Entities.AgregateProject;
using System;
using System.Collections.Generic;

namespace API.Integration.TCC.Domain.Entities.Users
{
    public class Teacher : User
    {
        public Teacher(string fullName,
                        string email,
                        string password,
                        DateTime birthDate,
                        string role,
                        string specialty,
                        string subjectsTaught)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Role = role;
            Specialty = specialty;
            SubjectsTaught = subjectsTaught;

            Active = true;
            CreatedAt = DateTime.Now;
        }
        /// <summary>
        /// Papel do Professor
        /// </summary>
        /// <value></value>
        public string Role { get; private set; }

        /// <summary>
        /// Se é Orientador, ou seja <see cref="Authors.IdTeacher"/> de algum projeto
        /// </summary>
        /// <value></value>
        public Authors? Advisor { get; private set; }

        /// <summary>
        /// Especialidade
        /// </summary>
        /// <value></value>
        public string Specialty { get; private set; }

        /// <summary>
        /// Disciplinas Ministradas
        /// </summary>
        /// <value></value>
        public string SubjectsTaught { get; private set; }

        public void SetTeacherAdvisor(Authors authors)
        {
            if (Active)
                Advisor = authors;
        }
    }
}