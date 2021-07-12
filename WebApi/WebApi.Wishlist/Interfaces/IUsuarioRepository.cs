using WebApi.WishList.Domains;

namespace WebApi.WishList.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(UsuarioViewModel usuario);
        Usuario Login(string email,string senha);
        Usuario ListarDesejos(int usuarioId);
    }
}
