using CallApp.Application.Infrastructure.Helpers;
using CallApp.Application.Infrastructure.Helpers.Data;
using CallApp.Infrastructure.Errors.CustomErrors;
using CallApp.Infrastructure.Globalization;
using CallApp.Infrastructure.Repositories.UserRepo;
using MediatR;

namespace CallApp.Application.Queries.UsersWithData
{
    public class GetUserAlbumsRequestHandler : IRequestHandler<GetUserAlbumsRequest, List<Albums>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserAlbumsRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Albums>> Handle(GetUserAlbumsRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(cancellationToken, request.Email);
            if (user == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            var result = await RetriveUsersDataHelper.GetUserAlbumsAsync(user.Id);
            return result;
        }
    }
}
