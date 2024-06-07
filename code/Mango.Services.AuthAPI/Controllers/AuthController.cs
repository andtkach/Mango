using Mango.MessageBus;
using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMessageBus _messageBus;
        private readonly IConfiguration _configuration;
        protected ResponseDto _response;

        public AuthController(IAuthService authService,IMessageBus messageBus, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
            _messageBus = messageBus;
            _response = new();
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {

            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message= errorMessage;
                return BadRequest(_response);
            }

            if (_configuration.GetValue<bool>("NotifyAzure") == true)
            {
                await _messageBus.PublishMessage(model.Email,
                    _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue"));
            }

            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var loginResponse = await _authService.Login(model);
            
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            
            _response.Result = loginResponse;

            if (_configuration.GetValue<bool>("NotifyAzure") == true)
            {
                await _messageBus.PublishMessage(model.UserName,
                    _configuration.GetValue<string>("TopicAndQueueNames:LoginUserQueue"));
            }

            return Ok(_response);
        }

        [HttpPost("assignrole")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequest model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }

            if (_configuration.GetValue<bool>("NotifyAzure") == true)
            {
                await _messageBus.PublishMessage(model.Email,
                    _configuration.GetValue<string>("TopicAndQueueNames:AssignRoleQueue"));
            }

            return Ok(_response);
        }
    }
}
