using ConnectSea.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectSea.WebApi.Controllers
{
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
    }
}
