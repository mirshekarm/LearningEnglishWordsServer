using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
	internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
	{
		public TicketConfiguration() : base()
		{
		}


		public void Configure(EntityTypeBuilder<Ticket> builder)
		{
			builder.ToTable
				("Tickets", "LE")
					.HasKey(current => current.Id);

			builder.Property
				(current => current.Message)
					.IsRequired();

			builder.Property
				(current => current.Method)
					.IsRequired();

			builder.Property
				(current => current.SentDate)
					.HasDefaultValueSql("getutcdate()")
					.HasColumnType("datetime")
					.IsRequired();

				
		}
	}
}
