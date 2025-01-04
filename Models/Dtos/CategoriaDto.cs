using System.ComponentModel.DataAnnotations;

namespace ApiMovies.Models.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

    }
}
