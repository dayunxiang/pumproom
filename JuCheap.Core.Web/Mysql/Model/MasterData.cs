using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.Model
{
    public class MasterData
    {
        public string 远程设定压力 { get; set; }
        public string 加泵频率 { get; set; }
        public string 减泵频率 { get; set; }
        public string 加泵时间 { get; set; }
        public string 减泵时间 { get; set; }
        public string 换泵时间 { get; set; }
        public string 睡眠频率 { get; set; }
        public string 睡眠延时 { get; set; }
        public string 唤醒值设定 { get; set; }
        public string 负压报警值设定 { get; set; }
        public string 负压停止延时 { get; set; }
        public string 超压警值设定 { get; set; }
        public string 超压停止延时 { get; set; }
        public string 泵1启停控制 { get; set; }
        public string 泵2启停控制 { get; set; }
        public string 泵3启停控制 { get; set; }
        public string 泵4启停控制 { get; set; }
        public string 泵5启停控制 { get; set; }
        public string 泵6启停控制 { get; set; }
        public string 小泵1启停控制 { get; set; }
        public string 小泵2启停控制 { get; set; }

        public string 进口压力低值设定 { get; set; }
        public string 进口压力恢复值设定 { get; set; }
        public string 出口压力目标值设定 { get; set; }
        public string 门禁开关状态 { get; set; }
    }
}
