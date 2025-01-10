using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.SuggestionsUser
{
    public class SuggestionsUserQueryRequest : IRequest<IList<SuggestionsUserQueryResponse>>
    {
    }
}