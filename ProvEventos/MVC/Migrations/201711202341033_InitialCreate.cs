namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventoProveedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Puntaje = c.Int(nullable: false),
                        Comentario = c.String(),
                        ProveedorRUT = c.Int(nullable: false),
                        Evento_Id = c.Int(),
                        Organizador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Eventoes", t => t.Evento_Id)
                .ForeignKey("dbo.Usuarios", t => t.Organizador_Id)
                .Index(t => t.Evento_Id)
                .Index(t => t.Organizador_Id);
            
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Direccion = c.String(),
                        Organizador_Id = c.Int(),
                        TipoEvento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Organizador_Id)
                .ForeignKey("dbo.TipoEventoes", t => t.TipoEvento_Id)
                .Index(t => t.Organizador_Id)
                .Index(t => t.TipoEvento_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioLogin = c.String(),
                        Password = c.String(),
                        TipoPerfil = c.Int(nullable: false),
                        NombreApellido = c.String(),
                        Telefono = c.String(),
                        RUT = c.String(),
                        NombreFantasia = c.String(),
                        Email = c.String(),
                        FechaRegistro = c.DateTime(),
                        Telefono1 = c.String(),
                        VIP = c.Boolean(),
                        ArancelVIP = c.Double(),
                        Activo = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoEventoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Servicio_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Servicios", t => t.Servicio_Id)
                .Index(t => t.Servicio_Id);
            
            CreateTable(
                "dbo.ProveedorServicios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProveedor = c.String(),
                        IdServicio = c.Int(nullable: false),
                        Imagen = c.String(),
                        Descripcion = c.String(),
                        Activo = c.Boolean(nullable: false),
                        EventoProveedor_Id = c.Int(),
                        Proveedor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventoProveedors", t => t.EventoProveedor_Id)
                .ForeignKey("dbo.Usuarios", t => t.Proveedor_Id)
                .Index(t => t.EventoProveedor_Id)
                .Index(t => t.Proveedor_Id);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdServicio = c.Int(nullable: false),
                        NombreServicio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoEventoes", "Servicio_Id", "dbo.Servicios");
            DropForeignKey("dbo.ProveedorServicios", "Proveedor_Id", "dbo.Usuarios");
            DropForeignKey("dbo.EventoProveedors", "Organizador_Id", "dbo.Usuarios");
            DropForeignKey("dbo.ProveedorServicios", "EventoProveedor_Id", "dbo.EventoProveedors");
            DropForeignKey("dbo.Eventoes", "TipoEvento_Id", "dbo.TipoEventoes");
            DropForeignKey("dbo.Eventoes", "Organizador_Id", "dbo.Usuarios");
            DropForeignKey("dbo.EventoProveedors", "Evento_Id", "dbo.Eventoes");
            DropIndex("dbo.ProveedorServicios", new[] { "Proveedor_Id" });
            DropIndex("dbo.ProveedorServicios", new[] { "EventoProveedor_Id" });
            DropIndex("dbo.TipoEventoes", new[] { "Servicio_Id" });
            DropIndex("dbo.Eventoes", new[] { "TipoEvento_Id" });
            DropIndex("dbo.Eventoes", new[] { "Organizador_Id" });
            DropIndex("dbo.EventoProveedors", new[] { "Organizador_Id" });
            DropIndex("dbo.EventoProveedors", new[] { "Evento_Id" });
            DropTable("dbo.Servicios");
            DropTable("dbo.ProveedorServicios");
            DropTable("dbo.TipoEventoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Eventoes");
            DropTable("dbo.EventoProveedors");
        }
    }
}
