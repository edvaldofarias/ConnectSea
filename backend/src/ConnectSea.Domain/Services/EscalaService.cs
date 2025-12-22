using ConnectSea.Domain.Entities;
using ConnectSea.Domain.Repositories;
using ConnectSea.Domain.Services.Interfaces;

namespace ConnectSea.Domain.Services;

public class EscalaService(IEscalaRepository repository) : IEscalaService
{
    //TODO: Implementar lógica para utilizar DTO de retorno
    public async Task<IEnumerable<Escala>> GetEscalasAsync()
    {
        var escalas = await repository.GetEscalasAsync();
        return escalas;
    }
}
