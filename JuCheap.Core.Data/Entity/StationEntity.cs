using System;
using System.Collections.Generic;
using System.Text;

namespace JuCheap.Core.Data.Entity
{
    public class StationEntity:BaseEntity
    {
        public string 分区名称
        {
            get;set;
        }
        public string  分区类型
        {
            get;set;
        }
        public string 站点名称
        {
            get;set;
        }
        public string 站点编号
        {
            get;set;
        }
        public string 编号
        {
            get;set;
        }
        public string 站点全名
        {
            get;set;
        }
        public string 站点类型
        {
            get;set;
        }
        public int 分区内排序
        {
            get;set;
        }


    }
}
