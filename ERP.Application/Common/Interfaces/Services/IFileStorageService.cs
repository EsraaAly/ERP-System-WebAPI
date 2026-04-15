namespace ERP.Application.Common.Interfaces.Services;

public interface IFileStorageService
{
    Task UploadFilesAsync(string subFolderName, IEnumerable<string> sourceFilePaths);
    Task UploadFileAsync(string subFolderName, string sourceFilePath, string? destinationFileName = null);
    Task<Stream?> OpenFileAsync(string subFolderName, string fileName);
    Task<bool> DeleteFileAsync(string subFolderName, string fileName);
    Task<IEnumerable<string>> GetFilesAsync(string subFolderName);
    Task<bool> DeleteFolderAsync(string folderName);
    Task<string> GetFullPath(string subFolderName, string fileName);
}
