using AutoMapper;
using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.DTOs.Comments;
using SocialPlatformAPI.Application.DTOs.Posts;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.CreateUser;
using SocialPlatformAPI.Application.Features.Commands.Auth.Login;
using SocialPlatformAPI.Application.Features.Commands.Auth.RefreshTokenLogin;
using SocialPlatformAPI.Application.Features.Commands.Posts.CreatePost;
using SocialPlatformAPI.Application.Features.Queries.Comments.GetComments;
using SocialPlatformAPI.Application.Features.Queries.Posts.GetAllPosts;
using SocialPlatformAPI.Application.Features.Queries.Posts.GetPostById;
using SocialPlatformAPI.Domain.Entities;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<GetPostDTO, GetAllPostsQueryResponse>().ReverseMap();
            CreateMap<CreatePostDTO, CreatePostCommandRequest>().ReverseMap();
            CreateMap<GetPostDTO, GetPostByIdQueryResponse>().ReverseMap();
            CreateMap<CreatePostDTO, Post>().ReverseMap();
            CreateMap<GetPostDTO, Post>();
            CreateMap<Post, GetPostDTO>().ForMember(dest => dest.LikeCount, options => options.MapFrom(src => src.Likes.Count));

            CreateMap<AppUser, CreateUserCommandRequest>().ReverseMap();
            CreateMap<AppUser, GetUserDTO>().ReverseMap();
            CreateMap<CreateUserDTO, CreateUserCommandRequest>().ReverseMap();
            CreateMap<CreateUserResponseDTO, CreateUserCommandResponse>().ReverseMap();

            CreateMap<TokenDTO, LoginCommandResponse>().ReverseMap();
            CreateMap<TokenDTO, RefreshTokenLoginCommandResponse>().ReverseMap();

            CreateMap<GetCommentDTO, Comment>().ReverseMap();
            CreateMap<GetCommentDTO, GetCommentsQueryResponse>().ReverseMap();
        }
    }
}
