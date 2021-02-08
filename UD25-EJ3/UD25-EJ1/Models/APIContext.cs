using Microsoft.EntityFrameworkCore;

namespace UD25_EJ1.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options) { }

        //Listas
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Caja> Cajas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.ToTable("Almacenes");

                //Columna codigo y Primary key
                entity.Property(e => e.Codigo).HasColumnName("Codigo");
                entity.HasKey(e => e.Codigo);

                //Columnas y caracteristicas
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Lugar)
                    .IsUnicode()
                    .HasMaxLength(100);

                entity.Property(e => e.Capacidad)
                   .IsRequired();
            });

            modelBuilder.Entity<Caja>(entity =>
            {
                entity.ToTable("Cajas");

                //Columna codigo y Primary key
                entity.Property(e => e.NumReferencia)
                    .HasColumnName("NumReferencia")
                    .HasMaxLength(5);
                entity.HasKey(e => e.NumReferencia);

                //Columnas y caracteristicas
                entity.Property(e => e.Contenido)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Almacen)
                    .IsRequired()
                    .IsUnicode(false);

                //Relaciones de las tablas
                entity.HasOne(a => a.Almacenes)
                    .WithMany(c => c.Cajas)
                    .HasForeignKey(fk => fk.Almacen)
                    .HasConstraintName("Almacen_fk");
            });

        }

    }
}
