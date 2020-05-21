using Microsoft.EntityFrameworkCore;
using Senai.WebApi.Wishlist.Domains;
using Senai.WebApi.Wishlist.Interfaces;
using System;
using System.Linq;

namespace Senai.WebApi.Wishlist.Repositorios {
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Cadastrar(UsuarioViewModel usuario)
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                bool emailExiste = ctx.Usuario.Any(i => i.Email == usuario.Email);

                if (!emailExiste)
                {
                    Usuario usuarioDomain = new Usuario(usuario.Nome, usuario.Email, usuario.Senha);

                    ctx.Usuario.Add(usuarioDomain);

                    ctx.SaveChanges();
                }
                else
                {
                    throw new NullReferenceException("Email ja está em uso");
                }
            }
        }

        public Usuario ListarDesejos(int ID)
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                Usuario usuario = ctx.Usuario.Include(i => i.Desejo).First(i => i.Usuarioid == ID);

                if (usuario != null)
                {
                    return usuario;
                }
            }

            throw new NullReferenceException("Erro ao encontrar usuario");
        }

        public Usuario Login(string email, string senha)
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                Usuario usuario = ctx.Usuario.ToList().Find(i => i.Email == email && i.Senha == senha);

                if (usuario != null)
                {
                    return usuario;
                }
            }

            throw new NullReferenceException("Email ou senha invalidos");
        }
    }
}
