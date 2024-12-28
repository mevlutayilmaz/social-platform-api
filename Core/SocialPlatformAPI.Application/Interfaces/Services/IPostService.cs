using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.DTOs.Posts;

namespace SocialPlatformAPI.Application.Interfaces.Services
{
    public interface IPostService
    {
        Task<IList<GetPostDTO>> GetAllPostsAsync(Pagination pagination);
        Task<GetPostDTO> GetPostByIdAsync(string postId);
        Task CreatePostAsync(CreatePostDTO post);
        Task DeletePostAsync(string postId);
    }
}
