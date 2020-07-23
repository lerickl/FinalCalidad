namespace FinalCalidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingresoes",
                c => new
                    {
                        IngresoId = c.Int(nullable: false, identity: true),
                        FechaIngreso = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        Monto = c.String(),
                        CuentaId_CuentaId = c.Int(),
                    })
                .PrimaryKey(t => t.IngresoId)
                .ForeignKey("dbo.Cuentas", t => t.CuentaId_CuentaId)
                .Index(t => t.CuentaId_CuentaId);
            
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        CuentaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Categoria = c.String(),
                        SaldoInicial = c.String(),
                    })
                .PrimaryKey(t => t.CuentaId);
            
            CreateTable(
                "dbo.Gastoes",
                c => new
                    {
                        GastoId = c.Int(nullable: false, identity: true),
                        FechaGasto = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        Monto = c.String(),
                        CuentaId_CuentaId = c.Int(),
                    })
                .PrimaryKey(t => t.GastoId)
                .ForeignKey("dbo.Cuentas", t => t.CuentaId_CuentaId)
                .Index(t => t.CuentaId_CuentaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingresoes", "CuentaId_CuentaId", "dbo.Cuentas");
            DropForeignKey("dbo.Gastoes", "CuentaId_CuentaId", "dbo.Cuentas");
            DropIndex("dbo.Gastoes", new[] { "CuentaId_CuentaId" });
            DropIndex("dbo.Ingresoes", new[] { "CuentaId_CuentaId" });
            DropTable("dbo.Gastoes");
            DropTable("dbo.Cuentas");
            DropTable("dbo.Ingresoes");
        }
    }
}
