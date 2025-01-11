using AutoMapper;
using MediatR;
using SocialPlatformAPI.Application.DTOs.Stories;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.Stories.GetUserStories
{
    public class GetUserStoriesQueryHandler(IStoryService storyService, IMapper mapper) : IRequestHandler<GetUserStoriesQueryRequest, IList<GetUserStoriesQueryResponse>>
    {
        public async Task<IList<GetUserStoriesQueryResponse>> Handle(GetUserStoriesQueryRequest request, CancellationToken cancellationToken)
        {
            IList<StoryDTO> stories = await storyService.GetUserStoriesAsync(request.Username);
            return mapper.Map<IList<StoryDTO>, IList<GetUserStoriesQueryResponse>>(stories);
        }
    }
}
