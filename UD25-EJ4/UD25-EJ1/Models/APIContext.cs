using Microsoft.EntityFrameworkCore;

namespace UD25_EJ1.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options) { }

        //Listas
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("Peliculas");

                //Columna codigo y Primary key
                entity.HasKey(e => e.Codigo);

                //Columnas y caracteristicas
                entity.Property(e => e.Codigo)
                    .HasColumnName("Codigo")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsUnicode()
                    .HasMaxLength(100);

                entity.Property(e => e.CalificacionEdad)
                   .IsRequired()
                   .IsUnicode(false);
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Salas");

                //Columna codigo y Primary key
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo)
                    .HasColumnName("Codigo");

                //Columnas y caracteristicas
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);

                entity.Property(e => e.Pelicula)
                    .IsRequired()
                    .IsUnicode(false);

                //Relaciones de las tablas
                entity.HasOne(p => p.Peliculas)
                    .WithMany(s => s.Salas)
                    .HasForeignKey(fk => fk.Pelicula)
                    .HasConstraintName("Pelicula_fk");
            });

        }

    }
}
