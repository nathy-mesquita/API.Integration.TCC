using System;

namespace API.Integration.TCC.Domain.Entities
{
    public class Student: User
    {
        public Student(string? fullName,
                        string? email,
                        string? password,
                        string? role,
                        DateTime birthDate,
                        string? course,
                        string? enrollment)
        {
            this.FullName = fullName;
            this.Email = email;
            this.Password = password;
            this.Role = role;
            this.BirthDate = birthDate;

            this.Active = true;
            this.CreatedAt = DateTime.Now;

            Course = course;
            Enrollment = enrollment;
        }

        /// <summary>
        /// Curso matriculado
        /// </summary>
        /// <value></value>
        public string? Course { get; private set; }

        /// <summary>
        /// Matrícula do aluno
        /// </summary>
        /// <value></value>
        public string? Enrollment { get; private set; }
    }
}