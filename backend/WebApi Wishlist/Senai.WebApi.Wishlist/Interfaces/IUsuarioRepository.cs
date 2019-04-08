using Senai.WebApi.Wishlist.Domains;

namespace Senai.WebApi.Wishlist.Interfaces {
    /// <summary>
    /// Interface com metodos de cadastro e login de usuario
    /// </summary>
    public interface IUsuarioRepository {
        /// <summary>
        /// Cadastra um usuario no banco de dados
        /// </summary>
        /// <param name="usuario">Usuario a ser cadastrado</param>
        void Cadastrar(Usuario usuario);
        /// <summary>
        /// Procura um usuario que tenha a combinação de email e senha inseridos
        /// </summary>
        /// <param name="email">Email do usuario a ser procurado</param>
        /// <param name="senha">Senha do usuario a ser procurada</param>
        /// <returns>Retorna um usuario se a combinação existir</returns>
        Usuario Login(string email,string senha);

        /// <summary>
        /// Retorna um usuario e todos os desejos feitos por ele
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Usuario ListarDesejos(int ID);
    }
}
