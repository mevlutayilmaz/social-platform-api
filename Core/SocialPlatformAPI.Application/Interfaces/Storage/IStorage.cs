using Microsoft.AspNetCore.Http;

namespace SocialPlatformAPI.Application.Interfaces.Storage
{
    public interface IStorage
    {
        Task<IList<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);
        Task DeleteAsync(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
