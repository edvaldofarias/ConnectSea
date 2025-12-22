using ConnectSea.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectSea.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EscalasController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromServices] IEscalaService service)
    {
        var escalas = await service.GetEscalasAsync();
        return Ok(escalas);
    }
}