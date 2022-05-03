using System;
using System.Collections.Generic;
using API.Integration.TCC.Domain.Entities;

namespace API.Integration.TCC.Domain.Entities.AgregateProject
{
    /// <summary>
    /// Agregate Root - Project
    /// </summary>
    public class Project : BaseEntity
    {
        public Project(Tcc tcc, Authors authors, Term term)
        {
            Tcc = tcc;
            Authors = authors;  
            Term = term;
        }
        /// <summary>
        /// Informações básicas do tipo de projeto que será realizado 
        /// </summary>
        public Tcc Tcc { get; set; }

        /// <summary>
        /// Autores do projeto
        /// <example><see cref="Authors.Student"/></example>
        /// <example><see cref="Authors.Teacher"/></example>
        /// </summary>
        public Authors Authors { get; set; }

        /// <summary>
        /// Termo para solicitação de um projeto
        /// <example>O termo deverá ser <see cref="Term.EmittedBy"/> um aluno</example>
        /// <example>O termo deverá ser <see cref="Term.AcceptedBy"/> um professor orientador</example>
        /// <example>O termo deverá ser <see cref="Term.ApprovedBy"/> um coordenador</example>
        /// </summary>
        public Term Term { get; set; }

        /// <summary>
        /// Cronograma dos tópcos que serão abordados no projeto
        /// <example><see cref="Topic.Title"/>= Arquitetura de software</example>
        /// <example><see cref="Topic.Deadline"/>= <code>DateTime date = new DateTime(2022, 12, 02);</code></example>
        /// </summary>
        public IReadOnlyCollection<Topic>? Schedule { get; set; }

        /// <summary>
        /// Lista de comentários que poderão ser realizados pelos <see cref="Authors"/>
        /// </summary>
        public IReadOnlyCollection<Comments>? Comments { get; set; }

        /// <summary>
        /// Geração de um cronograma
        /// </summary>
        /// <param name="schedule">conograma do projeto</param>
        public void GenereteSchedule(List<Topic> schedule)
        {
            Schedule = schedule;
        }

        /// <summary>
        /// Criação de um comentário
        /// </summary>
        /// <param name="comments">comentário do projeto</param>
        public void CreateComments(List<Comments> comments)
        {
            Comments = Comments;
        }
    }
}