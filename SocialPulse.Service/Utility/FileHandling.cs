using Microsoft.AspNetCore.Http;

namespace SocialPulse.Service.Utility
{
    public static class FileHandling
    {
        public static string UploadPostFile(IFormFile file, string folderName)
        {
            var folderPath = Directory.GetCurrentDirectory();
            var newGuid = Guid.NewGuid();

            var fileName = Path.Combine("wwwroot","Post",$"{folderName}",$"{newGuid}-{file.FileName}");
            var fileNameReturn = $"Post/{folderName}/{newGuid}-{file.FileName}";
            var filePath = Path.Combine(folderPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileNameReturn;
        }
    }
}
