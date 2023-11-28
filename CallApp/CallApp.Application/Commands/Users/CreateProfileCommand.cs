using MediatR;

namespace CallApp.Application.Commands.Users
{
    public class CreateProfileCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
    }
}
