using ConnectSea.Domain.Entities;
using ConnectSea.Domain.Repositories;
using ConnectSea.Domain.Services.Interfaces;

namespace ConnectSea.Domain.Services;

public class ManifestoService(IManifestoRepository repository) : IManifestoService
{
    //TODO: Implementar DTO
    public async Task<IEnumerable<Manifesto>> GetManifestosAsync()
    {
        var manifestos = await repository.GetManifestosAsync();
        return manifestos;
    }
}
