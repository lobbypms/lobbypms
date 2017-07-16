namespace lobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModPerfiles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservas", "Perfil_Id", "dbo.Perfiles");
            DropIndex("dbo.Reservas", new[] { "Perfil_Id" });
            RenameColumn(table: "dbo.Reservas", name: "Perfil_Id", newName: "PerfilId");
            AlterColumn("dbo.Reservas", "PerfilId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservas", "PerfilId");
            AddForeignKey("dbo.Reservas", "PerfilId", "dbo.Perfiles", "Id", cascadeDelete: true);
            DropColumn("dbo.Reservas", "HuespedID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservas", "HuespedID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reservas", "PerfilId", "dbo.Perfiles");
            DropIndex("dbo.Reservas", new[] { "PerfilId" });
            AlterColumn("dbo.Reservas", "PerfilId", c => c.Int());
            RenameColumn(table: "dbo.Reservas", name: "PerfilId", newName: "Perfil_Id");
            CreateIndex("dbo.Reservas", "Perfil_Id");
            AddForeignKey("dbo.Reservas", "Perfil_Id", "dbo.Perfiles", "Id");
        }
    }
}
