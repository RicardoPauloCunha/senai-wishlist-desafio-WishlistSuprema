using System.Collections.Generic;

namespace WebApi.WishList.Domains
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Desejo> Desejos { get; set; }

        public Usuario()
        {
            Desejos = new HashSet<Desejo>();
        }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
