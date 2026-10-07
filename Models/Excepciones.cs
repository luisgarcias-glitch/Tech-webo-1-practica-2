namespace CatalogoGalactico.Models;

public class NotFoundException(string mensaje) : Exception(mensaje);


public class ReglaNegocioException(string mensaje) : Exception(mensaje);
