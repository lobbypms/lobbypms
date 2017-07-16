namespace lobby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GruposYSubgrupos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transacciones", new[] { "ctGrupo_Id", "ctGrupo_Codigo" }, "dbo.ctGrupos");
            DropForeignKey("dbo.CodigosTransaccion", new[] { "Id", "Codigo" }, "dbo.ctGrupos");
            DropForeignKey("dbo.CodigosTransaccion", new[] { "Id", "Codigo" }, "dbo.ctSubgrupos");
            DropForeignKey("dbo.ctSubgrupos", new[] { "ctGrupo_Id", "ctGrupo_Codigo" }, "dbo.ctGrupos");
            DropForeignKey("dbo.Transacciones", new[] { "ctSubgrupo_Id", "ctSubgrupo_Codigo" }, "dbo.ctSubgrupos");
            DropForeignKey("dbo.Transacciones", "CodigoTransaccion_Id", "dbo.CodigosTransaccion");
            DropIndex("dbo.CodigosTransaccion", new[] { "Id", "Codigo" });
            DropIndex("dbo.ctSubgrupos", new[] { "ctGrupo_Id", "ctGrupo_Codigo" });
            DropIndex("dbo.Transacciones", new[] { "ctGrupo_Id", "ctGrupo_Codigo" });
            DropIndex("dbo.Transacciones", new[] { "ctSubgrupo_Id", "ctSubgrupo_Codigo" });
            DropColumn("dbo.ctSubgrupos", "CTGrupoId");
            DropColumn("dbo.Transacciones", "ctSubgrupoId");
            RenameColumn(table: "dbo.ctSubgrupos", name: "ctGrupo_Id", newName: "CTGrupoId");
            RenameColumn(table: "dbo.Transacciones", name: "ctSubgrupo_Id", newName: "ctSubgrupoId");
            DropPrimaryKey("dbo.CodigosTransaccion");
            DropPrimaryKey("dbo.ctGrupos");
            DropPrimaryKey("dbo.ctSubgrupos");
            AddColumn("dbo.CodigosTransaccion", "ctGrupo_Id", c => c.Int());
            AddColumn("dbo.CodigosTransaccion", "ctSubgrupo_Id", c => c.Int());
            AlterColumn("dbo.CodigosTransaccion", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ctGrupos", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ctGrupos", "Codigo", c => c.String(maxLength: 5));
            AlterColumn("dbo.ctSubgrupos", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ctSubgrupos", "Codigo", c => c.String(maxLength: 5));
            AlterColumn("dbo.ctSubgrupos", "CTGrupoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transacciones", "ctSubgrupoId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CodigosTransaccion", "Id");
            AddPrimaryKey("dbo.ctGrupos", "Id");
            AddPrimaryKey("dbo.ctSubgrupos", "Id");
            CreateIndex("dbo.CodigosTransaccion", "ctGrupo_Id");
            CreateIndex("dbo.CodigosTransaccion", "ctSubgrupo_Id");
            CreateIndex("dbo.ctGrupos", "Codigo", unique: true);
            CreateIndex("dbo.ctSubgrupos", "Codigo", unique: true);
            CreateIndex("dbo.ctSubgrupos", "CTGrupoId");
            CreateIndex("dbo.Transacciones", "ctSubgrupoId");
            AddForeignKey("dbo.CodigosTransaccion", "ctGrupo_Id", "dbo.ctGrupos", "Id");
            AddForeignKey("dbo.CodigosTransaccion", "ctSubgrupo_Id", "dbo.ctSubgrupos", "Id");
            AddForeignKey("dbo.ctSubgrupos", "CTGrupoId", "dbo.ctGrupos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transacciones", "ctSubgrupoId", "dbo.ctSubgrupos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transacciones", "CodigoTransaccion_Id", "dbo.CodigosTransaccion", "Id");
            DropColumn("dbo.ctSubgrupos", "ctGrupo_Codigo");
            DropColumn("dbo.Transacciones", "ctGrupoId");
            DropColumn("dbo.Transacciones", "ctGrupo_Id");
            DropColumn("dbo.Transacciones", "ctGrupo_Codigo");
            DropColumn("dbo.Transacciones", "ctSubgrupo_Codigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transacciones", "ctSubgrupo_Codigo", c => c.String(maxLength: 5));
            AddColumn("dbo.Transacciones", "ctGrupo_Codigo", c => c.String(maxLength: 5));
            AddColumn("dbo.Transacciones", "ctGrupo_Id", c => c.Int());
            AddColumn("dbo.Transacciones", "ctGrupoId", c => c.Int(nullable: false));
            AddColumn("dbo.ctSubgrupos", "ctGrupo_Codigo", c => c.String(maxLength: 5));
            DropForeignKey("dbo.Transacciones", "CodigoTransaccion_Id", "dbo.CodigosTransaccion");
            DropForeignKey("dbo.Transacciones", "ctSubgrupoId", "dbo.ctSubgrupos");
            DropForeignKey("dbo.ctSubgrupos", "CTGrupoId", "dbo.ctGrupos");
            DropForeignKey("dbo.CodigosTransaccion", "ctSubgrupo_Id", "dbo.ctSubgrupos");
            DropForeignKey("dbo.CodigosTransaccion", "ctGrupo_Id", "dbo.ctGrupos");
            DropIndex("dbo.Transacciones", new[] { "ctSubgrupoId" });
            DropIndex("dbo.ctSubgrupos", new[] { "CTGrupoId" });
            DropIndex("dbo.ctSubgrupos", new[] { "Codigo" });
            DropIndex("dbo.ctGrupos", new[] { "Codigo" });
            DropIndex("dbo.CodigosTransaccion", new[] { "ctSubgrupo_Id" });
            DropIndex("dbo.CodigosTransaccion", new[] { "ctGrupo_Id" });
            DropPrimaryKey("dbo.ctSubgrupos");
            DropPrimaryKey("dbo.ctGrupos");
            DropPrimaryKey("dbo.CodigosTransaccion");
            AlterColumn("dbo.Transacciones", "ctSubgrupoId", c => c.Int());
            AlterColumn("dbo.ctSubgrupos", "CTGrupoId", c => c.Int());
            AlterColumn("dbo.ctSubgrupos", "Codigo", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.ctSubgrupos", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ctGrupos", "Codigo", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.ctGrupos", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.CodigosTransaccion", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.CodigosTransaccion", "ctSubgrupo_Id");
            DropColumn("dbo.CodigosTransaccion", "ctGrupo_Id");
            AddPrimaryKey("dbo.ctSubgrupos", new[] { "Id", "Codigo" });
            AddPrimaryKey("dbo.ctGrupos", new[] { "Id", "Codigo" });
            AddPrimaryKey("dbo.CodigosTransaccion", "Id");
            RenameColumn(table: "dbo.Transacciones", name: "ctSubgrupoId", newName: "ctSubgrupo_Id");
            RenameColumn(table: "dbo.ctSubgrupos", name: "CTGrupoId", newName: "ctGrupo_Id");
            AddColumn("dbo.Transacciones", "ctSubgrupoId", c => c.Int(nullable: false));
            AddColumn("dbo.ctSubgrupos", "CTGrupoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transacciones", new[] { "ctSubgrupo_Id", "ctSubgrupo_Codigo" });
            CreateIndex("dbo.Transacciones", new[] { "ctGrupo_Id", "ctGrupo_Codigo" });
            CreateIndex("dbo.ctSubgrupos", new[] { "ctGrupo_Id", "ctGrupo_Codigo" });
            CreateIndex("dbo.CodigosTransaccion", new[] { "Id", "Codigo" });
            AddForeignKey("dbo.Transacciones", "CodigoTransaccion_Id", "dbo.CodigosTransaccion", "Id");
            AddForeignKey("dbo.Transacciones", new[] { "ctSubgrupo_Id", "ctSubgrupo_Codigo" }, "dbo.ctSubgrupos", new[] { "Id", "Codigo" });
            AddForeignKey("dbo.ctSubgrupos", new[] { "ctGrupo_Id", "ctGrupo_Codigo" }, "dbo.ctGrupos", new[] { "Id", "Codigo" });
            AddForeignKey("dbo.CodigosTransaccion", new[] { "Id", "Codigo" }, "dbo.ctSubgrupos", new[] { "Id", "Codigo" });
            AddForeignKey("dbo.CodigosTransaccion", new[] { "Id", "Codigo" }, "dbo.ctGrupos", new[] { "Id", "Codigo" });
            AddForeignKey("dbo.Transacciones", new[] { "ctGrupo_Id", "ctGrupo_Codigo" }, "dbo.ctGrupos", new[] { "Id", "Codigo" });
        }
    }
}
