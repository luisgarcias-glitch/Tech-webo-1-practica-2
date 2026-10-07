using CatalogoGalactico.Models;

namespace CatalogoGalactico.Data;

public class DataStore
{
    public object Sync { get; } = new();

    public List<Personaje> Personajes { get; } = new();
    public List<CardPersonaje> Cartas { get; } = new();
    public List<Evento> Eventos { get; } = new();

    private int _idPersonaje, _idCarta, _idEvento;

    public int NuevoIdPersonaje() => ++_idPersonaje;
    public int NuevoIdCarta() => ++_idCarta;
    public int NuevoIdEvento() => ++_idEvento;

    public DataStore() => Sembrar();

    private void Sembrar()
    {
        Personajes.AddRange(new[]
        {
            new Personaje(1, "Luke Skywalker", "Humano", Faccion.Rebelde, "Alianza Rebelde", EstadoPersonaje.Vivo, true,"https://static.wikia.nocookie.net/esstarwars/images/d/d9/Luke-rotjpromo.jpg/revision/latest?cb=20071214134433"),
            new Personaje(2, "Leia Organa", "Humana", Faccion.Rebelde, "Alianza Rebelde", EstadoPersonaje.Vivo, true, "https://static.wikia.nocookie.net/moviemorgue/images/5/51/Leia_organa.jpg/revision/latest?cb=20200505112641"),
            new Personaje(3, "Han Solo", "Humano", Faccion.Rebelde, "Alianza Rebelde", EstadoPersonaje.Vivo, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ80m9PtyEHTN0RK5W90KwANpn-DjD9chiZVJXtUKTpAA&s=10"),
            new Personaje(4, "Chewbacca", "Wookiee", Faccion.Rebelde, "Alianza Rebelde", EstadoPersonaje.Vivo, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTyHEyPYBO5CL2f1cfrhE3VTZnPFOw0Z-ljDpoR81uoJw&s=10"),
            new Personaje(5, "Obi-Wan Kenobi", "Humano", Faccion.Rebelde, "Orden Jedi", EstadoPersonaje.Muerto, true, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZVPe9bqEPNQhFL-3md_4W2epEX2zlY-_qtPhLvuU4JQ&s=10"),
            new Personaje(6, "Yoda", "Desconocida", Faccion.Neutral, "Orden Jedi", EstadoPersonaje.Muerto, true, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRsqepRIDZ-RP-CRbf9-c94TzewVAyLWvQjYJ_Hplm_JA&s=10"),
            new Personaje(7, "Darth Vader", "Humano", Faccion.Imperio, "Imperio Galáctico", EstadoPersonaje.Muerto, true,"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSbK9NmhvLzPiZ1WFGS8DfNTMK2nAipEMIZQ0DM2tZjbQ&s=10"),
            new Personaje(8, "Emperador Palpatine", "Humano", Faccion.Imperio, "Imperio Galáctico", EstadoPersonaje.Muerto, true, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbQF4isZpI-BZgJIqFauXK1WNLKzypOE8rmRIe-V7KJQ&s=10"),
            new Personaje(9, "Wilhuff Tarkin", "Humano", Faccion.Imperio, "Imperio Galáctico", EstadoPersonaje.Muerto, false,"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSf-1hJCWhSuyTZNqsFziyn5XIjcQrBdZi-6MIRgd8HYg&s=10"),
            new Personaje(10, "Boba Fett", "Humano", Faccion.Neutral, "Cazarrecompensas", EstadoPersonaje.Desconocido, false,"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZFCV6KxNYznwZbPaJz0MPVGDd-H_M80a3JHPzR8jIwQ&s=10"),
            new Personaje(11, "Lando Calrissian", "Humano", Faccion.Rebelde, "Alianza Rebelde", EstadoPersonaje.Vivo, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbD4La3fq4lH6gBTp6v_i4_bdiqMIt2SYqPbBSOrR_sw&s=10"),
        });
        _idPersonaje = 11;

        Cartas.AddRange(new[]
        {
            new CardPersonaje(1, 1, 88, "Empuje de la Fuerza", "Sable de luz verde", 8, "https://example.com/cartas/luke.png"),
            new CardPersonaje(2, 2, 55, "Liderazgo rebelde", "Bláster", 5, "https://example.com/cartas/leia.png"),
            new CardPersonaje(3, 3, 60, "Puntería veloz", "Bláster DL-44", 6, "https://example.com/cartas/han.png"),
            new CardPersonaje(4, 4, 72, "Fuerza wookiee", "Ballesta bowcaster", 7, "https://example.com/cartas/chewbacca.png"),
            new CardPersonaje(5, 5, 85, "Mente Jedi", "Sable de luz azul", 8, "https://example.com/cartas/obiwan.png"),
            new CardPersonaje(6, 6, 97, "Maestría de la Fuerza", "Sable de luz verde", 9, "https://example.com/cartas/yoda.png"),
            new CardPersonaje(7, 7, 95, "Estrangulamiento de la Fuerza", "Sable de luz rojo", 10, "https://example.com/cartas/vader.png"),
            new CardPersonaje(8, 8, 98, "Rayos de la Fuerza", "Rayos Sith", 10, "https://example.com/cartas/palpatine.png"),
            new CardPersonaje(9, 9, 45, "Estrategia imperial", "Superláser de la Estrella de la Muerte", 6, "https://example.com/cartas/tarkin.png"),
            new CardPersonaje(10, 10, 70, "Jetpack", "Bláster EE-3", 7, "https://example.com/cartas/boba.png"),
            new CardPersonaje(11, 11, 50, "Astucia de contrabandista", "Bláster", 4, "https://example.com/cartas/lando.png"),
        });
        _idCarta = 11;

        Eventos.AddRange(new[]
        {
            new Evento(1, "Duelo en Mustafar", -19, "Mustafar", "Duelo entre maestro y aprendiz junto a ríos de lava.",
                new[] { 5, 7 }, Array.Empty<int>(), null, null),
            new Evento(2, "Duelo en la Estrella de la Muerte", 0, "Estrella de la Muerte", "Obi-Wan se sacrifica para permitir el escape.",
                new[] { 5, 7 }, new[] { 5 }, null, null),
            new Evento(3, "Batalla de Yavin", 0, "Yavin 4", "Ataque rebelde que destruye la primera Estrella de la Muerte.",
                new[] { 1, 2, 3, 4, 7, 9 }, new[] { 9 }, null, null),
            new Evento(4, "Batalla de Hoth", 3, "Hoth", "El Imperio asalta la base Echo.",
                new[] { 1, 2, 3, 4, 7 }, Array.Empty<int>(), null, null),
            new Evento(5, "Muerte de Yoda", 4, "Dagobah", "Yoda se despide de Luke.",
                new[] { 1, 6 }, new[] { 6 }, null, null),
            new Evento(6, "Batalla de Endor", 4, "Endor", "Batalla final contra el Emperador y la segunda Estrella de la Muerte.",
                new[] { 1, 2, 3, 4, 7, 8, 11 }, new[] { 7, 8 }, null, null),
        });
        _idEvento = 6;
    }
}
