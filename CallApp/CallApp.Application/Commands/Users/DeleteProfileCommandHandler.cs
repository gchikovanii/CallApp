using CallApp.Infrastructure.Errors.CustomErrors;
using CallApp.Infrastructure.Globalization;
using CallApp.Infrastructure.Repositories.UserRepo;
using CallApp.Infrastructure.Units;
using MediatR;

namespace CallApp.Application.Commands.Users
{
    public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, bool>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProfileCommandHandler(IUserProfileRepository repository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(cancellationToken, request.Email);
            if (user == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            var userProfile = await _repository.GetUserProfileById(cancellationToken, user.Id);
            if (userProfile == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            await _repository.DeleteAsync(cancellationToken, userProfile.Id);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
