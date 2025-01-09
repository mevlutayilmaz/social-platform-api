using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Bio { get; set; }
    }
}