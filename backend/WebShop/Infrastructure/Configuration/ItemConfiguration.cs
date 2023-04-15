using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Infrastructure.Configuration
{
	public class ItemConfiguration : IEntityTypeConfiguration<Item>
	{
		public void Configure(EntityTypeBuilder<Item> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.Name).HasMaxLength(30);
			builder.Property(x => x.Description).HasMaxLength(1500);

			builder.HasOne(x => x.Seller)
				   .WithMany(x => x.Items)
				   .HasForeignKey(x => x.SellerId)
				   .OnDelete(DeleteBehavior.Cascade);


			//Price, Quantity
		}
	}
}
