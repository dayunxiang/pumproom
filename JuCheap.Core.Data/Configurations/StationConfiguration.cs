using JuCheap.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuCheap.Core.Data.Configurations
{
    public class StationConfiguration : IEntityTypeConfiguration<StationEntity>
    {
        public void Configure(EntityTypeBuilder<StationEntity> builder)
        {
            builder.HasKey(e => e.Id);
            //设置主键的字符串最大长度是36并且从未产生过
            builder.Property(e => e.Id).HasMaxLength(36).ValueGeneratedNever();

            //设置不为空的
            builder.Property(e => e.分区名称).HasMaxLength(25).IsRequired();
            builder.Property(e => e.分区类型).HasMaxLength(20).IsRequired();
            builder.Property(e => e.站点名称).HasMaxLength(35).IsRequired();
            builder.Property(e => e.站点编号).HasMaxLength(20).IsRequired();
            builder.Property(e => e.站点类型).HasMaxLength(20).IsRequired();
            builder.Property(e => e.分区内排序).IsRequired();
            //可以为空的
            builder.Property(e => e.站点全名).HasMaxLength(35);
            builder.Property(e => e.编号).HasMaxLength(20);

            builder.ToTable("Stations");

        }
    }
}
