using ConnectSea.Domain.Entities;
using ConnectSea.Domain.Repositories;
using ConnectSea.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ConnectSea.Infrastructure.Data.Repositories;

public class ManifestoRepository(ConnectSeaContext context) : IManifestoRepository
{
    public Task<Manifesto?> GetByIdAsync(int id)
    {
        return context.Manifestos
            .Include(m => m.ManifestoEscalas)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Manifesto>> GetManifestosAsync()
    {
        return await context.Manifestos
            .AsNoTracking()
            .ToListAsync();
    }

    public Task UpdateAsync(Manifesto manifesto)
    {
        context.Update(manifesto);
        return context.SaveChangesAsync();
    }
}