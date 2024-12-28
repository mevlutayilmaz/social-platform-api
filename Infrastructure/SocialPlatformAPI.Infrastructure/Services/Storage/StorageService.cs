﻿using Microsoft.AspNetCore.Http;
using SocialPlatformAPI.Application.Interfaces.Storage;

namespace SocialPlatformAPI.Infrastructure.Services.Storage
{
    public class StorageService(IStorage storage) : IStorageService
    {
        public string StorageName => storage.GetType().Name;

        public async Task DeleteAsync(string pathOrContainerName, string fileName)
            => await storage.DeleteAsync(pathOrContainerName, fileName);

        public List<string> GetFiles(string pathOrContainerName)
            => storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName)
            => storage.HasFile(pathOrContainerName, fileName);

        public async Task<IList<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
            => await storage.UploadAsync(pathOrContainerName, files);
    }
}
