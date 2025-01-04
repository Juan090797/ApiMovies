using ApiMovies.Models;
using ApiMovies.Models.Dtos;
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
            return Ok(categoriasDto);
        }

        // Get api/v1/categorias/{id}
        [HttpGet("{id:int}", Name = "GetCategoria")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetCategoria(id);
            if (categoria == null)
            {
                return NotFound();
            }
            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return Ok(categoriaDto);
        }

        // Post api/v1/categorias
        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] CrearCategoriaDto crearCategoriaDto)
        {
            if (crearCategoriaDto == null)
            {
                return BadRequest(ModelState);
            }
            
            var categoria = _mapper.Map<Categoria>(crearCategoriaDto);
            var categoriaCreada = await _categoriaRepository.CreateCategoria(categoria);
            return CreatedAtRoute("GetCategoria", new { id = categoriaCreada.Id }, categoriaCreada);
        }

        // Put api/v1/categorias/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CategoriaDto categoriaDto)
        {
            if (categoriaDto == null || id != categoriaDto.Id)
            {
                return BadRequest(ModelState);
            }
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            var categoriaActualizada = await _categoriaRepository.UpdateCategoria(categoria);
            return Ok(categoriaActualizada);
        }

        // Delete api/v1/categorias/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            if (!_categoriaRepository.ExisteCategoria(id))
            {
                return NotFound();
            }
            var categoriaEliminada = _categoriaRepository.DeleteCategoria(id);
            return Ok();
        }

    }
}
