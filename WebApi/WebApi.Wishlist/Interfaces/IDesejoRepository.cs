using System.Collections.Generic;
using WebApi.WishList.Domains;

namespace WebApi.WishList.Interfaces
{
    public interface IDesejoRepository
    {
        void Cadastrar(DesejoViewModel desejo);
        List<Desejo> Listar();
    }
}
