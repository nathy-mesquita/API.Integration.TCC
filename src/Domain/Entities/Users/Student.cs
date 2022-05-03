using System;
using System.Collections.Generic;
using API.Integration.TCC.Domain.Enums;

namespace API.Integration.TCC.Domain.Entities.Users
{
    public class Student : User
    {

        public Student(string fullName,
                        string email,
                        string password,
                        DateTime birthDate,
                        CourseEnum course,
                        string role)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Course = course;
            Role = role;

            Active = true;
            CreatedAt = DateTime.Now;
            Enrollment = Guid.NewGuid();
        }

        /// <summary>
        /// Curso matriculado
        /// </summary>
        /// <value></value>
        public CourseEnum Course { get; private set; }

        /// <summary>
        /// Papel do Aluno
        /// </summary>
        /// <value></value>
        public string Role { get; private set; }

        /// <summary>
        /// Matrícula do aluno
        /// </summary>
        /// <value></value>
        public Guid Enrollment { get; private set; }

    }
}