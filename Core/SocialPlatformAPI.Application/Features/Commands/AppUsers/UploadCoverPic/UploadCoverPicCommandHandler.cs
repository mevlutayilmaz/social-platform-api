using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Interfaces.Storage;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.UploadCoverPic
{
    public class UploadCoverPicCommandHandler(IUserService userService, IStorageService storageService) : IRequestHandler<UploadCoverPicCommandRequest, UploadCoverPicCommandResponse>
    {
        public async Task<UploadCoverPicCommandResponse> Handle(UploadCoverPicCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.File is not null && request.File.Any())
            {
                var files = await storageService.UploadAsync("cover-images", request.File);
                var coverPic = files.Select(f => $"https://localhost:7245/{f.pathOrContainerName}/{f.fileName}").First();
                await userService.UpdateUserCoverPicAsync(coverPic);
            }
            return new();
        }
    }
}
