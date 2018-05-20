namespace DBRepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pacote1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Morador",
                c => new
                    {
                        MoradorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataNascimento = c.String(maxLength: 10, unicode: false),
                        Telefone = c.String(maxLength: 15, unicode: false),
                        Cpf = c.String(maxLength: 14, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                        UnidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MoradorId)
                .ForeignKey("dbo.Unidade", t => t.UnidadeId, cascadeDelete: true)
                .Index(t => t.UnidadeId);
            
            CreateTable(
                "dbo.Unidade",
                c => new
                    {
                        UnidadeId = c.Int(nullable: false, identity: true),
                        Bloco = c.String(nullable: false, maxLength: 10, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.UnidadeId)
                .Index(t => new { t.Bloco, t.Numero }, unique: true, name: "IX_Unidade_BlocoNumero");
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Login = c.String(nullable: false, maxLength: 30, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 30, unicode: false),
                        ConfirmarSenha = c.String(unicode: false),
                        Situacao = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Morador", "UnidadeId", "dbo.Unidade");
            DropIndex("dbo.Unidade", "IX_Unidade_BlocoNumero");
            DropIndex("dbo.Morador", new[] { "UnidadeId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Unidade");
            DropTable("dbo.Morador");
        }
    }
}
