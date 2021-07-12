using Microsoft.EntityFrameworkCore;
using WebApi.WishList.Domains;
using WebApi.WishList.Interfaces;
using System;
using System.Linq;

namespace WebApi.WishList.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Cadastrar(UsuarioViewModel usuario)
        {
            using (WishListContext ctx = new WishListContext())
            {
                bool emailExiste = ctx.Usuarios.Any(x => x.Email == usuario.Email);

                if (!emailExiste)
                {
                    Usuario usuarioDomain = new Usuario(usuario.Nome, usuario.Email, usuario.Senha);

                    ctx.Usuarios.Add(usuarioDomain);

                    ctx.SaveChanges();
                }
                else
                    throw new NullReferenceException("Email ja está em uso");
            }
        }

        public Usuario ListarDesejos(int usuarioId)
        {
            using (WishListContext ctx = new WishListContext())
            {
                Usuario usuario = ctx.Usuarios
                    .Include(x => x.Desejos)
                    .First(x => x.Id == usuarioId);

                if (usuario != null)
                    return usuario;
            }

            throw new NullReferenceException("Erro ao encontrar usuario");
        }

        public Usuario Login(string email, string senha)
        {
            using (WishListContext ctx = new WishListContext())
            {
                Usuario usuario = ctx.Usuarios
                    .ToList()
                    .FirstOrDefault(x => x.Email == email && x.Senha == senha);

                if (usuario != null)
                    return usuario;
            }

            throw new NullReferenceException("Email ou senha invalidos");
        }
    }
}
