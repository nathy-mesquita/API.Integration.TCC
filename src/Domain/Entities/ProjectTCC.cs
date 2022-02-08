using PI.Integration.TCC.Domain.Enums;
using System;
using System.Collections.Generic;

namespace API.Integration.TCC.Domain.Entities
{
    public class ProjectTCC : BaseEntity
    {
        public ProjectTCC(string? title,
                            string? description,
                            int idStudent,
                            DateTime defenseForecast)
        {
            Title = title;
            Description = description;
            IdStudent = idStudent;
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
        public int IdStudent { get; set; }

        /// <summary>
        /// Aluno
        /// </summary>
        /// <value></value>
        public Student? Student { get; set; }

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
        public DateTime DefenseForecast { get; private set; }

        /// <summary>
        /// Criado em
        /// </summary>
        /// <value></value>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Iniciado em 
        /// </summary>
        /// <value></value>
        public DateTime StartedAt { get; private set; }

        /// <summary>
        /// Finalizado em 
        /// </summary>
        /// <value></value>
        public DateTime FinishedAt { get; private set; }

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

        public void Cancel()
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.Cancelled;
            }
        }
        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }
        public void Finish()
        {
            if (Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
        }
        public void Update(string title, string description, DateTime defenseForecast)
        {
            if (Status == ProjectStatusEnum.Created || Status == ProjectStatusEnum.InProgress)
            {
                Title = title;
                Description = description;
                DefenseForecast = defenseForecast;
            }
        }
        public void UpdateTeacher(int idTeacher)
        {
            if (Status == ProjectStatusEnum.Created || Status == ProjectStatusEnum.InProgress)
            {
                IdTeacher = idTeacher;
            }
        }

    }
}