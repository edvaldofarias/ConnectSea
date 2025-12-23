using System.Diagnostics;
using ConnectSea.Domain.Repositories;
using ConnectSea.Domain.Services;
using ConnectSea.Domain.Services.Interfaces;
using ConnectSea.Infrastructure.Data.Context;
using ConnectSea.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition =
            System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
    options.Providers.Add<BrotliCompressionProvider>();
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Fastest;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEscalaService, EscalaService>();
builder.Services.AddScoped<IManifestoService, ManifestoService>();

builder.Services.AddScoped<IEscalaRepository, EscalaRepository>();
builder.Services.AddScoped<IManifestoRepository, ManifestoRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'ConnectSeaDatabase' not found.");

builder.Services.AddDbContext<ConnectSeaContext>(options => { options.UseSqlServer(connectionString); });

var app = builder.Build();

app.UseResponseCompression();

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
    await WaitForDatabaseAsync(db, TimeSpan.FromSeconds(60));
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