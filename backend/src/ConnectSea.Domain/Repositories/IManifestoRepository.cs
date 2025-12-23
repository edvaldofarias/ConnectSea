using ConnectSea.Domain.Entities;

namespace ConnectSea.Domain.Repositories;

public interface IManifestoRepository
{
    Task<IEnumerable<Manifesto>> GetManifestosAsync();

    Task<Manifesto?> GetByIdAsync(int id);

    Task UpdateAsync(Manifesto manifesto);
}
