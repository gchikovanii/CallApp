using CallApp.Application.Commands.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CallApp.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> Register(RegistrationCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(LoginCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
    }
}
