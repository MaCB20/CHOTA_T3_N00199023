using CHOTA_T3.WEB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CHOTA_T3.WEB.BD.Mapping
{
    public class MascotaMapping : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable("Dueño", "dbo");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.dueño)
                .WithMany()
                .HasForeignKey(o => o.IdDueño);
        }
    }
}
