using Microsoft.EntityFrameworkCore;

namespace UD25_EJ1.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options) { }

        //Listas
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fabricante>(entity => 
            {
                entity.ToTable("Fabricantes");

                //Columna codigo y Primary key
                entity.Property(e => e.Codigo).HasColumnName("Codigo");
                entity.HasKey(e => e.Codigo);

                //Columnas y caracteristicas
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.ToTable("Articulos");

                //Columna codigo y Primary key
                entity.Property(e => e.Codigo).HasColumnName("Codigo");
                entity.HasKey(e => e.Codigo);

                //Columnas y caracteristicas
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .IsUnicode();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(100);

                entity.Property(e => e.Precio)
                    .IsRequired()
                    .IsUnicode();

                entity.Property(e => e.Fabricante)
                    .IsRequired()
                    .IsUnicode();

                //Relaciones de las tablas
                entity.HasOne(e => e.Fabricantes)
                    .WithMany(a => a.Articulos)
                    .HasForeignKey(f => f.Fabricante)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

        }

    }
}
