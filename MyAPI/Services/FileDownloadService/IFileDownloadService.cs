namespace MyAPI.Services.FileDownloadService
{
    public interface IFileDownloadService
    {
        Task<string> DownloadCsvAsync(string fileUrl, string fileName);
    }

}
