using JuCheap.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuCheap.Core.Data.Configurations
{
    public class MarkerArrConfiguration : IEntityTypeConfiguration<MarkerArrEntity>
    {
        public void Configure(EntityTypeBuilder<MarkerArrEntity> builder)
        {
            builder.Property(e => e.id).IsRequired();
            builder.Property(e => e.title).HasMaxLength(50).IsRequired();
            builder.Property(e => e.elecname).HasMaxLength(50).IsRequired();
            builder.Property(e => e.electricity).HasMaxLength(50).IsRequired();
            builder.Property(e => e.watername).HasMaxLength(50).IsRequired();
            builder.Property(e => e.water).HasMaxLength(50).IsRequired();
            builder.Property(e => e.airname).HasMaxLength(50).IsRequired();
            builder.Property(e => e.air).HasMaxLength(50).IsRequired();
            builder.Property(e => e.alarmname).HasMaxLength(50).IsRequired();
            builder.Property(e => e.alarm).HasMaxLength(50).IsRequired();
            builder.Property(e => e.point).HasMaxLength(50).IsRequired();
            builder.Property(e => e.isOnline).IsRequired();
            builder.ToTable("MarkerArrs");

        }
    }
}
