using MediatR;

namespace API.Integration.TCC.Application.Commands.UpdateTeacherAdvisor
{
    public class UpdateTeacherAdvisorCommand : IRequest<Unit>
    {
        /// <summary>
        /// Id do projeto
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id do  professor que será atribuido como orientador
        /// </summary>
        public int IdTeacher { get; set; }
    }
}
