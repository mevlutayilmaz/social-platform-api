using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialPlatformAPI.Application.DTOs.Comments;
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
            IList<Comment> comments = await commentReadRepository.GetAllAsync(
                include: x => x.Include(c => c.User).Include(c => c.Likes),
                predicate: c => c.PostId == Guid.Parse(postId));
            return mapper.Map<IList<Comment>, IList<GetCommentDTO>>(comments);
        }
    }
}
