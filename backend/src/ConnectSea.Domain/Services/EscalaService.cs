using ConnectSea.Domain.Dtos;
using ConnectSea.Domain.Repositories;
using ConnectSea.Domain.Services.Interfaces;

namespace ConnectSea.Domain.Services;

public class EscalaService(IEscalaRepository repository) : IEscalaService
{
    public async Task<IEnumerable<EscalaDto>> GetEscalasAsync()
    {
        var escalas = await repository.GetEscalasAsync();
        var escalasDtos = escalas.Select(e => new EscalaDto(
            e.Id,
            e.Navio,
            e.Porto,
            e.Status,
            e.Eta,
            e.Etb,
            e.Etd
        ));
        return escalasDtos;
    }
}
