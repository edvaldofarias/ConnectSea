using ConnectSea.Domain.Entities;
using ConnectSea.Domain.Repositories;
using ConnectSea.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ConnectSea.Infrastructure.Data.Repositories;

public class EscalaRepository(ConnectSeaContext context) : IEscalaRepository
{
    public async Task<IEnumerable<Escala>> GetEscalasAsync()
    {
        return await context.Escala
            .AsNoTracking()
            .ToListAsync();
    }
}