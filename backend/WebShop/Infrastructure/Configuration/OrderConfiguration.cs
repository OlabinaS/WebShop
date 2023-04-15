using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Infrastructure.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.Comment).HasMaxLength(500);

			builder.HasOne(x => x.Customer)
				   .WithMany(x => x.Orders)
				   .HasForeignKey(x => x.CustomerId)
				   .OnDelete(DeleteBehavior.Cascade);

			//OrderDate, DeliveryDate, Address
		}
	}
}
