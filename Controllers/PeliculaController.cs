using ApiMovies.Models.Dtos;
using ApiMovies.Models.Response;
using ApiMovies.Models;
using ApiMovies.Repositorys.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers
{
    [Route("api/v1/peliculas")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaRepository _peliculaRepository;
        private readonly IMapper _mapper;
        public PeliculaController(IPeliculaRepository peliculaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _peliculaRepository = peliculaRepository;
        }

        // Get api/v1/peliculas
        [HttpGet]
        public async Task<IActionResult> GetPeliculas()
        {
            var peliculas = await _peliculaRepository.GetPeliculas();
            var peliculasDto = new List<PeliculaDto>();
            foreach (var pelicula in peliculas)
            {
                peliculasDto.Add(_mapper.Map<PeliculaDto>(pelicula));
            }

            var response = new DataResponse<List<PeliculaDto>>();
            response.Success = true;
            response.Message = "Peliculas obtenidas con exito";
            response.Data = peliculasDto;

            return Ok(response);
        }

        // Get api/v1/peliculas/{id}
        [HttpGet("{id:int}", Name = "GetPelicula")]
        public async Task<IActionResult> GetPelicula(int id)
        {
            var pelicula = await _peliculaRepository.GetPelicula(id);

            if (pelicula == null)
            {
                var responseError = new DataResponse<string>
                {
                    Success = false,
                    Message = "Pelicula no encontrada",
                };
                return NotFound(responseError);
            }
            var peliculaDto = _mapper.Map<PeliculaDto>(pelicula);
            var response = new DataResponse<PeliculaDto>();
            response.Success = true;
            response.Message = "Pelicula obtenida con exito";
            response.Data = peliculaDto;

            return Ok(response);
        }
        /*
        // Post api/v1/peliculas
        [HttpPost]
        public async Task<IActionResult> CreatePelicula([FromBody] CrearPeliculaDto crearPeliculaDto)
        {
            if (crearPeliculaDto == null)
            {
                var responseError = new DataResponse<string>
                {
                    Success = false,
                    Message = "Pelicula vacia",
                };

                return BadRequest(responseError);
            }

            var pelicula = _mapper.Map<Pelicula>(crearPeliculaDto);
            var peliculaCreada = await _peliculaRepository.CreatePelicula(pelicula);
            var response = new DataResponse<PeliculaDto>
            {
                Success = true,
                Message = "Pelicula creada con exito",
                Data = _mapper.Map<PeliculaDto>(peliculaCreada)
            };
            return Ok(response);
        }

        // Put api/v1/peliculas/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePelicula(int id, [FromBody] PeliculaDto peliculaDto)
        {
            if (peliculaDto == null || id != peliculaDto.Id)
            {
                var responseError = new DataResponse<string>
                {
                    Success = false,
                    Message = "Pelicula vacia",
                };
                return BadRequest(responseError);
            }
            var pelicula = _mapper.Map<Pelicula>(peliculaDto);
            var peliculaActualizada = await _peliculaRepository.UpdatePelicula(pelicula);
            var response = new DataResponse<PeliculaDto>
            {
                Success = true,
                Message = "Pelicula actualizada con exito",
                Data = _mapper.Map<PeliculaDto>(peliculaActualizada)
            };
            return Ok(response);
        }

        // Delete api/v1/peliculas/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePelicula(int id)
        {
            if (!_peliculaRepository.ExistePelicula(id))
            {
                return NotFound(new DataResponse<String>
                {
                    Success = false,
                    Message = "Pelicula no encontrada",

                });
            }
            _peliculaRepository.DeletePelicula(id);
            return Ok(new DataResponse<string> { Success = true, Message = "Pelicula eliminada con exito" });
        }*/


    }
}

