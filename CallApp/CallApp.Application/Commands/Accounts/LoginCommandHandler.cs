using CallApp.Application.Infrastructure.Helpers;
using CallApp.Application.Infrastructure.Services;
using CallApp.Infrastructure.Repositories.UserRepo;
using MediatR;


namespace CallApp.Application.Commands.Accounts
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _repository;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public LoginCommandHandler(IUserRepository repository, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _repository = repository;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.FindByEmailAsync(cancellationToken, request.Email);
            if (PasswordHelper.VerifyPassword(request.Password, user.Password))
                return _jwtAuthenticationManager.Authenticate(true, request.Email);
            return String.Empty;
        }
    }
}
