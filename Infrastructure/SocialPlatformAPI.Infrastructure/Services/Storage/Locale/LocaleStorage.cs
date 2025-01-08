using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SocialPlatformAPI.Application.Interfaces.Storage.Locale;

namespace SocialPlatformAPI.Infrastructure.Services.Storage.Locale
{
    public class LocaleStorage(IWebHostEnvironment webHostEnvironment) : Storage, ILocaleStorage
    {
        public async Task DeleteAsync(string path, string fileName)
            => File.Delete($"{path}\\{fileName}");

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(path, file.FileName, HasFile);

                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, path));
            }

            return datas;
        }

        public bool HasFile(string path, string fileName)
            => File.Exists($"{path}\\{fileName}");
    }
}
