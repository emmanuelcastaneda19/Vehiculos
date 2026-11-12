using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion_ECC.entidades
{
    internal class Vehiculos
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public decimal Precio { get; set; }
        public string? Propietario { get; set; }
        public int VehiculosPersona { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal DescuentoPorcentaje { get; set; }
        public decimal PrecioFinal { get; set; }
    }
}
