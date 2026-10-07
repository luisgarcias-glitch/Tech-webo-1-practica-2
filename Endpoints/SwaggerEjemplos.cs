using CatalogoGalactico.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CatalogoGalactico.Endpoints;

public class SwaggerEjemplos : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(PersonajeRequest))
            schema.Example = new OpenApiObject
            {
                ["nombre"] = new OpenApiString("Ahsoka Tano"),
                ["especie"] = new OpenApiString("Togruta"),
                ["faccion"] = new OpenApiString("Rebelde"),
                ["afiliacion"] = new OpenApiString("Rebeldes de Phoenix"),
                ["estado"] = new OpenApiString("Vivo"),
                ["fuerzaSensitivo"] = new OpenApiBoolean(true)
            };
        else if (context.Type == typeof(CardRequest))
            schema.Example = new OpenApiObject
            {
                ["personajeId"] = new OpenApiInteger(12),
                ["poder"] = new OpenApiInteger(82),
                ["habilidadEspecial"] = new OpenApiString("Combate con dos sables"),
                ["arma"] = new OpenApiString("Sables de luz blancos"),
                ["nivelPeligrosidad"] = new OpenApiInteger(7),
                ["imagenUrl"] = new OpenApiString("https://example.com/cartas/ahsoka.png")
            };
        else if (context.Type == typeof(EventoRequest))
            schema.Example = new OpenApiObject
            {
                ["nombre"] = new OpenApiString("Batalla de Jakku"),
                ["fecha"] = new OpenApiString("5 ABY"),
                ["ubicacion"] = new OpenApiString("Jakku"),
                ["descripcion"] = new OpenApiString("Enfrentamiento final entre la Nueva República y los remanentes imperiales."),
                ["participantes"] = new OpenApiArray { new OpenApiInteger(2), new OpenApiInteger(3), new OpenApiInteger(9) },
                ["personajesMuertos"] = new OpenApiArray()
            };
    }
}
