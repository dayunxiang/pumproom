using JuCheap.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuCheap.Core.Data.Configurations
{
    public class CameraPathConfiguration: IEntityTypeConfiguration<CameraPathEntity>
    {
        public void Configure( EntityTypeBuilder<CameraPathEntity> builder)
        {
            //设置id为主键
            builder.HasKey(e => e.Id);
            //设置主键的字符串最大长度是36并且从未产生过
            builder.Property(e => e.Id).HasMaxLength(36).ValueGeneratedNever();

            //设置必须的端口、IP、loginname、pwd
            builder.Property(e => e.Ip).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Port).HasMaxLength(10).IsRequired();
            builder.Property(e => e.LoginName).HasMaxLength(20).IsRequired();
            builder.Property(e => e.Pwd).HasMaxLength(20).IsRequired();

            builder.Property(e => e.PumpRoomId).HasMaxLength(36);
            builder.Property(e => e.info).HasMaxLength(30);
            //设置泵房的名称不为空。
            builder.Property(e => e.PumpRoomName).HasMaxLength(20).IsRequired();

            builder.ToTable("CameraPaths");



        }

    }
}
