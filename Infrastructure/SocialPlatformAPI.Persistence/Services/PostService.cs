using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.DTOs.Posts;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Repositories;
using SocialPlatformAPI.Domain.Entities;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Persistence.Services
{
    public class PostService(
        IReadRepository<Post> postReadRepository,
        IWriteRepository<Post> postWriteRepository,
        IUserService userService,
        IMapper mapper) : IPostService
    {
        public async Task CreatePostAsync(CreatePostDTO post)
        {
            AppUser? user = await userService.GetCurrentUserAsync();

            if (user is not null)
            {
                post.UserId = user.Id;
                bool result = await postWriteRepository.AddAsync(mapper.Map<CreatePostDTO, Post>(post));
                await postWriteRepository.SaveAsync();
            }
        }

        public async Task DeletePostAsync(string postId)
        {
            bool result = await postWriteRepository.RemoveAsync(postId);
            await postWriteRepository.SaveAsync();
        }

        public async Task<IList<GetPostDTO>> GetAllPostsAsync(Pagination pagination, string? username = null)
        {
            AppUser? user = await userService.GetCurrentUserAsync();
            if (user is not null)
            {
                var query = postReadRepository.Table.AsQueryable().AsNoTracking();
                if (!string.IsNullOrEmpty(username)) query = query.Where(p => p.User.UserName == username);
                return await query.Include(p => p.User)
                    .Include(p => p.User)
                    .ThenInclude(u => u.Followers)
                    .Include(p => p.Likes)
                    .OrderByDescending(p => p.CreatedDate)
                    .Where(p => p.User.Followers.Any(f => f.FollowerId == user.Id))
                    .Skip(pagination.ItemCount * (pagination.PageCount - 1))
                    .Take(pagination.ItemCount)
                    .Select(p => new GetPostDTO
                    {
                        Id = p.Id.ToString(),
                        Content = p.Content,
                        CreatedDate = p.CreatedDate,
                        MediaUrl = p.MediaUrl,
                        LikeCount = p.Likes.Count,
                        IsLiked = p.Likes.Any(l => l.UserId == user.Id),
                        User = mapper.Map<AppUser, GetUserDTO>(p.User)
                    }).ToListAsync();
            }
            throw new Exception("User not found!");
        }

        public async Task<GetPostDTO> GetPostByIdAsync(string postId)
        {
            Post post = await postReadRepository.GetAsync(
                predicate: p => p.Id == Guid.Parse(postId),
                include: x => x.Include(p => p.User).Include(p => p.Likes));
            return mapper.Map<Post, GetPostDTO>(post);
        }
    }
}
