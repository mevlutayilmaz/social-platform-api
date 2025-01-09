using MediatR;
using Microsoft.AspNetCore.Http;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.UploadProfilePic
{
    public class UploadProfilePicCommandRequest : IRequest<UploadProfilePicCommandResponse>
    {
        public IFormFileCollection File { get; set; }
    }
}