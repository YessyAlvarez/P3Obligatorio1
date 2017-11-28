namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingDBstructure1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TipoEventoes", "Descripcion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TipoEventoes", "Descripcion", c => c.String());
        }
    }
}
