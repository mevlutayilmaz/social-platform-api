namespace SocialPlatformAPI.Application.Interfaces.Services
{
    public interface ILikeService
    {
        Task LikePostAsync(string postId);
        Task LikeCommentAsync(string commentId);
        Task UndoLikePostAsync(string postId);
        Task UndoLikeCommentAsync(string commentId);
        Task<int> GetCommentLikeCountAsync(string commentId);
        Task<int> GetPostLikeCountAsync(string postId);
        Task<bool> IsPostLikedAsync(string postId);
    }
}
