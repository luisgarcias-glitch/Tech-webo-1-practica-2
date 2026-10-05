using CatalogoGalactico.Data;
using CatalogoGalactico.Endpoints;
using CatalogoGalactico.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ---- Servicios (datos en memoria compartidos como singleton) ----
builder.Services.AddSingleton<DataStore>();
builder.Services.AddSingleton<PersonajeService>();
builder.Services.AddSingleton<CartaService>();
builder.Services.AddSingleton<EventoService>();
builder.Services.AddSingleton<SimulacionService>();
builder.Services.AddSingleton<EstadisticasService>();

// ---- Swagger / OpenAPI ----
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Catálogo galáctico de personajes y eventos",
        Version = "v1",
        Description = "API REST (Minimal API) para administrar personajes, cartas coleccionables y eventos, " +
                      "con relaciones N:N, reglas de consistencia temporal, ranking, MVP y simulación de batallas. " +
                      "Datos en memoria: se reinician al reiniciar la aplicación.\n\n" +
                      "Convención de fechas: 10 BBY = -10, Batalla de Yavin = 0, 3 ABY = 3."
    });
    o.SchemaFilter<SwaggerEjemplos>();
});

var app = builder.Build();

app.UseMiddleware<ManejadorErrores>();

app.UseSwagger();
app.UseSwaggerUI(o =>
{
    o.SwaggerEndpoint("/swagger/v1/swagger.json", "Catálogo galáctico v1");
    o.DocumentTitle = "Catálogo galáctico - Swagger";
});

app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.MapPersonajeEndpoints();
app.MapCartaEndpoints();
app.MapEventoEndpoints();

app.Run();
