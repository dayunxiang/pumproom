using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.Model
{
    public class CeShi1
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime 时间 { get; set; }

        public string 进口压力 { get; set; }
        public string 出口压力 { get; set; }
        public string 设定压力 { get; set; }

        public string 变频器1运行频率 { get; set; }
        public string 变频器2运行频率 { get; set; }
        public string 变频器3运行频率 { get; set; }
        public string 变频器4运行频率 { get; set; }
    }
}
