using Aplicacion_ECC.entidades;
using aplicaciones_horarios.interfaces;
using aplicaciones_horarios.nucleo;
using aplicaciones_vehiculos.entidades;
using aplicaciones_vehiculos.interfaces;
using aplicaciones_vehiculos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_vehiculos.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatosGenerales.StringConexion());
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Vehiculos>? Vehiculos { get; set; }
    }
}