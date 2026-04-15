namespace ERP.Application.Common.Models;

public class FileStorageSettings
{
    public string ServerType { get; set; } = "Local"; // "Cloud" or "Local"
    public string FolderPath { get; set; } = string.Empty;
    public string FTPUserName { get; set; } = string.Empty;
    public string FTPPassword { get; set; } = string.Empty;
}
