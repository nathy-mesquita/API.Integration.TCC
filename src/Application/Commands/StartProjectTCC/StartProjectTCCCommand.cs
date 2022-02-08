using MediatR;

namespace API.Integration.TCC.Application.Commands.StartProjectTCC
{
    public class StartProjectTCCCommand : IRequest<Unit>
    {
        public StartProjectTCCCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
