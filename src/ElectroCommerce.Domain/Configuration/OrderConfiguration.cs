using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.Customer)
           .WithMany(x => x.Orders)
           .HasForeignKey(x => x.CustomerId)
           .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Supplier)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Employee)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OrderDetails)
                   .WithOne(x => x.Order)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
