﻿using AutoMapper;
using MediatR;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandHandler(IUserService userService, IMapper mapper) : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponseDTO response = await userService.CreateAsync(mapper.Map<CreateUserCommandRequest, CreateUserDTO>(request));
            return mapper.Map<CreateUserResponseDTO, CreateUserCommandResponse>(response);
        }
    }
}
