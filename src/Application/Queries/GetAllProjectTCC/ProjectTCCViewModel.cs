using System;

namespace API.Integration.TCC.Application.Queries.GetAllProjectTCC
{
    public class ProjectTCCViewModel
    {
        public ProjectTCCViewModel(int id, string title, string description, DateTime defenseForecast)
        {
            Id = id;
            Title = title;
            Description = description;
            DefenseForecast = defenseForecast;
        }

        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DefenseForecast { get; private set; }
    }
}
