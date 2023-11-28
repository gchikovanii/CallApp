using CallApp.Application.Infrastructure.Helpers.Data;
using MediatR;

namespace CallApp.Application.Queries.UsersWithData
{
    public class GetUserAlbumsRequest : IRequest<List<Albums>>
    {
        public string Email { get; set; }
    }
}
