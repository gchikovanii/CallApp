using CallApp.Domain.Entities;
using CallApp.Infrastructure.Errors.CustomErrors;
using CallApp.Infrastructure.Globalization;
using CallApp.Infrastructure.Repositories.UserRepo;
using CallApp.Infrastructure.Units;
using MediatR;

namespace CallApp.Application.Commands.Users
{
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, bool>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProfileCommandHandler(IUserProfileRepository repository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(cancellationToken, request.Email);
            if (user == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            var userProfile = await _repository.GetUserProfileById(cancellationToken, user.Id);
            if (userProfile != null)
                throw new AlreadyExists(ErrorMessages.AlreadyExists);
            await _repository.CreateAsync(cancellationToken, new UserProfile()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PersonalNumber = request.PersonalNumber,
                UserId = user.Id
            });
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
