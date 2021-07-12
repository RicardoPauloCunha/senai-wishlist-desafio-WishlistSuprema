using System;

namespace WebApi.WishList.Domains
{
    public partial class Desejo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public Desejo(string nome, string descricao, int usuarioId)
        {
            Nome = nome;
            Descricao = descricao;
            UsuarioId = usuarioId;
            DataCriacao = DateTime.Now;
        }
    }
}
