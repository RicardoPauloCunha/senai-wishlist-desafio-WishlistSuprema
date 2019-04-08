using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Senai.WebApi.Wishlist.Domains;
using Senai.WebApi.Wishlist.Interfaces;

namespace Senai.WebApi.Wishlist.Repositorios {
    public class DesejoRepository : IDesejoRepository {

        public void Cadastrar(Desejo desejo) {
            desejo.Datacricao = DateTime.Now;
            using (WishlistContext ctx = new WishlistContext()) {
                ctx.Add(desejo);
                ctx.SaveChanges();
            }
        }

        public List<Desejo> Listar() {
            using(WishlistContext ctx = new WishlistContext()) {
                if(ctx.Desejo.Count() > 0) {
                    return ctx.Desejo.Include(x=> x.Usuario).ToList();
                }
            }
            throw new Exception("Não existe nenhum desejo cadastrado no banco de dados");
        }
    }
}
