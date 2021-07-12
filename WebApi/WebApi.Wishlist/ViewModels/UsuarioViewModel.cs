using System.ComponentModel.DataAnnotations;

namespace WebApi.WishList.Domains
{
    public class UsuarioViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome do usuario é obrigatorio")]
        [StringLength(maximumLength: 100, ErrorMessage = "Quantidade de carateres excede o limite")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Email do usuario é obrigatorio")]
        [StringLength(maximumLength: 250, ErrorMessage = "Quantidade de caracteres invalidas")]
        [EmailAddress(ErrorMessage = "O Valor inserido não é email valido")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A Senha do usuario é obrigatorio")]
        [StringLength(maximumLength: 250, MinimumLength = 8, ErrorMessage = "Quantidade de caracteres invalidas")]
        public string Senha { get; set; }
    }
}
