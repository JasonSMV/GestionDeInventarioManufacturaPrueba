using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infractructure.Data.Config;

public class ProductosConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
        // Cada Producto tiene un solo estado/Tipo de elaboracion, pero un estado/tipo de elaboracion puede estar asociado con muchos productos.
        builder.HasOne(p => p.Estado).WithMany().HasForeignKey(p => p.EstadoId);
        builder.HasOne(p => p.TipoDeElaboracion).WithMany().HasForeignKey(p => p.TipoDeElaboracionId);
    }
}