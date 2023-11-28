using CallApp.Application.Queries.Users.DTOs;
using MediatR;

namespace CallApp.Application.Queries.Users
{
    public class GetUserProfileQuery : IRequest<UserProfileDto>
    {
        public string Email { get; set; }
    }
}
