using ConnectSea.Domain.Dtos;

namespace ConnectSea.Domain.Services.Interfaces;

public interface IEscalaService
{
    Task<IEnumerable<EscalaDto>> GetEscalasAsync();
}
