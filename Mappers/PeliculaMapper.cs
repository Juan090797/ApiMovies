using ApiMovies.Models;
using ApiMovies.Models.Dtos;
using AutoMapper;

namespace ApiMovies.Mappers
{
    public class PeliculaMapper : Profile
    {
        public PeliculaMapper()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Categoria, CrearCategoriaDto>().ReverseMap();
            CreateMap<Pelicula, PeliculaDto>().ReverseMap();
            CreateMap<Pelicula, CrearPeliculaDto>().ReverseMap();
        }
    }
}
