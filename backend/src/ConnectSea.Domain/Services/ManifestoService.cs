using ConnectSea.Domain.Dtos;
using ConnectSea.Domain.Repositories;
using ConnectSea.Domain.Services.Interfaces;

namespace ConnectSea.Domain.Services;

public class ManifestoService(IManifestoRepository repository) : IManifestoService
{
    public async Task<IEnumerable<ManifestoDto>> GetManifestosAsync()
    {
        var manifestos = await repository.GetManifestosAsync();
        var manifestoDtos = manifestos.Select(m => new ManifestoDto(
            m.Id,
            m.Numero,
            m.Tipo,
            m.Navio,
            m.PortoOrigem,
            m.PortoDestino
        ));
        
        return manifestoDtos;
    }
}
