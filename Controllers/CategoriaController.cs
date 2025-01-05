using ApiMovies.Models;
using ApiMovies.Models.Dtos;
using ApiMovies.Models.Response;
using ApiMovies.Repositorys.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers
{
    [Route("api/v1/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriaController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
        }

        // Get api/v1/categorias
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _categoriaRepository.GetCategorias();
            var categoriasDto = new List<CategoriaDto>();
            foreach (var categoria in categorias)
            {
                categoriasDto.Add(_mapper.Map<CategoriaDto>(categoria));
            }

            var response = new DataResponse<List<CategoriaDto>>();
            response.Success = true;
            response.Message = "Categorias obtenidas con exito";
            response.Data = categoriasDto;

            return Ok(response);
        }

        // Get api/v1/categorias/{id}
        [HttpGet("{id:int}", Name = "GetCategoria")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetCategoria(id);
            
            if (categoria == null)
            {
                var responseError = new DataResponse<string>
                {
                    Success = false,
                    Message = "Categoria no encontrada",
                };
                return NotFound(responseError);
            }
            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            var response = new DataResponse<CategoriaDto>();
            response.Success = true;
            response.Message = "Categoria obtenida con exito";
            response.Data = categoriaDto;

            return Ok(response);
        }

        // Post api/v1/categorias
        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] CrearCategoriaDto crearCategoriaDto)
        {
            if (crearCategoriaDto == null)
            {
                var responseError = new DataResponse<string>
                {
                    Success = false,
                    Message = "Categoria vacia",
                };

                return BadRequest(responseError);
            }
            
            var categoria = _mapper.Map<Categoria>(crearCategoriaDto);
            var categoriaCreada = await _categoriaRepository.CreateCategoria(categoria);
            var response = new DataResponse<CategoriaDto>
            {
                Success = true,
                Message = "Categoria creada con exito",
                Data = _mapper.Map<CategoriaDto>(categoriaCreada)
            };
            return Ok(response);
        }

        // Put api/v1/categorias/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CategoriaDto categoriaDto)
        {
            if (categoriaDto == null || id != categoriaDto.Id)
            {
                var responseError = new DataResponse<string>
                {
                    Success = false,
                    Message = "Categoria vacia",
                };
                return BadRequest(responseError);
            }
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            var categoriaActualizada = await _categoriaRepository.UpdateCategoria(categoria);
            var response = new DataResponse<CategoriaDto>
            {
                Success = true,
                Message = "Categoria actualizada con exito",
                Data = _mapper.Map<CategoriaDto>(categoriaActualizada)
            };
            return Ok(response);
        }

        // Delete api/v1/categorias/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            if (!_categoriaRepository.ExisteCategoria(id))
            {
                return NotFound(new DataResponse<String>
                {
                    Success = false,
                    Message = "Categoria no encontrada",
                    
                });
            }
            var categoriaEliminada = _categoriaRepository.DeleteCategoria(id);
            return Ok(new DataResponse<string> { Success= true, Message = "Categoria eliminada con exito"});
        }


    }
}
