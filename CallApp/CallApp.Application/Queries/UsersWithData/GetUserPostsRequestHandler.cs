using CallApp.Application.Infrastructure.Helpers;
using CallApp.Application.Infrastructure.Helpers.Data;
using CallApp.Infrastructure.Errors.CustomErrors;
using CallApp.Infrastructure.Globalization;
using CallApp.Infrastructure.Repositories.UserRepo;
using MediatR;

namespace CallApp.Application.Queries.UsersWithData
{
    public class GetUserPostsRequestHandler : IRequestHandler<GetUserPostsRequest,List<PostsWithComments>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserPostsRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<PostsWithComments>> Handle(GetUserPostsRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(cancellationToken, request.Email);
            if (user == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            var result = await RetriveUsersDataHelper.GetUserPostsWithCommentsAsync(user.Id);
            return result;
        }
    }
}