﻿using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using NewsArticles.API.Application.Contracts;
using NewsArticles.API.Persistence.Data;

namespace NewsArticles.API.Persistence.Repositories;

internal class BaseRepositoryAsync<T>(NewsArticleDBContext dbContext) : IBaseRepositoryAsync<T> where T : class
{
    protected NewsArticleDBContext _dbContext { get; set; } = dbContext;
    public async Task<T> CreateAsync(T item, CancellationToken ct)
    {
        await _dbContext.Set<T>().AddAsync(item, ct);
        await _dbContext.SaveChangesAsync(ct);

        return item;
    }

    public async Task<int> DeleteAsync(ValueType id, CancellationToken ct)
        => await _dbContext.Set<T>()
            .Where(FindByPrimaryKeyExpression(id))
            .ExecuteDeleteAsync(ct);

    public async Task<List<T>> GetAllAsync(CancellationToken ct)
        => await _dbContext.Set<T>()
            .ToListAsync(ct);

    public async Task<T?> GetByIdAsync(ValueType id, CancellationToken ct)
        => await _dbContext.Set<T>()
            .SingleOrDefaultAsync(FindByPrimaryKeyExpression(id), ct);

    public async Task<T> UpdateAsync(ValueType id, T? entity, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var existingEntity = await GetByIdAsync(id, ct)
            ?? throw new KeyNotFoundException($"Entity with id {id} not found.");

        // Update the existing entity with values from the input entity
        _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

        // Mark entity as modified
        _dbContext.Entry(existingEntity).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync(ct);

        return existingEntity;
    }

    private Expression<Func<T, bool>> FindByPrimaryKeyExpression(ValueType id)
    {
        // Find the primary key property dynamically
        var keyProperty = _dbContext.Model
            .FindEntityType(typeof(T))?
            .FindPrimaryKey()?
            .Properties
            .FirstOrDefault();

        if (keyProperty is null)
            throw new InvalidOperationException("No primary key defined for the entity.");

        var primaryKeyName = keyProperty.Name;

        // Create an expression to find entities by the primary key
        var parameter = Expression.Parameter(typeof(T), "entity");
        var property = Expression.Property(parameter, primaryKeyName);
        var constant = Expression.Constant(id);
        var equal = Expression.Equal(property, Expression.Convert(constant, property.Type));
        return Expression.Lambda<Func<T, bool>>(equal, parameter);
    }
}
