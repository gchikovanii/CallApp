using MediatR;

namespace CallApp.Application.Commands.Users
{
    public class DeleteProfileCommand : IRequest<bool>
    {
        public string Email { get; set; }
    }
}
