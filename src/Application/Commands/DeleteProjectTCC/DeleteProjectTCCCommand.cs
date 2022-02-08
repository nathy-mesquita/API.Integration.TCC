using MediatR;

namespace API.Integration.TCC.Application.Commands.DeleteProjectTCC
{
    public class DeleteProjectTCCCommand : IRequest<Unit>
    {
        public DeleteProjectTCCCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
