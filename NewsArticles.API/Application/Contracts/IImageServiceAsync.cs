namespace NewsArticles.API.Application.Contracts;

internal interface IImageServiceAsync 
{
    Task<string> SaveAsync(IFormFile image);
    Task<List<string>> SaveAsync(IFormFileCollection? images);
    Task DeleteAsync(string imageName);
    Task<byte[]> GetAsByteArrayAsync(string imageName);
    Task<string> UpdateAsync(string oldImageName, IFormFile newImage);
}
