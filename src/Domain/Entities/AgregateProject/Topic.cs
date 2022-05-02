using System;

namespace API.Integration.TCC.Domain.Entities.AgregateProject
{
    /// <summary>
    /// Entity - Topic
    /// </summary>
    public class Topic
    {
        public Topic(string? title, DateTime deadline)
        {
            Title = title;
            Deadline = deadline;
        }

        /// <summary>
        /// Tópico do TCC
        /// </summary>
        /// <value></value>
        public string? Title { get; private set; }
        /// <summary>
        /// Prazo de entrega para do tópico
        /// </summary>
        /// <value></value>
        public DateTime Deadline { get; private set; }
    }
}