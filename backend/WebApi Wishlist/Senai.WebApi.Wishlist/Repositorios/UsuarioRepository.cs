using Microsoft.EntityFrameworkCore;
using Senai.WebApi.Wishlist.Domains;
using Senai.WebApi.Wishlist.Interfaces;
using System;
using System.Linq;

namespace Senai.WebApi.Wishlist.Repositorios {
    public class UsuarioRepository : IUsuarioRepository {

        public void Cadastrar(Usuario usuario) {
            using (WishlistContext ctx = new WishlistContext()) {
                ctx.Add(usuario);
                ctx.SaveChanges();
            }
         }

        public Usuario ListarDesejos(int ID) {
            using (WishlistContext ctx = new WishlistContext()) {
                if(ctx.Usuario.Find(ID) != null) {
                    return ctx.Usuario.Include(i => i.Desejo).First(i => i.Usuarioid == ID);
                }
            }
            throw new NullReferenceException("Erro ao encontrar usuario");
        }

        public Usuario Login(string email, string senha) {
            using (WishlistContext ctx = new WishlistContext()) {
                Usuario usuario = ctx.Usuario.First(i => i.Email == email && i.Senha == senha);
                if(usuario != null) {
                    return usuario;
                }
            }
            throw new NullReferenceException("Email ou senha invalidos");
        }
    }
}
