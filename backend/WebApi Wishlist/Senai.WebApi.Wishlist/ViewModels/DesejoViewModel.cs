using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.WebApi.Wishlist.Domains
{
    public class DesejoViewModel
    {
        [Required(ErrorMessage = "O Desejo precisa ter um nome", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 100, ErrorMessage = "Limite de caracteres atingido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Desejo precisa ter uma descrição", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 500, ErrorMessage = "Limite de caracteres atingido")]
        public string Descricao { get; set; }

        public int Usuarioid { get; set; }
    }
}
