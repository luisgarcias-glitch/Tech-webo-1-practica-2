using System.Text.Json.Serialization;

namespace CatalogoGalactico.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Faccion { Rebelde, Imperio, Neutral }

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EstadoPersonaje { Vivo, Muerto, Desconocido }

public record Personaje(
    int Id,
    string Nombre,
    string Especie,
    Faccion Faccion,
    string Afiliacion,
    EstadoPersonaje Estado,
    bool FuerzaSensitivo,
    string Image);

public record CardPersonaje(
    int Id,
    int PersonajeId,
    int Poder,
    string HabilidadEspecial,
    string Arma,
    int NivelPeligrosidad,
    string? ImagenUrl);


public record Evento(
    int Id,
    string Nombre,
    int Fecha,
    string Ubicacion,
    string Descripcion,
    IReadOnlyList<int> Participantes,
    IReadOnlyList<int> PersonajesMuertos,
    string? Resultado,
    string? Ganador);
