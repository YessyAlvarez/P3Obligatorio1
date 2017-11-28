namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingDBstructure2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TipoEventoes", "Servicio_Id", "dbo.Servicios");
            DropForeignKey("dbo.Eventoes", "TipoEvento_Id", "dbo.TipoEventoes");
            DropIndex("dbo.Eventoes", new[] { "TipoEvento_Id" });
            DropIndex("dbo.TipoEventoes", new[] { "Servicio_Id" });
            DropColumn("dbo.TipoEventoes", "Id");
            RenameColumn(table: "dbo.Eventoes", name: "TipoEvento_Id", newName: "TipoEvento_Nombre");
            RenameColumn(table: "dbo.TipoEventoes", name: "Servicio_Id", newName: "Id");
            DropPrimaryKey("dbo.TipoEventoes");
            AlterColumn("dbo.Eventoes", "TipoEvento_Nombre", c => c.String(maxLength: 128));
            AlterColumn("dbo.TipoEventoes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.TipoEventoes", "Nombre", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TipoEventoes", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TipoEventoes", "Nombre");
            CreateIndex("dbo.Eventoes", "TipoEvento_Nombre");
            CreateIndex("dbo.TipoEventoes", "Id");
            AddForeignKey("dbo.TipoEventoes", "Id", "dbo.Servicios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Eventoes", "TipoEvento_Nombre", "dbo.TipoEventoes", "Nombre");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eventoes", "TipoEvento_Nombre", "dbo.TipoEventoes");
            DropForeignKey("dbo.TipoEventoes", "Id", "dbo.Servicios");
            DropIndex("dbo.TipoEventoes", new[] { "Id" });
            DropIndex("dbo.Eventoes", new[] { "TipoEvento_Nombre" });
            DropPrimaryKey("dbo.TipoEventoes");
            AlterColumn("dbo.TipoEventoes", "Id", c => c.Int());
            AlterColumn("dbo.TipoEventoes", "Nombre", c => c.String());
            AlterColumn("dbo.TipoEventoes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Eventoes", "TipoEvento_Nombre", c => c.Int());
            AddPrimaryKey("dbo.TipoEventoes", "Id");
            RenameColumn(table: "dbo.TipoEventoes", name: "Id", newName: "Servicio_Id");
            RenameColumn(table: "dbo.Eventoes", name: "TipoEvento_Nombre", newName: "TipoEvento_Id");
            AddColumn("dbo.TipoEventoes", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.TipoEventoes", "Servicio_Id");
            CreateIndex("dbo.Eventoes", "TipoEvento_Id");
            AddForeignKey("dbo.Eventoes", "TipoEvento_Id", "dbo.TipoEventoes", "Id");
            AddForeignKey("dbo.TipoEventoes", "Servicio_Id", "dbo.Servicios", "Id");
        }
    }
}
