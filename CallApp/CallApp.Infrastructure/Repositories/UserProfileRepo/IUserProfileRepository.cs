using CallApp.Domain.Entities;

namespace CallApp.Infrastructure.Repositories.UserRepo
{
    public interface IUserProfileRepository
    {
        Task<List<UserProfile>> GetAllUserProfiles(CancellationToken cancellationToken);
        Task<UserProfile> GetUserProfileById(CancellationToken cancellationToken, int userId);
        Task CreateAsync(CancellationToken cancellationToken, UserProfile profile);
        void Update(CancellationToken cancellationToken, UserProfile profile);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, string personalNumber);
    }
}
