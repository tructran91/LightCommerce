﻿namespace LightCommerce.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        string Name { get; }
    }
}
