using PI.Integration.TCC.Domain.Enums;
using System;

namespace API.Integration.TCC.Application.Queries.GetProjectTCCById
{
    public class ProjectTCCDetailsViewModel
    {
        public ProjectTCCDetailsViewModel(int id, string? title, string? description, Guid enrollment, string? studentFullName, DateTime defenseForecast, ProjectStatusEnum status, DateTime createdAt, DateTime startedAt, DateTime finishedAt)
        {
            Id = id;
            Title = title;
            Description = description;
            Enrollment = enrollment;
            StudentFullName = studentFullName;
            DefenseForecast = defenseForecast;
            Status = status;
            CreatedAt = createdAt;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
        }

        public int Id { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public Guid Enrollment { get; private set; }
        public string? StudentFullName { get; private set; }
        public DateTime DefenseForecast { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime StartedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }
    }
}
