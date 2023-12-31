﻿using CallApp.Domain.Entities;

namespace CallApp.Infrastructure.Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers(CancellationToken cancellationToken); 
        Task<User> FindByEmailAsync(CancellationToken cancellationToken, string email);
        Task<User> GetUsersById(CancellationToken cancellationToken, int userId);
        Task CreateAsync(CancellationToken cancellationToken, User profile);
        void Update(User profile);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, string email);
    }
}
