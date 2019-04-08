using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.WebApi.Wishlist.Domains
{
    public partial class Desejo
    {

        public int Desejoid { get; set; }

        [Required(ErrorMessage = "O Desejo precisa ter um nome", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 100, ErrorMessage = "Limite de caracteres atingido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Desejo precisa ter uma descrição", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 500, ErrorMessage = "Limite de caracteres atingido")]
        public string Descricao { get; set; }

        public DateTime Datacricao { get; set; }

        [Required(ErrorMessage ="Não existe usuario para ser linkado a esse desejo",AllowEmptyStrings =false)]
        public int Usuarioid { get; set; }

        public Usuario Usuario { get; set; }
    }
}
