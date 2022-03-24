﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
	internal class CompleteResultConfiguration : IEntityTypeConfiguration<CompleteResult>
	{
		public void Configure(EntityTypeBuilder<CompleteResult> builder)
		{
			builder.ToTable
				("CompleteResult", "LE")
					.HasKey(current => current.Id);
		}
	}
}
