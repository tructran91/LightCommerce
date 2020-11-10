﻿using LightCommerce.Application.Common.Interfaces;
using LightCommerce.Application.Common.Models;
using LightCommerce.Application.Users.Share;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LightCommerce.Application.Users.Commands.CreateUser
{
    public class CreateUserDto : UserDto, IRequest<string>
    {
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserDto, string>
    {
        private readonly IIdentityService _identityService;

        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(CreateUserDto request, CancellationToken cancellationToken)
        {
            (Result Result, string UserId) result = await _identityService.CreateUserAsync(request);

            return result.UserId;
        }
    }
}
