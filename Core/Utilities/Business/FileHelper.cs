using Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Business;

public class FileHelper
{
    private const string ImageDirectoryPath = "wwwroot/CarImages/";
    public static readonly string DefaultImagePath = "/Users/kaankahveci/Desktop/default.jpeg";
    
    public static IDataResult<string> Upload(IFormFile file)
    {
        var newGuidPath = CreateUniqueFilename(file.FileName);
        var directory = GetImageDirectory();
        EnsureDirectoryExists(directory);
        
        var path = Path.Combine(directory, newGuidPath);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return new SuccessDataResult<string>(newGuidPath, "File uploaded successfully.");
    }
    
    public static IResult Delete(string path)
    {
        var directory = GetImageDirectory();
        var filePath = Path.Combine(directory, path);
    
        if (!File.Exists(filePath))
        {
            return new ErrorResult("File does not exist.");
        }
    
        try
        {
            File.Delete(filePath);
        }
        catch (Exception ex)
        {
            return new ErrorResult($"An error occurred while deleting the file: {ex.Message}");
        }
    
        return new SuccessResult();
    }

    public static IDataResult<string> Update(IFormFile file, string oldPath)
    {
        var newGuidPath = CreateUniqueFilename(file.FileName);
        var directory = GetImageDirectory();
        EnsureDirectoryExists(directory);
        
        var path = Path.Combine(directory, newGuidPath);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        File.Delete(Path.Combine(directory, oldPath));
        return new SuccessDataResult<string>(newGuidPath);
    }

    private static string CreateUniqueFilename(string oldFileName)
    {
        string fileExtension = Path.GetExtension(oldFileName);
        string guid = Guid.NewGuid().ToString("N");
        return $"{guid}{fileExtension}";
    }

    private static string GetImageDirectory()
    {
        return ImageDirectoryPath;
    }
    
    private static void EnsureDirectoryExists(string directory)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }
}