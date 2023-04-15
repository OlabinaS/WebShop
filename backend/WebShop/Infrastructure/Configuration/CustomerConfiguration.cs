using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Infrastructure.Configuration
{
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			builder.Property(x => x.Name).HasMaxLength(30);
			builder.Property(x => x.Lastname).HasMaxLength(30);

			builder.HasIndex(x => x.Username).IsUnique();
			builder.Property(x => x.Username).HasMaxLength(30);

			//Email, Password, BDay, Address
		}
	}
}
