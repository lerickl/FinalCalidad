using FinalCalidad.Db;
using FinalCalidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalCalidad.servicios
{
 
    public class BancoServices : IBancoServices
    {
        private readonly FinalCalidadContext _db;
        public BancoServices(FinalCalidadContext db)
        {
            this._db = db;
        }


        public void addCuenta(Cuenta cuenta)
        {
            _db.Cuentas.Add(cuenta);
            _db.SaveChanges();
        }

        public void addGasto(Gasto gasto)
        {
            gasto.FechaGasto = DateTime.Now;
            _db.Gastos.Add(gasto);
            _db.SaveChanges();
        }
        public void addIngreso(Ingreso ingreso)
        {
            ingreso.FechaIngreso = DateTime.Now;
            _db.Ingresos.Add(ingreso);
            _db.SaveChanges();
        }

        public double CalcularSaldo(Cuenta cuenta)
        {
           var gastos = _db.Gastos.Where(x => x.Cuenta == cuenta.CuentaId).ToList();
           var ingresos = _db.Ingresos.Where(x => x.Cuenta == cuenta.CuentaId).ToList();
            double gast=0.0;
            double ing = 0.0;
            foreach (var dato in gastos) {
                gast=gast+ Convert.ToDouble(dato.Monto);
            }
            foreach (var dato in ingresos)
            {
                ing = ing + Convert.ToDouble(dato.Monto);

            }
            var temp = Convert.ToDouble(cuenta.SaldoInicial) + ing - gast;
            return temp;
        }

        public Cuenta GetCuentaById(int id)
        {
           return  _db.Cuentas.Where(x => x.CuentaId == id).FirstOrDefault();
        }

        public IEnumerable<Cuenta> getCuentas()
        {
            return _db.Cuentas.ToList();
        }
    }

    public interface IBancoServices
    {
        void addCuenta(Cuenta cuenta);
        void addIngreso(Ingreso ingreso);
        void addGasto(Gasto gasto);
        IEnumerable<Cuenta> getCuentas();
        Cuenta GetCuentaById(int id);

        Double CalcularSaldo(Cuenta cuenta);
    }
}