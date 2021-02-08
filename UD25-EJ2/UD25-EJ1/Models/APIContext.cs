using Microsoft.EntityFrameworkCore;

namespace UD25_EJ1.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options) { }

        //Listas
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("Departamentos");

                //Columna codigo y Primary key
                entity.Property(e => e.Codigo).HasColumnName("Codigo");
                entity.HasKey(e => e.Codigo);

                //Columnas y caracteristicas
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(100);

                entity.Property(e => e.Presupuesto)
                   .IsRequired();
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleados");

                //Columna codigo y Primary key
                entity.Property(e => e.Dni).HasColumnName("DNI");
                entity.HasKey(e => e.Dni);

                //Columnas y caracteristicas
                entity.Property(e => e.Dni)
                    .IsRequired()
                    .IsUnicode();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(100);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(255);

                entity.Property(e => e.Dep)
                    .IsRequired();

                //Relaciones de las tablas
                entity.HasOne(f => f.Departamentos)
                    .WithMany(e => e.Empleados)
                    .HasForeignKey(k => k.Dep);
            });

        }

    }
}
