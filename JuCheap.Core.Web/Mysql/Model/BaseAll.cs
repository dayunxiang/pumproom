using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.Model
{
    public class BaseAll
    {
        public int Id { get; set; }
        public DateTime 时间 { get; set; }

        public string 进口压力 { get; set; }
        public string 出口压力 { get; set; }
        public string 设定压力 { get; set; }

        public string 变频器1运行频率 { get; set; }
        public string 变频器2运行频率 { get; set; }
        public string 变频器3运行频率 { get; set; }
        public string 变频器4运行频率 { get; set; }

        public string 变频器1运行电流 { get; set; }
        public string 变频器2运行电流 { get; set; }
        public string 变频器3运行电流 { get; set; }
        public string 变频器4运行电流 { get; set; }

        public string 变频器1运行电压 { get; set; }
        public string 变频器2运行电压 { get; set; }
        public string 变频器3运行电压 { get; set; }
        public string 变频器4运行电压 { get; set; }

        public string 变频器1运行温度 { get; set; }
        public string 变频器2运行温度 { get; set; }
        public string 变频器3运行温度 { get; set; }
        public string 变频器4运行温度 { get; set; }

        public string 泵1运行电流 { get; set; }
        public string 泵2运行电流 { get; set; }
        public string 泵3运行电流 { get; set; }
        public string 泵4运行电流 { get; set; }
        public string 泵5运行电流 { get; set; }
        public string 泵6运行电流 { get; set; }
        public string 小泵1运行电流 { get; set; }
        public string 小泵2运行电流 { get; set; }

        public string 系统总电压 { get; set; }
        public string 系统总电流 { get; set; }
        public string 总电能 { get; set; }

        public string A相电压 { get; set; }
        public string B相电压 { get; set; }
        public string C相电压 { get; set; }

        public string A相电流 { get; set; }
        public string B相电流 { get; set; }
        public string C相电流 { get; set; }

        public string 压力传感器量程 { get; set; }
        public string 水箱液位高度 { get; set; }
        public string 瞬时流量 { get; set; }
        public string 正向累计流量 { get; set; }
        public string 反向累计流量 { get; set; }
        public string 泵房温度 { get; set; }
        public string 泵房湿度 { get; set; }
        public string 浊度 { get; set; }
        public string 余氯 { get; set; }
        public string PH值 { get; set; }
        public string COD { get; set; }

        public string 泵1运行状态 { get; set; }
        public string 泵2运行状态 { get; set; }
        public string 泵3运行状态 { get; set; }
        public string 泵4运行状态 { get; set; }
        public string 泵5运行状态 { get; set; }
        public string 泵6运行状态 { get; set; }
        public string 小泵1运行状态 { get; set; }
        public string 小泵2运行状态 { get; set; }

        public string 泵1手自动状态 { get; set; }
        public string 泵2手自动状态 { get; set; }
        public string 泵3手自动状态 { get; set; }
        public string 泵4手自动状态 { get; set; }
        public string 泵5手自动状态 { get; set; }
        public string 泵6手自动状态 { get; set; }
        public string 小泵1手自动状态 { get; set; }
        public string 小泵2手自动状态 { get; set; }

        public string 系统运行状态 { get; set; }
        public string PLC故障状态 { get; set; }
        public string 压力报警状态 { get; set; }
        public string 水箱缺水状态 { get; set; }

        public string 变频器1状态 { get; set; }
        public string 变频器2状态 { get; set; }
        public string 变频器3状态 { get; set; }
        public string 变频器4状态 { get; set; }

        public string 阀门开关状态 { get; set; }
        public string 阀门到位状态 { get; set; }
        public string 停机报警 { get; set; }
        public string 泵房进水报警状态 { get; set; }
        public string 停电来电报警状态 { get; set; }
        public string 门禁报警状态 { get; set; }
        public string 烟感报警状态 { get; set; }
        public string 污水泵启停状态 { get; set; }
        public string 故障复位操作 { get; set; }
        public string 上位机控制下位机系统 { get; set; }
        public string 控制参数修改确认键 { get; set; }
        public string 阀门开关控制 { get; set; }
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












    }

    

}
