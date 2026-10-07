using CatalogoGalactico.Models;
using CatalogoGalactico.Services;
using CatalogoGalactico.Data;


namespace CatalogoGalactico.Endpoints;

public static class PersonajeEndpoints
{
    public static IEndpointRouteBuilder MapPersonajeEndpoints(this IEndpointRouteBuilder app)
    {
        var g = app.MapGroup("/personajes").WithTags("Personajes");

        g.MapGet("/", (PersonajeService s, string? faccion, string? estado, string? especie,
                string? afiliacion, bool? fuerzaSensitivo, string? nombre) =>
                Results.Ok(s.Listar(faccion, estado, especie, afiliacion, fuerzaSensitivo, nombre)))
            .WithSummary("Lista personajes con filtros opcionales combinables")
            .WithDescription("Filtros: faccion (Rebelde|Imperio|Neutral), estado (Vivo|Muerto|Desconocido), " +
                             "especie, afiliacion, nombre (contiene) y fuerzaSensitivo (true|false). " +
                             "Ejemplo: /personajes?faccion=Imperio&fuerzaSensitivo=true")
            .Produces<List<Personaje>>()
            .ProducesProblem(StatusCodes.Status400BadRequest);

        g.MapGet("/ranking", (EstadisticasService s, string? por, string? orden) =>
                Results.Ok(s.Ranking(por,orden)))
            .WithSummary("Ranking de personajes según su carta")
            .WithDescription("por=poder (por defecto) o peligrosidad; orden=desc (por defecto) o asc. " +
                             "Solo incluye personajes que tienen carta.")
            .Produces<List<RankingItem>>()
            .ProducesProblem(StatusCodes.Status400BadRequest);

        g.MapGet("/{id:int}", (int id, PersonajeService s) => Results.Ok(s.Obtener(id)))
            .WithSummary("Obtiene un personaje por id")
            .Produces<Personaje>()
            .ProducesProblem(StatusCodes.Status404NotFound);
        g.MapGet("/{id:int}/con-card", (int id, DataStore store) =>
        {
            var p = store.Personajes.FirstOrDefault(x => x.Id == id);
            if (p is null) return Results.NotFound(new { error = $"No existe el personaje {id}" });

            var c = store.Cartas.FirstOrDefault(x => x.PersonajeId == id);
            if (c is null) return Results.NotFound(new { error = "El personaje no tiene carta" });

            return Results.Ok(new
            {
                p.Id, p.Nombre, p.Especie, p.Faccion, p.Afiliacion, p.Estado, p.FuerzaSensitivo, p.Image,
                c.Poder, c.HabilidadEspecial, c.Arma, c.NivelPeligrosidad,
                card = c
            });
        })
        .WithSummary("Ficha de combate: personaje + su carta");

        g.MapGet("/{id:int}/eventos", (int id, EventoService s) => Results.Ok(s.ListarPorPersonaje(id)))
            .WithSummary("Eventos en los que participa un personaje (orden cronológico)")
            .Produces<List<EventoResponse>>()
            .ProducesProblem(StatusCodes.Status404NotFound);

        g.MapPost("/", (PersonajeRequest r, PersonajeService s) =>
            {
                var creado = s.Crear(r);
                return Results.Created($"/personajes/{creado.Id}", creado);
            })
            .WithSummary("Crea un personaje")
            .Produces<Personaje>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);

        g.MapPut("/{id:int}", (int id, PersonajeRequest r, PersonajeService s) => Results.Ok(s.Actualizar(id, r)))
            .WithSummary("Actualiza un personaje")
            .Produces<Personaje>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound);

        g.MapDelete("/{id:int}", (int id, PersonajeService s) =>
            {
                s.Eliminar(id);
                return Results.NoContent();
            })
            .WithSummary("Elimina un personaje (y su carta) si no participa en eventos")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound);

        return app;
    }
}
