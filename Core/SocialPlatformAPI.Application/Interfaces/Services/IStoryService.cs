using SocialPlatformAPI.Application.DTOs.Stories;

namespace SocialPlatformAPI.Application.Interfaces.Services
{
    public interface IStoryService
    {
        Task CreateStoryAsync(string imageUrl);
        Task DeleteStoryAsync(string id);
        Task<IList<GetStoriesDTO>> GetStoriesAsync();
        Task<IList<StoryDTO>> GetUserStoriesAsync(string username);
    }
}
