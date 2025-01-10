using AutoMapper;
using MediatR;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.SuggestionsUser
{
    public class SuggestionsUserQueryHandler(IUserService userService, IMapper mapper) : IRequestHandler<SuggestionsUserQueryRequest, IList<SuggestionsUserQueryResponse>>
    {
        public async Task<IList<SuggestionsUserQueryResponse>> Handle(SuggestionsUserQueryRequest request, CancellationToken cancellationToken)
        {
            IList<GetUserDTO> users = await userService.SuggestionsUserAsync();
            return mapper.Map<IList<GetUserDTO>, IList<SuggestionsUserQueryResponse>>(users);
        }
    }
}
