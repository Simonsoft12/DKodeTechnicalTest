namespace MyAPI.Services.FileDownloadService
{
    public class FileDownloadService : IFileDownloadService
    {
        private readonly string _downloadFolder;

        public FileDownloadService(IConfiguration configuration)
        {
            _downloadFolder = Path.Combine(Directory.GetCurrentDirectory(), configuration["DownloadFolder"]);
            if (!Directory.Exists(_downloadFolder))
            {
                Directory.CreateDirectory(_downloadFolder);
            }
        }

        public async Task<string> DownloadCsvAsync(string fileUrl, string fileName)
        {
            var filePath = Path.Combine(_downloadFolder, fileName);

            using (var client = new HttpClient())
            {
                var fileBytes = await client.GetByteArrayAsync(fileUrl);
                await File.WriteAllBytesAsync(filePath, fileBytes);
            }

            return filePath;
        }
    }
}
