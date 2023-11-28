using CallApp.Application.Queries.UsersWithData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CallApp.API.Controllers
{
    public class UserDataController : BaseController
    {
        private readonly IMediator _mediator;

        public UserDataController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetUserAlbums")]
        public async Task<IActionResult> GetUserAlbums([FromQuery] GetUserAlbumsRequest query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("GetUserTodosRequest")]
        public async Task<IActionResult> GetUserTodos([FromQuery] GetUserTodosRequest query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("GetUserPosts")]
        public async Task<IActionResult> GetUserPosts([FromQuery] GetUserPostsRequest query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }

    }
}
