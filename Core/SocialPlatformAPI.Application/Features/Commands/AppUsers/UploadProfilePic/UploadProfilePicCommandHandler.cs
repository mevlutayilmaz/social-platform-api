using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Interfaces.Storage;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.UploadProfilePic
{
    public class UploadProfilePicCommandHandler(IUserService userService, IStorageService storageService) : IRequestHandler<UploadProfilePicCommandRequest, UploadProfilePicCommandResponse>
    {
        public async Task<UploadProfilePicCommandResponse> Handle(UploadProfilePicCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.File is not null && request.File.Any())
            {
                var files = await storageService.UploadAsync("profile-images", request.File);
                var profilePic = files.Select(f => $"https://localhost:7245/{f.pathOrContainerName}/{f.fileName}").First();
                await userService.UpdateUserProfilePicAsync(profilePic);
                return new() { ProfilePicture =  profilePic};
            }
            return new();
        }
    }
}
