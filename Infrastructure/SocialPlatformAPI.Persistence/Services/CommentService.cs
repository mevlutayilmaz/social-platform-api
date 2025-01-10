using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialPlatformAPI.Application.DTOs.Comments;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Repositories;
using SocialPlatformAPI.Domain.Entities;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Persistence.Services
{
    public class CommentService(
        IReadRepository<Comment> commentReadRepository,
        IWriteRepository<Comment> commentWriteRepository,
        IUserService userService,
        IMapper mapper) : ICommentService
    {
        public async Task AddCommentAsync(string postId, string content)
        {
            AppUser? user = await userService.GetCurrentUserAsync();
            if (user is not null)
            {
                await commentWriteRepository.AddAsync(new()
                {
                    Content = content,
                    PostId = Guid.Parse(postId),
                    UserId = user.Id
                });
                await commentWriteRepository.SaveAsync();
            }
        }

        public async Task DeleteCommentAsync(string id)
        {
            await commentWriteRepository.RemoveAsync(id);
            await commentWriteRepository.SaveAsync();
        }

        public async Task<IList<GetCommentDTO>> GetCommentsAsync(string postId)
        {
            AppUser? user = await userService.GetCurrentUserAsync();

            if (user is not null)
            {
                return await commentReadRepository.Table
                    .Include(c => c.User)
                    .Include(c => c.Likes)
                    .OrderByDescending(c => c.CreatedDate)
                    .Where(c => c.PostId == Guid.Parse(postId))
                    .Select(c => new GetCommentDTO
                    {
                        Id = c.Id.ToString(),
                        Content = c.Content,
                        CreatedDate = c.CreatedDate,
                        LikeCount = c.Likes.Count,
                        IsLiked = c.Likes.Any(l => l.UserId == user.Id),
                        User = mapper.Map<AppUser, GetUserDTO>(c.User)
                    }).ToListAsync();
            }
            throw new Exception("User not found!");
        }
    }
}
