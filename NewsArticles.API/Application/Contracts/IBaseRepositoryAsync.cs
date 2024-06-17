namespace NewsArticles.API.Application.Contracts;

internal interface IBaseRepositoryAsync<T> where T : class
{
    Task<T> CreateAsync(T item);
    Task<int> DeleteAsync(ValueType id);
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(ValueType id);
    Task<T> UpdateAsync(ValueType id, T? entity);
}
