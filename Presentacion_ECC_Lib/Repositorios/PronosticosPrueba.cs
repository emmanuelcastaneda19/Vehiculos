using aplicaciones_horarios.entidades;
using aplicaciones_horarios.implementaciones;
using aplicaciones_horarios.interfaces;
using Microsoft.EntityFrameworkCore;
using pruebas_horarios.Nucleo;

namespace pruebas_horarios.Repositorios
{
    [TestClass]
    public class AsignacionesPrueba
    {
        private readonly IConexion? iConexion;
        private List<Asignaciones>? lista;
        private Asignaciones? entidad;

        public AsignacionesPrueba()
        {
            iConexion = new Conexion();
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.IsTrue(Guardar());
            Assert.IsTrue(Modificar());
            Assert.IsTrue(Listar());
            Assert.IsTrue(Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Asignaciones!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Asignaciones()!;

            this.iConexion!.Asignaciones!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Lugar = "Test";

            var entry = this.iConexion!.Entry<Asignaciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Asignaciones!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}