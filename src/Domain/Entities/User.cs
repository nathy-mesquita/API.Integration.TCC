using System;

namespace API.Integration.TCC.Domain.Entities
{
    public abstract class User : BaseEntity
    {

        /// <summary>
        /// Nome Completo
        /// </summary>
        /// <value></value>
        public string? FullName { get; protected set; }

        /// <summary>
        /// Email para Login
        /// </summary>
        /// <value></value>
        public string? Email { get; protected set; }

        /// <summary>
        /// Senha para Login
        /// </summary>
        /// <value></value>
        public string? Password { get; protected set; }
        /// <summary>
        /// Papel do Aluno
        /// </summary>
        /// <value></value>
        public string? Role { get; protected set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        /// <value></value>
        public DateTime BirthDate { get; protected set; }

        /// <summary>
        /// Está ativo
        /// </summary>
        /// <value></value>
        public bool Active { get; protected set; }

        /// <summary>
        /// Criado em
        /// </summary>
        /// <value></value>
        public DateTime CreatedAt { get; protected set; }
    }
}