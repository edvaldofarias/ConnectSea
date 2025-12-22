using ConnectSea.Domain.Entities;

namespace ConnectSea.Domain.Repositories;

public interface IManifestoRepository
{
    Task<IEnumerable<Manifesto>> GetManifestosAsync();
}
