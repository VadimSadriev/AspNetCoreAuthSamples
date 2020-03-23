using MediatR;

namespace Auth.Application.Identity.Commands
{
    public class IsTokenValidCommand : IRequest<bool>
    {
    }
}