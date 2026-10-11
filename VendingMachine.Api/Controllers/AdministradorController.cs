using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Administradores.CriarAdministrador;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly CriarAdministradorHandler _handler;

        public AdministradorController(
            CriarAdministradorHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<ActionResult<Administrador>> CriarAdministrador(
            [FromBody] CriarAdministradorCommand command)
        {
            var administrador = await _handler.Handle(command);

            return CreatedAtAction(
                nameof(CriarAdministrador),
                new { id = administrador.Id },
                administrador);
        }
    }
}