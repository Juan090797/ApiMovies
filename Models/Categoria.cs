using System.ComponentModel.DataAnnotations;

namespace ApiMovies.Models
{
    public class Categoria
    {
        //campos id, nombre, fechaCreacion
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
