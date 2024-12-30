using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Repositories;
using SocialPlatformAPI.Domain.Entities;
using SocialPlatformAPI.Domain.Entities.Identity;
using System.ComponentModel.Design;

namespace SocialPlatformAPI.Persistence.Services
{
    public class LikeService(
        IReadRepository<PostLike> postLikeReadRepository,
        IWriteRepository<PostLike> postLikeWriteRepository,
        IReadRepository<CommentLike> commentLikeReadRepository,
        IWriteRepository<CommentLike> commentLikeWriteRepository,
        IUserService userService) : ILikeService
    {
        public async Task<int> GetCommentLikeCountAsync(string commentId)
            => await commentLikeReadRepository.CountAsync(l => l.CommentId == Guid.Parse(commentId));

        public async Task<int> GetPostLikeCountAsync(string postId)
            => await postLikeReadRepository.CountAsync(l => l.PostId == Guid.Parse(postId));

        public async Task LikeCommentAsync(string commentId)
        {
            AppUser? user = await userService.GetCurrentUser();
            if (user is not null)
            {
                await commentLikeWriteRepository.AddAsync(new() 
                { 
                    CommentId = Guid.Parse(commentId),
                    UserId = user.Id,
                    CreatedDate = DateTime.UtcNow
                });
                await commentLikeWriteRepository.SaveAsync();
            }
        }

        public async Task LikePostAsync(string postId)
        {
            AppUser? user = await userService.GetCurrentUser();
            if(user is not null)
            {
                await postLikeWriteRepository.AddAsync(new() 
                { 
                    PostId = Guid.Parse(postId),
                    UserId = user.Id,
                    CreatedDate = DateTime.UtcNow
                });
                await postLikeWriteRepository.SaveAsync();
            }
        }

        public async Task UndoLikeCommentAsync(string commentId)
        {
            AppUser? user = await userService.GetCurrentUser();
            if (user is not null)
            {
                CommentLike commentLike = await commentLikeReadRepository.GetAsync(
                    predicate: cl => cl.CommentId == Guid.Parse(commentId) && cl.UserId == user.Id,
                    enableTracking: true);
                commentLikeWriteRepository.Remove(commentLike);
                await commentLikeWriteRepository.SaveAsync();
            }
        }

        public async Task UndoLikePostAsync(string postId)
        {
            AppUser? user = await userService.GetCurrentUser();
            if (user is not null)
            {
                PostLike postLike = await postLikeReadRepository.GetAsync(
                    predicate: cl => cl.PostId == Guid.Parse(postId) && cl.UserId == user.Id,
                    enableTracking: true);
                postLikeWriteRepository.Remove(postLike);
                await postLikeWriteRepository.SaveAsync();
            }
        }
    }
}
