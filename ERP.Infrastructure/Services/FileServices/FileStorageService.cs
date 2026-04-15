using System.Net;
using ERP.Application.Common.Interfaces.Services;
using ERP.Application.Common.Models;
using Microsoft.Extensions.Options;

namespace ERP.Infrastructure.Services.FileServices;

public class FileStorageService : IFileStorageService
{
    private readonly FileStorageSettings _settings;

    public FileStorageService(IOptions<FileStorageSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task UploadFilesAsync(string subFolderName, IEnumerable<string> sourceFilePaths)
    {
        foreach (var path in sourceFilePaths)
        {
            await UploadFileAsync(subFolderName, path);
        }
    }

    public async Task UploadFileAsync(string subFolderName, string sourceFilePath, string? destinationFileName = null)
    {
        if (!File.Exists(sourceFilePath)) return;

        await CreateDirectoryInternalAsync(subFolderName);

        var fileName = destinationFileName ?? Path.GetFileName(sourceFilePath);

        if (_settings.ServerType.Equals("Cloud", StringComparison.OrdinalIgnoreCase))
        {
            await UploadToFtpAsync(sourceFilePath, subFolderName, fileName);
        }
        else
        {
            var destPath = Path.Combine(_settings.FolderPath, subFolderName, fileName);
            await Task.Run(() => File.Copy(sourceFilePath, destPath, true));
        }
    }

    public async Task<Stream?> OpenFileAsync(string subFolderName, string fileName)
    {
        if (_settings.ServerType.Equals("Cloud", StringComparison.OrdinalIgnoreCase))
        {
            return await DownloadFromFtpAsync(subFolderName, fileName);
        }
        else
        {
            var path = Path.Combine(_settings.FolderPath, subFolderName, fileName);
            if (!File.Exists(path)) return null;
            
            return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
        }
    }

    public async Task<bool> DeleteFileAsync(string subFolderName, string fileName)
    {
        try
        {
            if (_settings.ServerType.Equals("Cloud", StringComparison.OrdinalIgnoreCase))
            {
                return await DeleteFromFtpAsync(subFolderName, fileName);
            }
            else
            {
                var path = Path.Combine(_settings.FolderPath, subFolderName, fileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<string>> GetFilesAsync(string subFolderName)
    {
        if (_settings.ServerType.Equals("Cloud", StringComparison.OrdinalIgnoreCase))
        {
            return await GetFilesFromFtpAsync(subFolderName);
        }
        else
        {
            var path = Path.Combine(_settings.FolderPath, subFolderName);
            if (!Directory.Exists(path)) return Enumerable.Empty<string>();
            return Directory.GetFiles(path).Select(Path.GetFileName).ToList()!;
        }
    }

    private async Task<IEnumerable<string>> GetFilesFromFtpAsync(string subFolder)
    {
        try
        {
            var baseUri = _settings.FolderPath.EndsWith("/") ? _settings.FolderPath : _settings.FolderPath + "/";
            var uri = new Uri($"{baseUri}{subFolder}");

            var request = (FtpWebRequest)WebRequest.Create(uri);
            request.Credentials = new NetworkCredential(_settings.FTPUserName, _settings.FTPPassword);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            using var response = (FtpWebResponse)await request.GetResponseAsync();
            using var responseStream = response.GetResponseStream();
            using var reader = new StreamReader(responseStream);

            var files = new List<string>();
            while (!reader.EndOfStream)
            {
                var file = await reader.ReadLineAsync();
                if (!string.IsNullOrEmpty(file))
                {
                    files.Add(file);
                }
            }
            return files;
        }
        catch
        {
            return Enumerable.Empty<string>();
        }
    }

    private async Task CreateDirectoryInternalAsync(string folderName)
    {
        if (_settings.ServerType.Equals("Cloud", StringComparison.OrdinalIgnoreCase))
        {
            await CreateFtpDirectoryAsync(folderName);
        }
        else
        {
            var path = Path.Combine(_settings.FolderPath, folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }

    private async Task CreateFtpDirectoryAsync(string folderName)
    {
        var baseUri = _settings.FolderPath.EndsWith("/") ? _settings.FolderPath : _settings.FolderPath + "/";
        var uri = new Uri($"{baseUri}{folderName}");
        var request = (FtpWebRequest)WebRequest.Create(uri);
        request.Credentials = new NetworkCredential(_settings.FTPUserName, _settings.FTPPassword);
        request.Method = WebRequestMethods.Ftp.MakeDirectory;

        try
        {
            using var response = (FtpWebResponse)await request.GetResponseAsync();
        }
        catch (WebException ex)
        {
            if (ex.Response is FtpWebResponse response && response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
            {
                // Directory likely already exists
            }
            else
            {
                throw;
            }
        }
    }

    private async Task UploadToFtpAsync(string sourcePath, string subFolder, string fileName)
    {
        var baseUri = _settings.FolderPath.EndsWith("/") ? _settings.FolderPath : _settings.FolderPath + "/";
        var uri = new Uri($"{baseUri}{subFolder}/{fileName}");
        
        var request = (FtpWebRequest)WebRequest.Create(uri);
        request.Credentials = new NetworkCredential(_settings.FTPUserName, _settings.FTPPassword);
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.UseBinary = true;

        using (var fileStream = File.OpenRead(sourcePath))
        using (var requestStream = await request.GetRequestStreamAsync())
        {
            await fileStream.CopyToAsync(requestStream);
        }
    }

    private async Task<Stream?> DownloadFromFtpAsync(string subFolder, string fileName)
    {
        try
        {
            var baseUri = _settings.FolderPath.EndsWith("/") ? _settings.FolderPath : _settings.FolderPath + "/";
            var uri = new Uri($"{baseUri}{subFolder}/{fileName}");

            var request = (FtpWebRequest)WebRequest.Create(uri);
            request.Credentials = new NetworkCredential(_settings.FTPUserName, _settings.FTPPassword);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.UseBinary = true;

            var response = (FtpWebResponse)await request.GetResponseAsync();
            return response.GetResponseStream();
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> DeleteFolderAsync(string folderName)
    {
        try
        {
            if (_settings.ServerType.Equals("Cloud", StringComparison.OrdinalIgnoreCase))
            {
                return await DeleteFtpDirectoryAsync(folderName);
            }
            else
            {
                var path = Path.Combine(_settings.FolderPath, folderName);
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true); // true for recursive delete
                    return true;
                }
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    private async Task<bool> DeleteFtpDirectoryAsync(string folderName)
    {
        try
        {
            // FTP requires deleting files inside before deleting the directory
            var files = await GetFilesFromFtpAsync(folderName);
            foreach (var file in files)
            {
                await DeleteFromFtpAsync(folderName, file);
            }

            var baseUri = _settings.FolderPath.EndsWith("/") ? _settings.FolderPath : _settings.FolderPath + "/";
            var uri = new Uri($"{baseUri}{folderName}");

            var request = (FtpWebRequest)WebRequest.Create(uri);
            request.Credentials = new NetworkCredential(_settings.FTPUserName, _settings.FTPPassword);
            request.Method = WebRequestMethods.Ftp.RemoveDirectory;

            using var response = (FtpWebResponse)await request.GetResponseAsync();
            return response.StatusCode == FtpStatusCode.FileActionOK || response.StatusCode == FtpStatusCode.CommandOK;
        }
        catch
        {
            return false;
        }
    }

    private async Task<bool> DeleteFromFtpAsync(string subFolder, string fileName)
    {
        var baseUri = _settings.FolderPath.EndsWith("/") ? _settings.FolderPath : _settings.FolderPath + "/";
        var uri = new Uri($"{baseUri}{subFolder}/{fileName}");

        var request = (FtpWebRequest)WebRequest.Create(uri);
        request.Credentials = new NetworkCredential(_settings.FTPUserName, _settings.FTPPassword);
        request.Method = WebRequestMethods.Ftp.DeleteFile;

        using var response = (FtpWebResponse)await request.GetResponseAsync();
        return response.StatusCode == FtpStatusCode.FileActionOK || response.StatusCode == FtpStatusCode.CommandOK;
    }

    public async Task<string> GetFullPath(string subFolderName, string fileName)
    {
        if (_settings.ServerType.Equals("Cloud", StringComparison.OrdinalIgnoreCase))
        {
            var baseUri = _settings.FolderPath.TrimEnd('/');
            return $"{baseUri}/{subFolderName.Trim('/')}/{fileName.Trim('/')}";
        }
        else
        {
            var basePath = _settings.FolderPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var subPath = subFolderName.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            return Path.Combine(basePath, subPath, fileName);
        }
    }
}
