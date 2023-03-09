using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class ApliClassDBContext : DbContext
    {
        public ApliClassDBContext()
        {
        }

        public ApliClassDBContext(DbContextOptions<ApliClassDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asistencia> Asistencias { get; set; } = null!;
        public virtual DbSet<Clase> Clases { get; set; } = null!;
        public virtual DbSet<ClasesListasdeEstudiante> ClasesListasdeEstudiantes { get; set; } = null!;
        public virtual DbSet<ClasesListasdeLeccione> ClasesListasdeLecciones { get; set; } = null!;
        public virtual DbSet<ClasesNota> ClasesNotas { get; set; } = null!;
        public virtual DbSet<ListasdeEstudiante> ListasdeEstudiantes { get; set; } = null!;
        public virtual DbSet<ListasdeLeccione> ListasdeLecciones { get; set; } = null!;
        public virtual DbSet<ListasdeLeccionesAsistencia> ListasdeLeccionesAsistencias { get; set; } = null!;
        public virtual DbSet<Nota> Notas { get; set; } = null!;
        public virtual DbSet<TiposdeEstado> TiposdeEstados { get; set; } = null!;
        public virtual DbSet<TiposdeUsuario> TiposdeUsuarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuariosAsistencia> UsuariosAsistencias { get; set; } = null!;
        public virtual DbSet<UsuariosListasdeEstudiante> UsuariosListasdeEstudiantes { get; set; } = null!;
        public virtual DbSet<UsuariosNota> UsuariosNotas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ApliClassDB;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Estado).HasMaxLength(255);
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<ClasesListasdeEstudiante>(entity =>
            {
                entity.HasKey(e => new { e.ClasesId, e.ListasdeEstudiantesClase })
                    .HasName("PK__Clases_L__17CEE3516726E026");

                entity.ToTable("Clases_ListasdeEstudiantes");

                entity.Property(e => e.ClasesId).HasColumnName("Clases_ID");

                entity.Property(e => e.ListasdeEstudiantesClase).HasColumnName("ListasdeEstudiantes_Clase");

                entity.HasOne(d => d.Clases)
                    .WithMany(p => p.ClasesListasdeEstudiantes)
                    .HasForeignKey(d => d.ClasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clases_Li__Clase__4CA06362");
            });

            modelBuilder.Entity<ClasesListasdeLeccione>(entity =>
            {
                entity.HasKey(e => new { e.ClasesId, e.ListasdeLeccionesClase })
                    .HasName("PK__Clases_L__F3E9F6F18D3D830E");

                entity.ToTable("Clases_ListasdeLecciones");

                entity.Property(e => e.ClasesId).HasColumnName("Clases_ID");

                entity.Property(e => e.ListasdeLeccionesClase).HasColumnName("ListasdeLecciones_Clase");

                entity.HasOne(d => d.Clases)
                    .WithMany(p => p.ClasesListasdeLecciones)
                    .HasForeignKey(d => d.ClasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clases_Li__Clase__5070F446");
            });

            modelBuilder.Entity<ClasesNota>(entity =>
            {
                entity.HasKey(e => new { e.ClasesId, e.NotasClase })
                    .HasName("PK__Clases_N__5E53C8543A6FC72D");

                entity.ToTable("Clases_Notas");

                entity.Property(e => e.ClasesId).HasColumnName("Clases_ID");

                entity.Property(e => e.NotasClase).HasColumnName("Notas_Clase");

                entity.HasOne(d => d.Clases)
                    .WithMany(p => p.ClasesNota)
                    .HasForeignKey(d => d.ClasesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clases_No__Clase__60A75C0F");
            });

            modelBuilder.Entity<ListasdeEstudiante>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<ListasdeLeccione>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fecha)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Numero).HasMaxLength(255);
            });

            modelBuilder.Entity<ListasdeLeccionesAsistencia>(entity =>
            {
                entity.HasKey(e => new { e.ListasdeLeccionesId, e.AsistenciasLeccion })
                    .HasName("PK__Listasde__612239B191AA43D3");

                entity.ToTable("ListasdeLecciones_Asistencias");

                entity.Property(e => e.ListasdeLeccionesId).HasColumnName("ListasdeLecciones_ID");

                entity.Property(e => e.AsistenciasLeccion).HasColumnName("Asistencias_Leccion");

                entity.HasOne(d => d.ListasdeLecciones)
                    .WithMany(p => p.ListasdeLeccionesAsistencia)
                    .HasForeignKey(d => d.ListasdeLeccionesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ListasdeL__Lista__5441852A");
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.Property(e => e.Nota1).HasColumnName("Nota");
            });

            modelBuilder.Entity<TiposdeEstado>(entity =>
            {
                entity.ToTable("TiposdeEstado");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tipo).HasMaxLength(255);
            });

            modelBuilder.Entity<TiposdeUsuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tipo).HasMaxLength(255);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Coreo)
                    .HasMaxLength(255)
                    .HasColumnName("coreo");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.Property(e => e._1apellido)
                    .HasMaxLength(255)
                    .HasColumnName("1Apellido");

                entity.Property(e => e._2apellido)
                    .HasMaxLength(255)
                    .HasColumnName("2Apellido");
            });

            modelBuilder.Entity<UsuariosAsistencia>(entity =>
            {
                entity.HasKey(e => new { e.UsuariosId, e.AsistenciasEstudiante })
                    .HasName("PK__usuarios__87CA5E8CD0A8AFBC");

                entity.ToTable("usuarios_Asistencias");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_ID");

                entity.Property(e => e.AsistenciasEstudiante).HasColumnName("Asistencias_Estudiante");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.UsuariosAsistencia)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios___usuar__5812160E");
            });

            modelBuilder.Entity<UsuariosListasdeEstudiante>(entity =>
            {
                entity.HasKey(e => new { e.UsuariosId, e.ListasdeEstudiantesEstudiante })
                    .HasName("PK__usuarios__3B74F3A6A8CDF04F");

                entity.ToTable("usuarios_ListasdeEstudiantes");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_ID");

                entity.Property(e => e.ListasdeEstudiantesEstudiante).HasColumnName("ListasdeEstudiantes_Estudiante");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.UsuariosListasdeEstudiantes)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios___usuar__48CFD27E");
            });

            modelBuilder.Entity<UsuariosNota>(entity =>
            {
                entity.HasKey(e => new { e.UsuariosId, e.NotasEstudiante })
                    .HasName("PK__usuarios__35C1F2B78BEBBBD0");

                entity.ToTable("usuarios_Notas");

                entity.Property(e => e.UsuariosId).HasColumnName("usuarios_ID");

                entity.Property(e => e.NotasEstudiante).HasColumnName("Notas_Estudiante");

                entity.HasOne(d => d.Usuarios)
                    .WithMany(p => p.UsuariosNota)
                    .HasForeignKey(d => d.UsuariosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios___usuar__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
