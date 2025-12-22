using ConnectSea.Domain.Entities;

namespace ConnectSea.Domain.Repositories;

public interface IEscalaRepository
{
    Task<IEnumerable<Escala>> GetEscalasAsync();
}
