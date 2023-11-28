using CallApp.Application.Infrastructure.Helpers.Data;
using MediatR;

namespace CallApp.Application.Queries.UsersWithData
{
    public class GetUserTodosRequest : IRequest<List<Todo>>
    {
        public string Email { get; set; }
    }
}
