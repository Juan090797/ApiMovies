﻿namespace ApiMovies.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
        public string RutaImagen { get; set; }
        public enum TipoClasificacion { Siete, Trece, Dieciseis, Dieciocho }
        public string Clasificacion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public int categoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}
