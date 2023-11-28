using CallApp.Application.Infrastructure.Helpers;
using CallApp.Application.Infrastructure.Helpers.Data;
using CallApp.Infrastructure.Errors.CustomErrors;
using CallApp.Infrastructure.Globalization;
using CallApp.Infrastructure.Repositories.UserRepo;
using MediatR;

namespace CallApp.Application.Queries.UsersWithData
{
    public class GetUserTodosRequestHandler : IRequestHandler<GetUserTodosRequest, List<Todo>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserTodosRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<Todo>> Handle(GetUserTodosRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(cancellationToken, request.Email);
            if (user == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            var result = await RetriveUsersDataHelper.GetUserTodosAsync(user.Id);
            return result;
        }
    }
}
