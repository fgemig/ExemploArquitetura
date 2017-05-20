using FG.MusicStore.Domain.Entities.Customers;
using FG.MusicStore.Infra.Data.Mappings.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FG.MusicStore.Infra.Data.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public override void Map(EntityTypeBuilder<Customer> builder)
        {

            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(150)")
                .IsRequired();

        }
    }
}
