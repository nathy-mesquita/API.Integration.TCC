using MediatR;
using System;

namespace API.Integration.TCC.Application.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<int>
    {
        /// <summary>
        /// Nome completo do aluno
        /// </summary>
        public string? FullName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// Curso matriculado
        /// </summary>
        public string? Course { get; set; }
        /// <summary>
        /// Data de nascimento
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
