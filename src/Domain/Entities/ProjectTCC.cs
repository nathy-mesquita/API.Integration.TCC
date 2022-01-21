using System;
using System.Collections.Generic;
using PI.Integration.TCC.Domain.Enums;

namespace API.Integration.TCC.Domain.Entities
{
    public class ProjectTCC : BaseEntity
    {
        public ProjectTCC(string title,
                            string description,
                            int idStudent,
                            int idTeacher,
                            DateTime? defenseForecast)
        {
            Title = title;
            Description = description;
            IdStudent = idStudent;

            IdTeacher = idTeacher;
            DefenseForecast = defenseForecast;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectTCCComments>();
        }
        /// <summary>
        /// Título
        /// </summary>
        /// <value></value>
        public string? Title { get; private set; }

        /// <summary>
        /// Descrição
        /// </summary>
        /// <value></value>
        public string? Description { get; private set; }

        /// <summary>
        /// Id do Aluno
        /// </summary>
        /// <value></value>
        public int IdStudent { get; private set; }

        /// <summary>
        /// Aluno
        /// </summary>
        /// <value></value>
        public Student? Student { get; private set; }

        /// <summary>
        /// Id do Professor
        /// </summary>
        /// <value></value>
        public int IdTeacher { get; private set; }

        /// <summary>
        /// Professor
        /// </summary>
        /// <value></value>
        public Teacher? Teacher { get; private set; }

        /// <summary>
        /// Previsão de Defesa
        /// </summary>
        /// <value></value>
        public DateTime? DefenseForecast  { get; private set; }

        /// <summary>
        /// Criado em
        /// </summary>
        /// <value></value>
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Iniciado em 
        /// </summary>
        /// <value></value>
        public DateTime? StartedAt { get; private set; }

        /// <summary>
        /// Finalizado em 
        /// </summary>
        /// <value></value>
        public DateTime? FinishedAt { get; private set; }

        /// <summary>
        /// Status
        /// </summary>
        /// <value></value>
        public ProjectStatusEnum Status { get; private set; }

        /// <summary>
        /// Comentários
        /// </summary>
        /// <value></value>
        public List<ProjectTCCComments> Comments { get; private set; }
    }
}