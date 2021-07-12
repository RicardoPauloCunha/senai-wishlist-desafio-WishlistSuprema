using System.ComponentModel.DataAnnotations;

namespace WebApi.WishList.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
