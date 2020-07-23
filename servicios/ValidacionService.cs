using FinalCalidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCalidad.servicios
{
    public class ValidacionService : IValidacionService
    {
        public void validarCuenta(Cuenta cuenta, ModelStateDictionary modelState)
        {
            if (string.IsNullOrEmpty(cuenta.Nombre))
                modelState.AddModelError("Nombre", "El nombre es campo obligatorio!");
            if (cuenta.Categoria=="0")
                modelState.AddModelError("Categoria", "la categoria es campo obligatorio!");
            if (string.IsNullOrEmpty(cuenta.SaldoInicial))
                modelState.AddModelError("SaldoInicial", "El Saldo Inicial es campo obligatorio!");

        }

        public void validarGasto(Gasto gasto, ModelStateDictionary modelState, Double saldo)
        {
            if (gasto.Cuenta==0)
                modelState.AddModelError("Cuenta", "Seleccione cuenta es campo obligatorio!");
            if (string.IsNullOrEmpty(gasto.Descripcion))
                modelState.AddModelError("Descripcion", "la Descripcion es campo obligatorio!");
            if (string.IsNullOrEmpty(gasto.Monto))
                modelState.AddModelError("Monto", "el Monto es campo obligatorio!");
            var temp = Convert.ToDouble(gasto.Monto);
            if (temp>saldo)
                modelState.AddModelError("Monto", "supera su saldo actual!");

        }

        public void validarIngreso(Ingreso ingreso, ModelStateDictionary modelState)
        {
            if (ingreso.Cuenta == 0)
                modelState.AddModelError("Cuenta", "Seleccione cuenta es campo obligatorio!");
            if (string.IsNullOrEmpty(ingreso.Descripcion))
                modelState.AddModelError("Descripcion", "la Descripcion es campo obligatorio!");
            if (string.IsNullOrEmpty(ingreso.Monto))
                modelState.AddModelError("Monto", "el Monto es campo obligatorio!");
        }
    }

    public interface IValidacionService
    {
        void validarCuenta(Cuenta cuenta, ModelStateDictionary modelState);
        void validarGasto(Gasto gasto, ModelStateDictionary modelState, Double saldo);
        void validarIngreso(Ingreso ingreso, ModelStateDictionary modelState);

    }
}