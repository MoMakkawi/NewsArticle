namespace NewsArticles.API.Application.Contracts;

internal interface IImageServiceAsync 
{
    Task<string> SaveAsync(IFormFile image);
    Task<List<string>> SaveAsync(List<IFormFile>? image);
    Task DeleteAsync(string imageName);
    Task<byte[]> GetAsByteArrayAsync(string imageName);
    Task<string> UpdateAsync(string oldImageName, IFormFile newImage);
}
