using LightCommerce.Application.Common.Models;
using LightCommerce.Application.Users.Commands.CreateUser;
using LightCommerce.Application.Users.Commands.UpdateUser;
using LightCommerce.Application.Users.Share;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightCommerce.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(CreateUserDto userDto);

        Task<(Result Result, string UserId)> UpdateUserAsync(UpdateUserDto userDto);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
