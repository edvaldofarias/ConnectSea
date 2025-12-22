using System.Diagnostics;
using ConnectSea.Domain.Repositories;
using ConnectSea.Domain.Services;
using ConnectSea.Domain.Services.Interfaces;
using ConnectSea.Infrastructure.Data.Context;
using ConnectSea.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEscalaService, EscalaService>();
builder.Services.AddScoped<IManifestoService, ManifestoService>();

builder.Services.AddScoped<IEscalaRepository, EscalaRepository>();
builder.Services.AddScoped<IManifestoRepository, ManifestoRepository>();

builder.Services.AddDbContext<ConnectSeaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<ConnectSeaContext>();
    await WaitForDatabaseAsync(db, TimeSpan.FromSeconds(30));
    await db.Database.MigrateAsync();

    if (!await db.Manifestos.AnyAsync())
    {
        var sqlFile = Path.Combine(AppContext.BaseDirectory, "Seeds", "Initial.sql");
        if (File.Exists(sqlFile))
        {
            var sql = await File.ReadAllTextAsync(sqlFile);
            await db.Database.ExecuteSqlRawAsync(sql);
        }
    }
        

}

await app.RunAsync();


static async Task WaitForDatabaseAsync(DbContext db, TimeSpan timeout)
{
    var sw = Stopwatch.StartNew();
    while (true)
    {
        try
        {
            await db.Database.CanConnectAsync();
            return;
        }
        catch
        {
            if (sw.Elapsed > timeout) throw;
            await Task.Delay(1000);
        }
    }
}
