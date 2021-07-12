using System;
using System.Linq;
using System.Collections.Generic;
using WebApi.WishList.Domains;
using WebApi.WishList.Interfaces;

namespace WebApi.WishList.Repositorios
{
    public class DesejoRepository : IDesejoRepository
    {
        public void Cadastrar(DesejoViewModel desejo)
        {
            Desejo desejoDomain = new Desejo(desejo.Nome, desejo.Descricao, desejo.Usuarioid); 

            using (WishListContext ctx = new WishListContext())
            {
                ctx.Add(desejoDomain);
                ctx.SaveChanges();
            }
        }

        public List<Desejo> Listar()
        {
            using (WishListContext ctx = new WishListContext())
            {
                if (ctx.Desejos.Count() > 0)
                {
                    return ctx.Desejos.ToList();
                }
            }

            throw new Exception("Não existe nenhum desejo cadastrado no banco de dados");
        }
    }
}
