﻿using System.Linq.Expressions;

namespace Auction.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);

    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<T> entities);
}