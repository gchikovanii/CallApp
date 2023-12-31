﻿using System.Linq.Expressions;

namespace CallApp.Infrastructure.Repositories.BaseRepo.Abstraction
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetCollectionAsync(CancellationToken token, Expression<Func<T, bool>> expression = null);
        IQueryable<T> GetQuery(Expression<Func<T, bool>> expression = null);
        IQueryable<T> Table { get; }
        Task AddAsync(T entity, CancellationToken token);
        void Update(T entity);
        Task RemoveAsync(CancellationToken token, params object[] key);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken token);
    }
}
