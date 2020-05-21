using System.Collections.Generic;
using Senai.WebApi.Wishlist.Domains;

namespace Senai.WebApi.Wishlist.Interfaces {
    /// <summary>
    /// Interface com metodos de cadastro e listagem de desejos
    /// </summary>
    public interface IDesejoRepository {
        /// <summary>
        /// Cadastra um desejo no banco de dados
        /// </summary>
        /// <param name="desejo">Desejo a ser cadastrado</param>
        void Cadastrar(DesejoViewModel desejo);

        /// <summary>
        /// Lista todos os desejos do banco de dados
        /// </summary>
        /// <returns>Retorna todos os desejos cadastrados no banco de dados</returns>
        List<Desejo> Listar();
    }
}
