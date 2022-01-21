using System;

namespace API.Integration.TCC.Domain.Entities
{
    public class Teacher : User
    {
        public Teacher(string? fullName,
                        string? email,
                        string? password,
                        string? role,
                        DateTime birthDate,
                        string? specialty,
                        string[]? subjectsTaught)
        {
            this.FullName = fullName;
            this.Email = email;
            this.Password = password;
            this.Role = role;
            this.BirthDate = birthDate;

            this.Active = true;
            this.CreatedAt = DateTime.Now;

            Advisor = false;
            Specialty = specialty;
            SubjectsTaught = subjectsTaught;
        }
        /// <summary>
        /// Se é Orientador
        /// </summary>
        /// <value></value>
        public bool Advisor { get; private set; }

        /// <summary>
        /// Especialidade
        /// </summary>
        /// <value></value>
        public string? Specialty { get; private set; }

        /// <summary>
        /// Disciplinas Ministradas
        /// </summary>
        /// <value></value>
        public string[]? SubjectsTaught { get; private set; }
    }
}