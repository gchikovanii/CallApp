using CallApp.Application.Infrastructure.Helpers;
using CallApp.Domain.Entities;
using CallApp.Infrastructure.Errors.CustomErrors;
using CallApp.Infrastructure.Globalization;
using CallApp.Infrastructure.Repositories.UserRepo;
using CallApp.Infrastructure.Units;
using Mapster;
using MediatR;

namespace CallApp.Application.Commands.Accounts
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Exists(cancellationToken, request.Email);
            if (user == true)
                throw new AlreadyExists(ErrorMessages.AlreadyExists);
            request.Password = PasswordHelper.HashPassword(request.Password);
            await _repository.CreateAsync(cancellationToken, request.Adapt<User>());
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
