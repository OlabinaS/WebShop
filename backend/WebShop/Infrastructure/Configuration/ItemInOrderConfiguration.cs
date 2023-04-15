using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Infrastructure.Configuration
{
	public class ItemInOrderConfiguration : IEntityTypeConfiguration<ItemInOrder>
	{
		public void Configure(EntityTypeBuilder<ItemInOrder> builder)
		{
			builder.HasKey(x => new { x.ItemId, x.OrderId });

			builder.HasOne(x => x.Order)
				   .WithMany(x => x.Items)
				   .HasForeignKey(x => x.OrderId);

			builder.HasOne(x => x.Item)
				   .WithMany()
				   .HasForeignKey(x => x.ItemId);

			// Quantity, Price
		}
	}
}
