using CallApp.Domain.Entities;
using CallApp.Infrastructure.Errors.CustomErrors;
using CallApp.Infrastructure.Globalization;
using CallApp.Infrastructure.Repositories.BaseRepo.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CallApp.Infrastructure.Repositories.UserRepo
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IRepository<UserProfile> _repository;

        public UserProfileRepository(IRepository<UserProfile> repository)
        {
            _repository = repository;
        }
        public async Task<List<UserProfile>> GetAllUserProfiles(CancellationToken cancellationToken)
        {
            return await _repository.GetQuery().ToListAsync(cancellationToken);
        }

        public async Task<UserProfile> GetUserProfileById(CancellationToken cancellationToken, int userId)
        {
            return await _repository.GetQuery(i => i.UserId == userId).SingleOrDefaultAsync(cancellationToken);
        }
        public async Task CreateAsync(CancellationToken cancellationToken, UserProfile profile)
        {
            await _repository.AddAsync(profile, cancellationToken);
        }
        public void Update(UserProfile profile)
        {
            _repository.Update(profile);
        }
        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            await _repository.RemoveAsync(cancellationToken, id);
        }
       
        public async Task<bool> Exists(CancellationToken cancellationToken, string personalNumber)
        {
            return await _repository.AnyAsync(i => i.PersonalNumber == personalNumber, cancellationToken);
        }

       
    }
}
