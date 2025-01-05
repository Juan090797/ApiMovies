using ApiMovies.Data;
using ApiMovies.Models;
using ApiMovies.Repositorys.IRepository;

namespace ApiMovies.Repositorys
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool ExisteCategoria(int id)
        {
            var existeCategoria = _context.Categoria.Any(p => p.Id == id);
            if (existeCategoria) {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<Categoria> GetCategoria(int id)
        {
            var categoria = _context.Categoria.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(categoria);

        }

        public Task<IEnumerable<Categoria>> GetCategorias()
        {
            var categorias = _context.Categoria.ToList();
            return Task.FromResult(categorias.AsEnumerable());
        }

        public Task<Categoria> CreateCategoria(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
            return Task.FromResult(categoria);
        }

        public Task<Categoria> UpdateCategoria(Categoria categoria)
        {
            _context.Categoria.Update(categoria);
            _context.SaveChanges();
            return Task.FromResult(categoria);
        }

        public bool DeleteCategoria(int id)
        {
            var categoria = ExisteCategoria(id);
            if (!categoria)
            {
                return false;
            }
            var categoriaEncontrada = _context.Categoria.Find(id);
            _context.Categoria.Remove(categoriaEncontrada);
            _context.SaveChanges();
            return true;
        }
    }
}
