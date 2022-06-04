using Microsoft.EntityFrameworkCore;
using CHOTA_T3.WEB.Models;
using CHOTA_T3.WEB.BD.Mapping;

namespace CHOTA_T3.WEB.BD
{
    public class DbEntities : DbContext
    {
        public DbSet<Dueño> dueños { get; set; }
        public DbSet<HistoriaClinica> historiaClinicas { get; set; }
        public DbSet<Mascota> mascotas { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbEntities() { }
        public DbEntities(DbContextOptions<DbEntities> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DueñoMapping());
            modelBuilder.ApplyConfiguration(new HistoriaClinicaMapping());
            modelBuilder.ApplyConfiguration(new MascotaMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
        }
    }
}
