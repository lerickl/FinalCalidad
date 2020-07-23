namespace FinalCalidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vertion2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingresoes", "Cuenta", c => c.Int(nullable: false));
            AddColumn("dbo.Gastoes", "Cuenta", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gastoes", "Cuenta");
            DropColumn("dbo.Ingresoes", "Cuenta");
        }
    }
}
