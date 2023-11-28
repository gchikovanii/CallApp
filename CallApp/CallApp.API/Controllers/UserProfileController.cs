using CallApp.Application.Commands.Users;
using CallApp.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallApp.API.Controllers
{
    public class UserProfileController : BaseController
    {
        private readonly IMediator _mediator;

        public UserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserProfiles(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetUsersProfileQuery(), cancellationToken));
        }
        [Authorize]
        [HttpGet("GetUsersProfile")]
        public async Task<IActionResult> GetUserProfile([FromQuery] GetUserProfileQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [Authorize]
        [HttpPost("CreateProfile")]
        public async Task<IActionResult> CreateProfile(CreateProfileCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize]
        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize]
        [HttpDelete("DeleteProfile")]
        public async Task<IActionResult> DeleteProfile([FromForm] DeleteProfileCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
