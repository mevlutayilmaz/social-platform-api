using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialPlatformAPI.Application.DTOs.Stories;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Repositories;
using SocialPlatformAPI.Domain.Entities;
using SocialPlatformAPI.Domain.Entities.Identity;
using System.Linq;

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
            AppUser? user = await userService.GetCurrentUserAsync();
            if (user is not null)
                return await storyReadRepository.Table
                    .AsNoTracking()
                    .Include(s => s.User)
                    .ThenInclude(u => u.Followers)
                    .Where(s => s.UserId != user.Id && s.User.Followers.Any(f => f.FollowerId == user.Id))
                    .GroupBy(s => s.User)
                    .Select(group => new GetStoriesDTO()
                    {
                        User = mapper.Map<AppUser, GetUserDTO>(group.Key),
                        Stories = group.Select(story => new StoryDTO()
                        {
                            Id = story.Id.ToString(),
                            ImageUrl = story.ImageUrl,
                            CreatedDate = story.CreatedDate
                        }).OrderByDescending(s => s.CreatedDate).ToList()
                    }).ToListAsync();

            throw new Exception("User not found!");
        }

        public async Task<IList<StoryDTO>> GetUserStoriesAsync(string username)
        {
            if(!string.IsNullOrEmpty(username))
            {
                IList<Story> stories = await storyReadRepository.GetAllAsync(
                    predicate: s => s.User.UserName == username,
                    orderBy: x => x.OrderByDescending(s => s.CreatedDate));
                return mapper.Map<IList<Story>, IList<StoryDTO>>(stories);
            }

            throw new Exception("User not found!");
        }
    }
}
