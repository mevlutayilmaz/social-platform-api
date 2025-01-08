using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialPlatformAPI.Application.DTOs.Stories;
using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Repositories;
using SocialPlatformAPI.Domain.Entities;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Persistence.Services
{
    public class StoryService(
        IReadRepository<Story> storyReadRepository,
        IWriteRepository<Story> storyWriteRepository,
        IMapper mapper,
        IUserService userService) : IStoryService
    {
        public async Task CreateStoryAsync(string imageUrl)
        {
            AppUser? user = await userService.GetCurrentUserAsync();
            if (user is not null)
            {
                await storyWriteRepository.AddAsync(new() { ImageUrl = imageUrl, User = user });
                await storyWriteRepository.SaveAsync();
            }
        }

        public async Task DeleteStoryAsync(string id)
        {
            await storyWriteRepository.RemoveAsync(id);
            await storyWriteRepository.SaveAsync();
        }

        public async Task<IList<GetStoriesDTO>> GetStoriesAsync()
        {
            var stories = await storyReadRepository.GetAllAsync(
                include: x => x.Include(s => s.User),
                orderBy: x => x.OrderByDescending(s => s.CreatedDate));
            return mapper.Map<IList<Story>, IList<GetStoriesDTO>>(stories);
        }
    }
}
