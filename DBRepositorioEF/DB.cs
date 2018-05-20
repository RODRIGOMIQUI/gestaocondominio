using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;
using DBDominio;

namespace DBRepositorioEF
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DB : DbContext
    {
        public DB() : base(nameOrConnectionString: "MySQLDB") { }

        public DbSet<Morador> morador { get; set; }
        public DbSet<Unidade> unidade { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // UNIDADE
            modelBuilder.Entity<Unidade>().Property(x => x.Bloco).IsRequired().HasColumnType("varchar").HasMaxLength(10);
            modelBuilder.Entity<Unidade>().Property(x => x.Numero).IsRequired().HasColumnType("varchar").HasMaxLength(10);

            // MORADOR
            modelBuilder.Entity<Morador>().Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Entity<Morador>().Property(x => x.DataNascimento).HasColumnType("varchar").HasMaxLength(10);
            modelBuilder.Entity<Morador>().Property(x => x.Telefone).HasColumnType("varchar").HasMaxLength(15);
            modelBuilder.Entity<Morador>().Property(x => x.Cpf).HasColumnType("varchar").HasMaxLength(14);
            modelBuilder.Entity<Morador>().Property(x => x.Email).HasColumnType("varchar").HasMaxLength(200);
            //modelBuilder.Entity<Morador>().Property(x => x.Responsavel).HasColumnType("char").HasMaxLength(1);

            // UNIDADES x MORADORES
            modelBuilder.Entity<Morador>()
                .HasRequired<Unidade>(s => s.Unidade)
                .WithMany(g => g.Moradores)
                .HasForeignKey<int>(s => s.UnidadeId);
        }

    }
}
