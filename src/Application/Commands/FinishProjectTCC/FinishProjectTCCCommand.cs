using MediatR;

namespace API.Integration.TCC.Application.Commands.FinishProjectTCC
{
    public class FinishProjectTCCCommand : IRequest<Unit>
    {
        public FinishProjectTCCCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
