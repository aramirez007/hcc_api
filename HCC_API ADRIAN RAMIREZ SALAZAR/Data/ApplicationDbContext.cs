using Microsoft.EntityFrameworkCore;
using HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models;


namespace HCC_API_ADRIAN_RAMIREZ_SALAZAR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<HccOrden> HccOrdenes { get; set; }
        public DbSet<HccMesa> HccMesas { get; set; }
        public DbSet<HccCatEstatusOrden> HccCatEstatusOrdenes { get; set; }
        public DbSet<HccOrdenDetalle> HccOrdenDetalles { get; set; }
        public DbSet<HccProducto> HccProductos { get; set; }
        public DbSet<HccAlmacen> HccAlmacenes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir claves primarias
            modelBuilder.Entity<HccAlmacen>().HasKey(a => a.alm_id);
            modelBuilder.Entity<HccCatEstatusOrden>().HasKey(a => a.catord_id);
            modelBuilder.Entity<HccMesa>().HasKey(a => a.mes_id);
            modelBuilder.Entity<HccOrden>().HasKey(a => a.ord_id);
            modelBuilder.Entity<HccOrdenDetalle>().HasKey(a => a.orddet_id);
            modelBuilder.Entity<HccProducto>().HasKey(a => a.pro_id);

            // Relación entre HccOrden y HccMesa (una orden está asociada a una mesa)
            modelBuilder.Entity<HccOrden>()
                .HasOne(o => o.Mesas)
                .WithMany()
                .HasForeignKey(o => o.mes_id)
                .OnDelete(DeleteBehavior.Restrict);  // Puedes modificar el comportamiento de eliminación según tus necesidades

            // Relación entre HccOrden y HccCatEstatusOrden
            modelBuilder.Entity<HccOrden>()
                .HasOne(o => o.EstatusOrden)
                .WithMany()
                .HasForeignKey(o => o.catord_id)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación entre HccOrden y HccOrdenDetalle
            modelBuilder.Entity<HccOrden>()
                .HasMany(o => o.OrdenDetalles)
                .WithOne(od => od.Orden)
                .HasForeignKey(od => od.ord_id)
                .OnDelete(DeleteBehavior.Cascade);  // Si se elimina una orden, se eliminan sus detalles

            // Relación entre HccOrdenDetalle y HccProducto
            modelBuilder.Entity<HccOrdenDetalle>()
                .HasOne(od => od.Producto)
                .WithMany()
                .HasForeignKey(od => od.pro_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
