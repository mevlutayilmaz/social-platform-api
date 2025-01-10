using AutoMapper;
using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.DTOs.Comments;
using SocialPlatformAPI.Application.DTOs.Posts;
using SocialPlatformAPI.Application.DTOs.Stories;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.CreateUser;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.UpdateUser;
using SocialPlatformAPI.Application.Features.Commands.Auth.RefreshTokenLogin;
using SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowers;
using SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowing;
using SocialPlatformAPI.Application.Features.Queries.AppUsers.GetUserByUsername;
using SocialPlatformAPI.Application.Features.Queries.AppUsers.SuggestionsUser;
using SocialPlatformAPI.Application.Features.Queries.Comments.GetComments;
using SocialPlatformAPI.Application.Features.Queries.Posts.GetAllPosts;
using SocialPlatformAPI.Application.Features.Queries.Posts.GetPostById;
using SocialPlatformAPI.Application.Features.Queries.Stories.GetStories;
using SocialPlatformAPI.Domain.Entities;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<GetPostDTO, GetAllPostsQueryResponse>().ReverseMap();
            CreateMap<GetPostDTO, GetPostByIdQueryResponse>().ReverseMap();
            CreateMap<CreatePostDTO, Post>().ReverseMap();
            CreateMap<GetPostDTO, Post>();
            CreateMap<Post, GetPostDTO>().ForMember(dest => dest.LikeCount, options => options.MapFrom(src => src.Likes.Count));

            CreateMap<GetStoriesDTO, Story>().ReverseMap();
            CreateMap<GetStoriesDTO, GetStoriesQueryResponse>().ReverseMap();

            CreateMap<AppUser, CreateUserCommandRequest>().ReverseMap();
            CreateMap<AppUser, GetUserDTO>().ReverseMap();
            CreateMap<GetFollowersQueryResponse, GetUserDTO>().ReverseMap();
            CreateMap<GetFollowingQueryResponse, GetUserDTO>().ReverseMap();
            CreateMap<SuggestionsUserQueryResponse, GetUserDTO>().ReverseMap();
            CreateMap<CreateUserDTO, CreateUserCommandRequest>().ReverseMap();
            CreateMap<CreateUserResponseDTO, CreateUserCommandResponse>().ReverseMap();
            CreateMap<GetUserByUsernameDTO, GetUserByUsernameQueryResponse>().ReverseMap();
            CreateMap<GetUserByUsernameDTO, AppUser>();
            CreateMap<AppUser, GetUserByUsernameDTO>()
                .ForMember(dest => dest.Follower, options => options.MapFrom(src => src.Followers.Count))
                .ForMember(dest => dest.Following, options => options.MapFrom(src => src.Following.Count));
            CreateMap<UpdateUserDTO, AppUser>().ReverseMap();
            CreateMap<UpdateUserDTO, UpdateUserCommandRequest>().ReverseMap();

            CreateMap<TokenDTO, RefreshTokenLoginCommandResponse>().ReverseMap();

            CreateMap<GetCommentDTO, Comment>();
            CreateMap<Comment, GetCommentDTO>().ForMember(dest => dest.LikeCount, options => options.MapFrom(src => src.Likes.Count));
            CreateMap<GetCommentDTO, GetCommentsQueryResponse>().ReverseMap();
        }
    }
}
