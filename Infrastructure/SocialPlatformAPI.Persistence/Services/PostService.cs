using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.DTOs.Posts;
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
            AppUser? user = await userService.GetCurrentUser();

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

        public async Task<IList<GetPostDTO>> GetAllPostsAsync(Pagination pagination)
        {
            var posts = await postReadRepository.GetAllByPagingAsync(
                include: x => x.Include(p => p.User).Include(p => p.Likes),
                pageCount: pagination.PageCount,
                itemCount: pagination.ItemCount);
            return mapper.Map<IList<Post>, IList<GetPostDTO>>(posts);
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
