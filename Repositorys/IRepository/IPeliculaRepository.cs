using ApiMovies.Models;

namespace ApiMovies.Repositorys.IRepository
{
    public interface IPeliculaRepository
    {
        Task<IEnumerable<Pelicula>> GetPeliculas();
        Task<IEnumerable<Pelicula>> GetPeliculasEnCategoria(int catId);
        Task<Pelicula> GetPelicula(int id);
        bool ExistePelicula(int id);
        Task<Pelicula> CreatePelicula(Pelicula pelicula);
        Task<Pelicula> UpdatePelicula(Pelicula pelicula);
        bool DeletePelicula(int id);
    }
}
