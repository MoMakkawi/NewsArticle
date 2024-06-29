using NewsArticles.API.Application.Contracts;

namespace NewsArticles.API.Application.Services;

internal sealed class ImageServiceAsync(IWebHostEnvironment env) : IImageServiceAsync
{
    private readonly Func<string, string> GetFullImagePath = (string imagePath) 
        => Path.Combine(env.WebRootPath, imagePath);

    public Task DeleteAsync(string imageName)
    {
        File.Delete(GetFullImagePath(imageName));
        return Task.CompletedTask;
    }

    public Task<byte[]> GetAsByteArrayAsync(string imageName)
    {
        var fullImagePath = GetFullImagePath(imageName);

        if (!File.Exists(fullImagePath)) throw new FileNotFoundException();

        var imageBytes = File.ReadAllBytes(fullImagePath);
        return Task.FromResult(imageBytes);
    }

    public async Task<string> SaveAsync(IFormFile image)
    {
        var fullImagePath = GetFullImagePath(image.FileName);

        using var stream = new FileStream(fullImagePath, FileMode.Create);
            await image.CopyToAsync(stream);

        return image.FileName;
    }

    public async Task<List<string>> SaveAsync(IFormFileCollection? images)
    {
        if (images is null) return [];

        var saveTasks = images
            .Select(async image => await SaveAsync(image));

        var savedImagesNames = await Task.WhenAll(saveTasks);

        return [.. savedImagesNames];
    }

    public async Task<string> UpdateAsync(string oldImageName, IFormFile newImage)
    {
        await DeleteAsync(oldImageName);
        await SaveAsync(newImage);

        return "updated successfully!";
    }
}
