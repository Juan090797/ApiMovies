using ApiMovies.Models;

namespace ApiMovies.Repositorys.IRepository
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<Categoria> GetCategoria(int id);
        bool ExisteCategoria(int id);
        Task<Categoria> CreateCategoria(Categoria categoria);
        Task<Categoria> UpdateCategoria(Categoria categoria);
        bool DeleteCategoria(int id);
    }
}
