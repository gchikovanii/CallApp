using CallApp.Application.Infrastructure.Helpers.Data;
using MediatR;


namespace CallApp.Application.Queries.UsersWithData
{
    public class GetUserPostsRequest : IRequest<List<PostsWithComments>>
    {
        public string Email { get; set; }
    }
}