using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Repositories;
using SocialPlatformAPI.Domain.Entities;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Persistence.Services
{
    public class LikeService(
        IReadRepository<Like> likeReadRepository,
        IWriteRepository<Like> likeWriteRepository,
        IUserService userService) : ILikeService
    {
        public async Task<int> GetLikeCountAsync(string postId)
            => await likeReadRepository.CountAsync(l => l.PostId == Guid.Parse(postId));

        public async Task LikePostAsync(string postId)
        {
            AppUser? user = await userService.GetCurrentUser();
            if(user is not null)
            {
                await likeWriteRepository.AddAsync(new() { PostId = Guid.Parse(postId), UserId = user.Id });
                await likeWriteRepository.SaveAsync();
            }
        }
    }
}
