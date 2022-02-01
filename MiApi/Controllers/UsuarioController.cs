using MiApi.Data.Repositories;
using MiApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUsuariosActivos()
        {
            return Ok(await _usuarioRepository.ObtenerUsuariosActivos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuarioDetalles(int id)
        {
            return Ok(await _usuarioRepository.ObtenerUsuarioDetalles(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertarUsuario([FromBody] Usuario usuario)
        {
            if(usuario == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _usuarioRepository.InsertarUsuario(usuario);
            return Created("created", created);

        }

        [HttpPut]
        public async Task<IActionResult> ActualizarUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _usuarioRepository.ActualizarUsuario(usuario);
            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DesactivarUsuario(int id)
        {
            return Ok(await _usuarioRepository.DesactivarUsuario(id));
        }
    }
}
