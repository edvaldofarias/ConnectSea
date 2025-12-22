using ConnectSea.Domain.Entities;

namespace ConnectSea.Domain.Services.Interfaces;

public interface IEscalaService
{
    Task<IEnumerable<Escala>> GetEscalasAsync();
}
