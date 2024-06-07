namespace Mango.Web.Models
{
    public class LoginResponse
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
