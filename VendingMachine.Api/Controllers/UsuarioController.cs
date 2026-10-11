using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Usuarios.CriarUsuario;

namespace VendingMachine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly CriarUsuarioHandler _criarUsuarioHandler;
        public UsuarioController(CriarUsuarioHandler criarUsuarioHandler)
        {
            _criarUsuarioHandler = criarUsuarioHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario( [FromBody] CriarUsuarioCommand command)
        {
            var usuario = await _criarUsuarioHandler.Handle(command);
            return Created($"/api/produto/{usuario.Id}", new {id = usuario.Id});
        }
    }
}
