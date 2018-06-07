using JuCheap.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuCheap.Core.Data.Configurations
{
    public class CeshiConfiguration:IEntityTypeConfiguration<CeshiEntity>
    {
        public void Configure(EntityTypeBuilder<CeshiEntity> builder)
        {
            //设置id为主键
            builder.HasKey(e => e.Id);
            //设置主键的字符串最大长度是36并且从未产生过
            builder.Property(e => e.Id).HasMaxLength(36).ValueGeneratedNever();
            builder.ToTable("Ceshis");

        }
        }
}
