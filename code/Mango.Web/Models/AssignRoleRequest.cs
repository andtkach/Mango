using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models
{
    public class AssignRoleRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
