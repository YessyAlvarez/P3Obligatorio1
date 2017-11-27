namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingDBstructure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProveedorServicios", "Proveedor", c => c.String());
            AddColumn("dbo.ProveedorServicios", "NombreServicio", c => c.String());
            DropColumn("dbo.ProveedorServicios", "IdProveedor");
            DropColumn("dbo.ProveedorServicios", "IdServicio");
            DropColumn("dbo.Servicios", "IdServicio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicios", "IdServicio", c => c.Int(nullable: false));
            AddColumn("dbo.ProveedorServicios", "IdServicio", c => c.Int(nullable: false));
            AddColumn("dbo.ProveedorServicios", "IdProveedor", c => c.String());
            DropColumn("dbo.ProveedorServicios", "NombreServicio");
            DropColumn("dbo.ProveedorServicios", "Proveedor");
        }
    }
}
