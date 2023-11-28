using CallApp.Application.Queries.Users.DTOs;
using CallApp.Infrastructure.Repositories.UserRepo;
using Mapster;
using MediatR;

namespace CallApp.Application.Queries.Users
{
    public class GetUsersProfileQueryHandler : IRequestHandler<GetUsersProfileQuery, List<UserProfileDto>>
    {
        private readonly IUserProfileRepository _repository;

        public GetUsersProfileQueryHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserProfileDto>> Handle(GetUsersProfileQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllUserProfiles(cancellationToken);
            return result.Adapt<List<UserProfileDto>>();
        }
    }
}
