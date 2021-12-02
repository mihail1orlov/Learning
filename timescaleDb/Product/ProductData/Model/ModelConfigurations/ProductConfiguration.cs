using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductData.Model.ModelConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(prop => prop.ProductId);
            
            builder.Property(prop => prop.CreateOn)
                .HasColumnType("TIMESTAMP(0)")
                .IsRequired();

            builder.Property(prop => prop.Body)
                .HasMaxLength(1000);

            builder.Property(prop => prop.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(prop => prop.IsCompleted)
                .IsRequired();
            
        }
    }
}