using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KAM.Models
{
    public partial class assistance_koll_brContext : DbContext
    {
        public assistance_koll_brContext()
        {
        }

        public assistance_koll_brContext(DbContextOptions<assistance_koll_brContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Equipamento> Equipamentos { get; set; }
        public virtual DbSet<Falhaakd> Falhaakds { get; set; }
        public virtual DbSet<Ficha> Fichas { get; set; }
        public virtual DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente", "assistance_koll_br");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cel)
                    .HasMaxLength(45)
                    .HasColumnName("cel");

                entity.Property(e => e.Cliente1)
                    .HasMaxLength(45)
                    .HasColumnName("cliente");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(45)
                    .HasColumnName("departamento");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.Responsavel)
                    .HasMaxLength(45)
                    .HasColumnName("responsavel");

                entity.Property(e => e.TelFixo)
                    .HasMaxLength(45)
                    .HasColumnName("telFixo");
            });

            modelBuilder.Entity<Equipamento>(entity =>
            {
                entity.HasKey(e => e.Os)
                    .HasName("PK_equipamento_os");

                entity.ToTable("equipamento", "assistance_koll_br");

                entity.Property(e => e.Os).HasColumnName("os");

                entity.Property(e => e.Data)
                    .HasMaxLength(45)
                    .HasColumnName("data");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(45)
                    .HasColumnName("empresa");

                entity.Property(e => e.Equipamento1)
                    .HasMaxLength(45)
                    .HasColumnName("equipamento");

                entity.Property(e => e.Nf)
                    .HasMaxLength(45)
                    .HasColumnName("nf");

                entity.Property(e => e.Sn)
                    .HasMaxLength(45)
                    .HasColumnName("sn");
            });

            modelBuilder.Entity<Falhaakd>(entity =>
            {
                entity.ToTable("falhaakd", "assistance_koll_br");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Causa)
                    .HasMaxLength(500)
                    .HasColumnName("causa");

                entity.Property(e => e.Falha)
                    .HasMaxLength(45)
                    .HasColumnName("falha");

                entity.Property(e => e.Mensagem)
                    .HasMaxLength(500)
                    .HasColumnName("mensagem");

                entity.Property(e => e.Solucao)
                    .HasMaxLength(500)
                    .HasColumnName("solucao");
            });

            modelBuilder.Entity<Ficha>(entity =>
            {
                entity.HasKey(e => e.Os)
                    .HasName("PK_ficha_os");

                entity.ToTable("ficha", "assistance_koll_br");

                entity.Property(e => e.Os)
                    .HasMaxLength(45)
                    .HasColumnName("os");

                entity.Property(e => e.Ano)
                    .HasMaxLength(45)
                    .HasColumnName("ano");

                entity.Property(e => e.Comentario).HasColumnName("comentario");

                entity.Property(e => e.DefDeclarado).HasColumnName("def_declarado");

                entity.Property(e => e.DefEncontrado).HasColumnName("def_encontrado");

                entity.Property(e => e.Garantia)
                    .HasMaxLength(45)
                    .HasColumnName("garantia");

                entity.Property(e => e.Inicio)
                    .HasMaxLength(45)
                    .HasColumnName("inicio");

                entity.Property(e => e.Ok)
                    .HasMaxLength(45)
                    .HasColumnName("ok");

                entity.Property(e => e.Reclamacao)
                    .HasMaxLength(45)
                    .HasColumnName("reclamacao");

                entity.Property(e => e.Responsavel)
                    .HasMaxLength(45)
                    .HasColumnName("responsavel");

                entity.Property(e => e.Retorno)
                    .HasMaxLength(45)
                    .HasColumnName("retorno");

                entity.Property(e => e.Solucao).HasColumnName("solucao");

                entity.Property(e => e.Termino)
                    .HasMaxLength(45)
                    .HasColumnName("termino");

                entity.Property(e => e.Total)
                    .HasMaxLength(45)
                    .HasColumnName("total");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Usuario)
                    .HasName("PK_login_usuario");

                entity.ToTable("login", "assistance_koll_br");

                entity.HasIndex(e => e.Usuario, "login$usuario_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .HasColumnName("usuario");

                entity.Property(e => e.Apelido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("apelido");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Senha).HasColumnName("senha");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
