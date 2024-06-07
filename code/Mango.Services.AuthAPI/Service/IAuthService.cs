using Mango.Services.AuthAPI.Models.Dto;

namespace Mango.Services.AuthAPI.Service
{
    public interface IAuthService
    {
        Task<string> Register(RegisterRequest registerRequest);
        Task<LoginResponseDto> Login(LoginRequest loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
