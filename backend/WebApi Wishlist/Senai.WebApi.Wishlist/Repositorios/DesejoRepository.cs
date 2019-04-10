using System;
using System.Linq;
using System.Collections.Generic;
using Senai.WebApi.Wishlist.Domains;
using Senai.WebApi.Wishlist.Interfaces;

namespace Senai.WebApi.Wishlist.Repositorios {
    public class DesejoRepository : IDesejoRepository {

        public void Cadastrar(Desejo desejo) {
            desejo.Datacriacao = DateTime.Now;
            using (WishlistContext ctx = new WishlistContext()) {
                ctx.Add(desejo);
                ctx.SaveChanges();
            }
        }

        public List<Desejo> Listar() {
            using(WishlistContext ctx = new WishlistContext()) {
                if(ctx.Desejo.Count() > 0) {
                    return ctx.Desejo.ToList();
                }
            }
            throw new Exception("Não existe nenhum desejo cadastrado no banco de dados");
        }
    }
}
