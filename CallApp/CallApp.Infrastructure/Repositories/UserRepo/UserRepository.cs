using CallApp.Domain.Entities;
using CallApp.Infrastructure.Errors.CustomErrors;
using CallApp.Infrastructure.Globalization;
using CallApp.Infrastructure.Repositories.BaseRepo.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CallApp.Infrastructure.Repositories.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _repository;

        public UserRepository(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            return await _repository.GetQuery().Include(i => i.UserProfile).ToListAsync(cancellationToken);
        }
        public async Task<User> GetUsersById(CancellationToken cancellationToken, int userId)
        {
            var user = await _repository.GetQuery(i => i.Id == userId).SingleOrDefaultAsync(cancellationToken);
            if (user == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            return user;
        }
        public async Task<User> FindByEmailAsync(CancellationToken cancellationToken, string email)
        {
            var user = await _repository.GetQuery(i => i.Email == email).SingleOrDefaultAsync(cancellationToken);
            if (user == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            return user;
        }
        public async Task CreateAsync(CancellationToken cancellationToken, User profile)
        {
            await _repository.AddAsync(profile, cancellationToken);
        }
        public void Update(User profile)
        {
            _repository.Update(profile);
        }
        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            await _repository.RemoveAsync(cancellationToken, id);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, string email)
        {
            return await _repository.AnyAsync(i => i.Email == email, cancellationToken);
        }
        
    }
}
