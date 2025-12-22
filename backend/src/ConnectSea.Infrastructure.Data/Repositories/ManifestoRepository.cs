using ConnectSea.Domain.Entities;
using ConnectSea.Domain.Repositories;
using ConnectSea.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ConnectSea.Infrastructure.Data.Repositories;

public class ManifestoRepository(ConnectSeaContext context) : IManifestoRepository
{
    public async Task<IEnumerable<Manifesto>> GetManifestosAsync()
    {
        return await context.Manifestos
            .AsNoTracking()
            .ToListAsync();
    }
}