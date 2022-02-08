using MediatR;
using System;

namespace API.Integration.TCC.Application.Commands.UpdateProjectTCC
{
    public class UpdateProjectTCCCommand : IRequest<Unit>
    {
        /// <summary>
        /// Id 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Título
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Desrição
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Data da defesa
        /// </summary>
        public DateTime DefenseForecast { get; set; }
    }
}
