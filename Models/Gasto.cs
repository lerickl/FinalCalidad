using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCalidad.Models
{
    public class Gasto
    {
        public int GastoId { get; set; }
        public int Cuenta { get; set; }
        public Cuenta CuentaId { get; set; }
        public DateTime FechaGasto { get; set; }
        public string Descripcion { get; set; }
        public string Monto { get; set; }
    }
}