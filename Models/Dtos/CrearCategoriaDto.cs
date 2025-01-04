using System.ComponentModel.DataAnnotations;

namespace ApiMovies.Models.Dtos
{
    public class CrearCategoriaDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "La cantida maxima de caracteres es 100")]
        [MinLength(3, ErrorMessage = "La cantida minima de caracteres es 3")]
        public string Nombre { get; set; }
    }
}
