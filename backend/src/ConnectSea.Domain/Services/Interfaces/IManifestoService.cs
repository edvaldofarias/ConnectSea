using ConnectSea.Domain.Dtos;

namespace ConnectSea.Domain.Services.Interfaces;

public interface IManifestoService
{
    Task<IEnumerable<ManifestoDto>> GetManifestosAsync();
}
