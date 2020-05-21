using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.WebApi.Wishlist.Domains
{
    public partial class Desejo
    {
        public int Desejoid { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Datacricao { get; set; }
        public int Usuarioid { get; set; }

        public Usuario Usuario { get; set; }

        public Desejo(string nome, string descricao, int usuarioid)
        {
            Nome = nome;
            Descricao = descricao;
            Datacricao = DateTime.Now;
            Usuarioid = usuarioid;
        }
    }
}
