using ConnectSea.Domain.Entities;

namespace ConnectSea.Domain.Services.Interfaces;

public interface IManifestoService
{
    Task<IEnumerable<Manifesto>> GetManifestosAsync();
}
