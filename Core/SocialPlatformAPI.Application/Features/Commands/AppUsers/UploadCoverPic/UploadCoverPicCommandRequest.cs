using MediatR;
using Microsoft.AspNetCore.Http;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.UploadCoverPic
{
    public class UploadCoverPicCommandRequest : IRequest<UploadCoverPicCommandResponse>
    {
        public IFormFileCollection File { get; set; }
    }
}