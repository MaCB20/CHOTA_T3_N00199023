using CHOTA_T3.WEB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHOTA_T3.WEB.BD.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("Usuarios", "dbo");
            builder.HasKey(x => x.Id);
        }
    }
}
