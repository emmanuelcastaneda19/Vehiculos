namespace presentaciones_horarios.interfaces
{
    public interface IComunicaciones
    {
        Task<T> Ejecutar<T>(string url, object entidad);
    }
}