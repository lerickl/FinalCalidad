using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCalidad.Models
{
    public class Ingreso
    {
        public int IngresoId { get; set; }
        public int Cuenta { get; set; }
        public Cuenta CuentaId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Descripcion { get; set; }
        public string Monto { get; set; }

    }
}