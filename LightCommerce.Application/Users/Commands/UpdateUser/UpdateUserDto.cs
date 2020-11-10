﻿using LightCommerce.Application.Common.Interfaces;
using LightCommerce.Application.Common.Models;
using LightCommerce.Application.Users.Share;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LightCommerce.Application.Users.Commands.UpdateUser
{
    public class UpdateUserDto : UserDto, IRequest<string>
    {
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserDto, string>
    {
        private readonly IIdentityService _identityService;

        public UpdateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(UpdateUserDto request, CancellationToken cancellationToken)
        {
            (Result Result, string UserId) result = await _identityService.UpdateUserAsync(request);

            return result.UserId;
        }
    }
}
