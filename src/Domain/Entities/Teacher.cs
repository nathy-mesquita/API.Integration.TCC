using System;
using System.Collections.Generic;

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

            Comments = new List<ProjectTCCComments>();
            AdvisorProject = new List<ProjectTCC>();
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

        /// <summary>
        /// Comentários
        /// </summary>
        /// <value></value>
        public List<ProjectTCCComments>? Comments { get; private set; }

        /// <summary>
        /// Orientador do Projeto
        /// </summary>
        /// <value></value>
        public List<ProjectTCC>? AdvisorProject { get; private set; }
    }
}