using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCalidad.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string SaldoInicial { get; set; }
        public List<Gasto> Gastos { get; set; }
        public List<Ingreso> Ingresos { get; set; }

    }
}