using aplicaciones_vehiculos.entidades;
using Presentacion_ECC_Lib.entidades;

namespace aplicaciones_vehiculos.interfaces
{
    public interface IVehiculosAplicacion
    {
        Asignaciones Insertar(Asignaciones entidad);
        Asignaciones Actualizar(Asignaciones entidad);
        List<Asignaciones> Consultar();
        List<Asignaciones> Buscar(Asignaciones entidad);
        Asignaciones Borrar(Asignaciones entidad);
    }
}