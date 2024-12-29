using SocialPlatformAPI.Application.DTOs.Comments;

namespace SocialPlatformAPI.Application.Interfaces.Services
{
    public interface ICommentService
    {
        Task<IList<GetCommentDTO>> GetCommentsAsync(string postId);
        Task AddCommentAsync(string postId, string content);
        Task DeleteCommentAsync(string id);
    }
}
