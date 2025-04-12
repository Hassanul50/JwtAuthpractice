using JwtAuthpractice.Entity;
using JwtAuthpractice.Models;

namespace JwtAuthpractice.Service
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO request);
        Task<string?> LoginAsync(UserDTO request);
    }
}
