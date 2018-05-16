using JuCheap.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuCheap.Core.Data.Configurations
{
    public class GisProConfiguration : IEntityTypeConfiguration<GisProEntity>
    {
        public void Configure(EntityTypeBuilder<GisProEntity> builder)
        {
            //设置id为主键
            builder.HasKey(e => e.Id);
            //设置主键的字符串最大长度是36并且从未产生过
            builder.Property(e => e.Id).HasMaxLength(36).ValueGeneratedNever();

            //设置必须填写的
            builder.Property(e => e.分区名称).HasMaxLength(50).IsRequired();
            builder.Property(e => e.站点名称).HasMaxLength(50).IsRequired();
            builder.Property(e => e.泵个数name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.泵个数).HasMaxLength(50).IsRequired();
            builder.Property(e => e.状态信息name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.状态信息).HasMaxLength(50).IsRequired();
            builder.Property(e => e.报警信息name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.报警信息).HasMaxLength(50).IsRequired();
            builder.Property(e => e.坐标).HasMaxLength(50).IsRequired();
            builder.Property(e => e.泵表编号).HasMaxLength(50).IsRequired();

            //不是必须填的
            builder.Property(e => e.备用1).HasMaxLength(50);
            builder.Property(e => e.备用2).HasMaxLength(50);
            builder.Property(e => e.备用3).HasMaxLength(50);
            builder.Property(e => e.备用4).HasMaxLength(50);

            builder.ToTable("GisPros");
            
        }
    }
}
