using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Interfaces.Storage;

namespace SocialPlatformAPI.Application.Features.Commands.Stories.CreateStory
{
    public class CreateStoryCommandHandler(IStoryService storyService, IStorageService storageService) : IRequestHandler<CreateStoryCommandRequest, CreateStoryCommandResponse>
    {
        public async Task<CreateStoryCommandResponse> Handle(CreateStoryCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.File is not null && request.File.Any())
            {
                var files = await storageService.UploadAsync("story-images", request.File);
                string fileName = files.Select(f => $"https://localhost:7245/{f.pathOrContainerName}/{f.fileName}").First();
                await storyService.CreateStoryAsync(fileName);
            }
            return new();
        }
    }
}
