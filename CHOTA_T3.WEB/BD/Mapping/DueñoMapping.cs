using CHOTA_T3.WEB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHOTA_T3.WEB.BD.Mapping
{
    public class DueñoMapping : IEntityTypeConfiguration<Dueño>
    {
        public void Configure(EntityTypeBuilder<Dueño> builder)
        {
            builder.ToTable("Dueño", "dbo");
            builder.HasKey(o => o.id);


        }
    }
}
