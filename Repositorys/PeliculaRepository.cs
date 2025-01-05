using ApiMovies.Data;
using ApiMovies.Models;
using ApiMovies.Repositorys.IRepository;

namespace ApiMovies.Repositorys
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly AppDbContext _context;

        public PeliculaRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool ExistePelicula(int id)
        {
            var existePelicula = _context.Pelicula.Any(p => p.Id == id);
            if (existePelicula)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<Pelicula> GetPelicula(int id)
        {
            var pelicula = _context.Pelicula.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(pelicula);

        }

        public Task<IEnumerable<Pelicula>> GetPeliculas()
        {
            var peliculas = _context.Pelicula.ToList();
            return Task.FromResult(peliculas.AsEnumerable());
        }

        public Task<Pelicula> CreatePelicula(Pelicula pelicula)
        {
            _context.Pelicula.Add(pelicula);
            _context.SaveChanges();
            return Task.FromResult(pelicula);
        }

        public Task<Pelicula> UpdatePelicula(Pelicula pelicula)
        {
            _context.Pelicula.Update(pelicula);
            _context.SaveChanges();
            return Task.FromResult(pelicula);
        }

        public bool DeletePelicula(int id)
        {
            var pelicula = ExistePelicula(id);
            if (!pelicula)
            {
                return false;
            }
            var peliculaEncontrada = _context.Pelicula.Find(id);
            _context.Pelicula.Remove(peliculaEncontrada);
            _context.SaveChanges();
            return true;
        }

        public Task<IEnumerable<Pelicula>> GetPeliculasEnCategoria(int catId)
        {
            var peliculas = _context.Pelicula.Where(p => p.categoriaId == catId).ToList();
            return Task.FromResult(peliculas.AsEnumerable());
        }
    }
}
