using CallApp.Infrastructure.Errors.CustomErrors;
using CallApp.Infrastructure.Globalization;
using CallApp.Infrastructure.Repositories.UserRepo;
using CallApp.Infrastructure.Units;
using MediatR;


namespace CallApp.Application.Commands.Users
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, bool>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProfileCommandHandler(IUserProfileRepository repository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(cancellationToken, request.Email);
            if (user == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            var userProfile = await _repository.GetUserProfileById(cancellationToken, user.Id);
            if (userProfile == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            if(!String.IsNullOrEmpty(request.FirstName) && request.FirstName!="string" && request.FirstName != userProfile.FirstName)
                userProfile.FirstName = request.FirstName;
            if (!String.IsNullOrEmpty(request.LastName) && request.LastName != "string" && request.LastName != userProfile.LastName)
                userProfile.LastName = request.LastName;
            if (!String.IsNullOrEmpty(request.PersonalNumber) && request.PersonalNumber != "string" && request.PersonalNumber != userProfile.PersonalNumber &&
                 await _repository.Exists(cancellationToken, request.PersonalNumber) == false)
                userProfile.PersonalNumber = request.PersonalNumber;
            _repository.Update(userProfile);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
