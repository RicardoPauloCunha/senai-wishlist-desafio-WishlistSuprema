using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.WebApi.Wishlist.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Desejo = new HashSet<Desejo>();
        }

        public int Usuarioid { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Desejo> Desejo { get; set; }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
