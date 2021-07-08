using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiClient.Models
{
    public partial class ProyectoFinal_cliente_AIMMContext : DbContext
    {
        public ProyectoFinal_cliente_AIMMContext()
        {
        }

        public ProyectoFinal_cliente_AIMMContext(DbContextOptions<ProyectoFinal_cliente_AIMMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server=163.178.107.10;Initial Catalog=ProyectoFinal_cliente_AIMM;User ID=laboratorios;Password=KmZpo.2796");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.ToTable("Client");

                entity.Property(e => e.IdClient).HasColumnName("Id_Client");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('DBA')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.FirstSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SecondContact)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SecondSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Client')");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdComment);

                entity.ToTable("Comment");

                entity.Property(e => e.IdComment).HasColumnName("Id_Comment");

                entity.Property(e => e.CommentTimestamp).HasColumnType("date");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('DBA')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdIssue).HasColumnName("Id_Issue");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Client')");

                entity.HasOne(d => d.IdIssueNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdIssue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Issue");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.IdIssue);

                entity.ToTable("Issue");

                entity.Property(e => e.IdIssue).HasColumnName("Id_Issue");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.ContactPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('DBA')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdClient).HasColumnName("Id_Client");

                entity.Property(e => e.RegisterTimestamp).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SupportUserAssigned)
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Client')");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Issue_Client");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
