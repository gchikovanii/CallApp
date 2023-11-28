using CallApp.Application.Queries.Users.DTOs;
using CallApp.Infrastructure.Errors.CustomErrors;
using CallApp.Infrastructure.Globalization;
using CallApp.Infrastructure.Repositories.UserRepo;
using Mapster;
using MediatR;

namespace CallApp.Application.Queries.Users
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IUserRepository _userRepository;

        public GetUserProfileQueryHandler(IUserProfileRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(cancellationToken, request.Email);
            if (user == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            var userProfile = await _repository.GetUserProfileById(cancellationToken, user.Id);
            if (userProfile == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            return userProfile.Adapt<UserProfileDto>();
        }
    }
}
