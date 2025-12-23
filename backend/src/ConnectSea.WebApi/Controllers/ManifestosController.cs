using ConnectSea.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectSea.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ManifestosController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromServices] IManifestoService service)
    {
        var manifestos = await service.GetManifestosAsync();
        return Ok(manifestos);
    }

    [HttpPost("{manifestoId}/vincular-escala/{escalaId}")]
    public async Task<IActionResult> VincularEscalaAsync(
        int manifestoId,
        int escalaId,
        [FromServices] IManifestoService service)
    {
        var result = await service.VincularEscalaAsync(manifestoId, escalaId);
        if (result.Sucesso is false)
        {
            return result.Duplicidade
                ? Conflict(result.Mensagem)
                : BadRequest(result.Mensagem);
        }

        return Ok();
    }
}