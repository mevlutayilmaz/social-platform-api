namespace SocialPlatformAPI.Application.Interfaces.Services
{
    public interface ILikeService
    {
        Task LikePostAsync(string postId);
        Task<int> GetLikeCountAsync(string postId);
    }
}
