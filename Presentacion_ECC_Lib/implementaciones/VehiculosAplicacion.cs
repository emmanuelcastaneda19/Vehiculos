using Aplicacion_ECC.entidades;
using aplicaciones_horarios.interfaces;
using aplicaciones_vehiculos.entidades;
using aplicaciones_vehiculos.interfaces;
using Microsoft.EntityFrameworkCore;

namespace aplicaciones_vehiculos.implementaciones
{
    public class VehiculosAplicacion : IVehiculosAplicacion
    {
        private IConexion IConexion;

        public VehiculosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Vehiculos Actualizar(Vehiculos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado el vehiculo");
            Validar(entidad);
            entidad = AplicarDescuento(entidad);
            var entry = this.IConexion.Entry<Vehiculos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Vehiculos Borrar(Vehiculos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha seleccionado un vehiculo");
            this.IConexion.Vehiculos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Vehiculos> Buscar(Vehiculos entidad)
        {
            string nombre = entidad.NombrePropietario ?? "";
            string codigo = entidad.Codigo ?? "";
            return this.IConexion.Vehiculos!
                .Where(x => x.NombrePropietario!.Contains(nombre) && x.Codigo!.Contains(codigo))
                .OrderBy(x => x.Id).ToList();
        }

        public List<Vehiculos> Consultar()
        {
            return this.IConexion.Vehiculos!.OrderBy(x => x.Id).ToList();
        }

        public Vehiculos Insertar(Vehiculos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("El vehiculo ya se encuentra guardado");
            Validar(entidad);
            entidad = AplicarDescuento(entidad);
            this.IConexion.Vehiculos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Vehiculos CalcularDescuento(Vehiculos entidad)
        {
            Validar(entidad);
            return AplicarDescuento(entidad);
        }

        private Vehiculos AplicarDescuento(Vehiculos entidad)
        {
            decimal descuento = 0;

            if (entidad.VehiculosPersona > 2)
                descuento = 10.5m;

            DateTime fecha = entidad.FechaRegistro;
            DateTime inicioPeriodo = new DateTime(fecha.Year, 12, 2);
            DateTime finPeriodo = new DateTime(fecha.Year, 12, 31);
            if (fecha.Date >= inicioPeriodo && fecha.Date <= finPeriodo && descuento < 10m)
                descuento = 10m;

            if (entidad.ColeccionesSinVender > 1)
                descuento = 17m;

            entidad.DescuentoPorcentaje = descuento;
            entidad.PrecioFinal = Math.Round(entidad.Precio * (1 - descuento / 100m), 2);
            return entidad;
        }

        private void Validar(Vehiculos entidad)
        {
            if (string.IsNullOrWhiteSpace(entidad.Codigo) ||
                string.IsNullOrWhiteSpace(entidad.Marca) ||
                string.IsNullOrWhiteSpace(entidad.Modelo) ||
                string.IsNullOrWhiteSpace(entidad.NombrePropietario))
                throw new Exception("Falta informacion obligatoria");

            if (entidad.Anio < 1886 || entidad.Anio > DateTime.Now.Year + 1)
                throw new Exception("El año del vehiculo no es valido");
            if (entidad.Precio <= 0)
                throw new Exception("El precio debe ser mayor que cero");
            if (entidad.VehiculosPersona < 1 || entidad.ColeccionesSinVender < 0)
                throw new Exception("Revise la cantidad de vehiculos o colecciones");
            if (entidad.FechaRegistro == DateTime.MinValue)
                throw new Exception("La fecha de registro es obligatoria");
        }
    }
}