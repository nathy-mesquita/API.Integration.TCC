using System;
using API.Integration.TCC.Domain.Entities;
using API.Integration.TCC.Domain.Enums;

namespace API.Integration.TCC.Domain.Entities.AgregateProject
{
    /// <summary>
    /// Value Objetc - TCC
    /// </summary>
    public class Tcc : BaseEntity
    {
        public Tcc(string? title, 
                    string? description, 
                    DateTime defenseForecast)
        {
            Title = title;
            Description = description;
            DefenseForecast = defenseForecast;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
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
    }
}