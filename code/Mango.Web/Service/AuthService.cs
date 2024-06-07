using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> AssignRoleAsync(AssignRoleRequest assignRoleRequest)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.POST,
                Data = assignRoleRequest,
                Url = Constants.AuthAPIBase + "/api/auth/assignrole"
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequest loginRequest)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.POST,
                Data = loginRequest,
                Url = Constants.AuthAPIBase + "/api/auth/login"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> RegisterAsync(RegisterRequest registerRequest)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.POST,
                Data = registerRequest,
                Url = Constants.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }
    }
}
