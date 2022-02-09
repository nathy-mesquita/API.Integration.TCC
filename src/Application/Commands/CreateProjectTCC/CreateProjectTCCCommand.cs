using MediatR;
using System;

namespace API.Integration.TCC.Application.Commands.CreateProjectTCC
{
    public class CreateProjectTCCCommand : IRequest<int>
    {
        /// <summary>
        /// Título
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// ID do aluno
        /// </summary>
        public int IdStudent { get; set; }
        /// <summary>
        /// Data da defesa
        /// </summary>
        public DateTime DefenseForecast { get; set; }
    }
}
