using System.ComponentModel.DataAnnotations;

namespace CanteenManagement_2._0.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
