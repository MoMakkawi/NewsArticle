namespace NewsArticles.API.Application.Contracts;

internal interface IBaseRepositoryAsync<T> where T : class
{
    Task<T> CreateAsync(T item, CancellationToken ct);
    Task<int> DeleteAsync(ValueType id, CancellationToken ct);
    Task<List<T>> GetAllAsync(CancellationToken ct);
    Task<T?> GetByIdAsync(ValueType id, CancellationToken ct);
    Task<T> UpdateAsync(ValueType id, T? entity, CancellationToken ct);
}
