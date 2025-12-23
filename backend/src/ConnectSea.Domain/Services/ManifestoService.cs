using ConnectSea.Domain.Dtos;
using ConnectSea.Domain.Repositories;
using ConnectSea.Domain.Services.Interfaces;

namespace ConnectSea.Domain.Services;

public class ManifestoService(
    IManifestoRepository repository,
    IEscalaRepository escalaRepository) : IManifestoService
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

    public async Task<Result> VincularEscalaAsync(int manifestoId, int escalaId)
    {
        var escala = await escalaRepository.GetEscalaByIdAsync(escalaId);
        if(escala is null)
        {
            return new Result(false, "Escala não encontrada.");
        }

        if(escala.Status == Enums.StatusEscala.Cancelada)
        {
            return new Result(false, "Não é possível vincular uma escala cancelada.");
        }

        var manifesto = await repository.GetByIdAsync(manifestoId);
        if(manifesto == null)
        {
            return new Result(false, "Manifesto não encontrado.");
        }

        if(manifesto.VerificarEscalaVinculada(escalaId))
        {
            return new Result(false, "Escala já vinculada ao manifesto.", true);
        }

        manifesto.AdicionarEscala(escalaId);
        await repository.UpdateAsync(manifesto);
        return new Result();
    }
}
