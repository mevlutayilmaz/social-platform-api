using AutoMapper;
using MediatR;
using SocialPlatformAPI.Application.DTOs.Stories;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.Stories.GetStories
{
    public class GetStoriesQueryHandler(IStoryService storyService, IMapper mapper) : IRequestHandler<GetStoriesQueryRequest, IList<GetStoriesQueryResponse>>
    {
        public async Task<IList<GetStoriesQueryResponse>> Handle(GetStoriesQueryRequest request, CancellationToken cancellationToken)
        {
            IList<GetStoriesDTO> stories = await storyService.GetStoriesAsync();
            return mapper.Map<IList<GetStoriesDTO>, IList<GetStoriesQueryResponse>>(stories);
        }
    }
}
