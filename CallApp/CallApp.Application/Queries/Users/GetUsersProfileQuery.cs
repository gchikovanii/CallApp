using CallApp.Application.Queries.Users.DTOs;
using MediatR;

namespace CallApp.Application.Queries.Users
{
    public class GetUsersProfileQuery : IRequest<List<UserProfileDto>>
    {
    }
}
