using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.Model
{
    public class PressureData
    {
        public int Id
        {
            get;set;
        }
        public string Tablename
        {
            get;set;
        }
        public string 分区名称
        {
            get;set;
        }
        public string 站点名称
        {
            get;set;
        }
        public string 传感器
        {
            get;set;
        }
        public string 上传时间
        {
            get;set;
        }
        public string 压力
        {
            get;set;
        }
        public string 今日最高
        {
            get;set;
        }
        public string 时间1
        {
            get;set;
        }
        public string 今日最低
        {
            get;set;
        }
        public string 时间2
        {
            get;set;
        }
        public string 昨日最高
        {
            get;set;
        }
        public string 时间3
        {
            get;set;
        }
        public string 昨日最低
        {
            get;set;
        }
        public string 时间4
        {
            get;set;
        }
        public string 今日平均
        {
            get;set;
        }
        public string 昨日平均
        {
            get;set;
        }

    }
}
