using FinalCalidad.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalCalidad.Db
{
    public class FinalCalidadContext : DbContext
    {
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Gasto> Gastos { get; set; }
        public virtual DbSet<Ingreso> Ingresos { get; set; }
        public FinalCalidadContext()
        {
            Database.SetInitializer<FinalCalidadContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Configurations.Add(new UsuarioMap());
            ////modelBuilder.Configurations.Add(new PublicacionMap());          
            //modelBuilder.Configurations.Add(new PlanMap());
       

        }
    }
}