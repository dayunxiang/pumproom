using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.DAL
{
    public class RTData_DAL
    {
       public IEnumerable<RTData>  GetRTData()
        {
            int i = 1;
            List<RTData> list = new List<RTData>();
            DataTable dt = MySqlHelper.ExecuteDataTable("select 分区名称,站点名称,编号 from stations where IsDeleted ='0';");
            foreach(DataRow dr in dt.Rows)
            {
                RTData rt = new RTData();
                rt.Id = i;
                rt.分区名称 = dr["分区名称"].ToString();
                rt.站点名称 = dr["站点名称"].ToString();
                rt.Tablename = "pumproom"+dr["编号"].ToString();
                list.Add(rt);
                i++;
            }


            for(int k=0;k<list.Count;k++)
            {
                DataTable dt1 = MySqlHelper.ExecuteDataTable("select * from " + list[k].Tablename + " order by 时间 desc limit 1;");
               if(dt1.Rows.Count==0)
                {
                    list[k].上传时间 = "";
                    list[k].进口压力 = "";
                    list[k].出口压力 = "";
                    list[k].设定压力 = "";
                    list[k].变频器1运行频率 = "";
                    list[k].变频器2运行频率 = "";
                    list[k].变频器3运行频率 = "";
                    list[k].变频器4运行频率 = "";
                    list[k].变频器1运行电流 = "";
                    list[k].变频器2运行电流 = "";
                    list[k].变频器3运行电流 = "";
                    list[k].变频器4运行电流 = "";
                    list[k].变频器1运行电压 = "";
                    list[k].变频器2运行电压 = "";
                    list[k].变频器3运行电压 = "";
                    list[k].变频器4运行电压 = "";
                    list[k].变频器1运行温度 = "";
                    list[k].变频器2运行温度 = "";
                    list[k].变频器3运行温度 = "";
                    list[k].变频器4运行温度 = "";
                    list[k].泵1运行电流 = "";
                    list[k].泵2运行电流 = "";
                    list[k].泵3运行电流 = "";
                    list[k].泵4运行电流 = "";
                    list[k].泵5运行电流 = "";
                    list[k].泵6运行电流 = "";
                    list[k].小泵1运行电流 = "";
                    list[k].小泵2运行电流 = "";
                    list[k].系统总电压 = "";
                    list[k].系统总电流 = "";
                    list[k].总电能 = "";
                    list[k].A相电压 = "";
                    list[k].B相电压 = "";
                    list[k].C相电压 = "";
                    list[k].A相电流 = "";
                    list[k].B相电流 = "";
                    list[k].C相电流 = "";
                    list[k].压力传感器量程 = "";
                    list[k].水箱液位高度 = "";
                    list[k].瞬时流量 = "";
                    list[k].正向累计流量 = "";
                    list[k].反向累计流量 = "";
                    list[k].泵房温度 = "";
                    list[k].泵房湿度 = "";
                    list[k].浊度 = "";
                    list[k].余氯 = "";
                    list[k].PH值 = "";
                    list[k].COD = "";
                    list[k].泵1运行状态 = "";
                    list[k].泵2运行状态 = "";
                    list[k].泵3运行状态 = "";
                    list[k].泵4运行状态 = "";
                    list[k].泵5运行状态 = "";
                    list[k].泵6运行状态 = "";
                    list[k].小泵1运行状态 = "";
                    list[k].小泵2运行状态 = "";
                    list[k].泵1手自动状态 = "";
                    list[k].泵2手自动状态 = "";
                    list[k].泵3手自动状态 = "";
                    list[k].泵4手自动状态 = "";
                    list[k].泵5手自动状态 = "";
                    list[k].泵6手自动状态 = "";
                    list[k].小泵1手自动状态 = "";
                    list[k].小泵2手自动状态 = "";
                    list[k].系统运行状态 = "";
                    list[k].PLC故障状态 = "";
                    list[k].压力报警状态 = "";
                    list[k].水箱缺水状态 = "";
                    list[k].变频器1状态 = "";
                    list[k].变频器2状态 = "";
                    list[k].变频器3状态 = "";
                    list[k].变频器4状态 = "";
                    list[k].阀门开关状态 = "";
                    list[k].阀门到位状态 = "";
                    list[k].停机报警 = "";
                    list[k].泵房进水报警状态 = "";
                    list[k].停电来电报警状态 = "";
                    list[k].门禁报警状态 = "";
                    list[k].烟感报警状态 = "";
                    list[k].污水泵启停状态 = "";
                    list[k].故障复位操作 = "";
                    list[k].上位机控制下位机系统 = "";
                    list[k].控制参数修改确认键 = "";
                    list[k].阀门开关控制 = "";
                    list[k].远程设定压力 = "";
                    list[k].加泵频率 = "";
                    list[k].减泵频率 = "";
                    list[k].加泵时间 = "";
                    list[k].减泵时间 = "";
                    list[k].换泵时间 = "";
                    list[k].睡眠频率 = "";
                    list[k].睡眠延时 = "";
                    list[k].唤醒值设定 = "";
                    list[k].负压报警值设定 = "";
                    list[k].负压停止延时 = "";
                    list[k].超压警值设定 = "";
                    list[k].超压停止延时 = "";
                    list[k].泵1启停控制 = "";
                    list[k].泵2启停控制 = "";
                    list[k].泵3启停控制 = "";
                    list[k].泵4启停控制 = "";
                    list[k].泵5启停控制 = "";
                    list[k].泵6启停控制 = "";
                    list[k].小泵1启停控制 = "";
                    list[k].小泵2启停控制 = "";
                }
                else
                {
                    list[k].上传时间 = dt1.Rows[0]["时间"].ToString();
                    list[k].进口压力 = dt1.Rows[0]["进口压力"].ToString();
                    list[k].出口压力 = dt1.Rows[0]["出口压力"].ToString();
                    list[k].设定压力 = dt1.Rows[0]["设定压力"].ToString();
                    list[k].变频器1运行频率 = dt1.Rows[0]["1变频器运行频率"].ToString();
                    list[k].变频器2运行频率 = dt1.Rows[0]["2变频器运行频率"].ToString();
                    list[k].变频器3运行频率 = dt1.Rows[0]["3变频器运行频率"].ToString();
                    list[k].变频器4运行频率 = dt1.Rows[0]["4变频器运行频率"].ToString();
                    list[k].变频器1运行电流 = dt1.Rows[0]["1变频器运行频率"].ToString();
                    list[k].变频器2运行电流 = dt1.Rows[0]["2变频器运行电流"].ToString();
                    list[k].变频器3运行电流 = dt1.Rows[0]["3变频器运行电流"].ToString();
                    list[k].变频器4运行电流 = dt1.Rows[0]["4变频器运行电流"].ToString();
                    list[k].变频器1运行电压 = dt1.Rows[0]["1变频器运行电压"].ToString();
                    list[k].变频器2运行电压 = dt1.Rows[0]["2变频器运行电压"].ToString();
                    list[k].变频器3运行电压 = dt1.Rows[0]["3变频器运行电压"].ToString();
                    list[k].变频器4运行电压 = dt1.Rows[0]["4变频器运行电压"].ToString();
                    list[k].变频器1运行温度 = dt1.Rows[0]["1变频器运行温度"].ToString();
                    list[k].变频器2运行温度 = dt1.Rows[0]["2变频器运行温度"].ToString();
                    list[k].变频器3运行温度 = dt1.Rows[0]["3变频器运行温度"].ToString();
                    list[k].变频器4运行温度 = dt1.Rows[0]["4变频器运行温度"].ToString();
                    list[k].泵1运行电流 = dt1.Rows[0]["1泵运行电流"].ToString();
                    list[k].泵2运行电流 = dt1.Rows[0]["2泵运行电流"].ToString();
                    list[k].泵3运行电流 = dt1.Rows[0]["3泵运行电流"].ToString();
                    list[k].泵4运行电流 = dt1.Rows[0]["4泵运行电流"].ToString();
                    list[k].泵5运行电流 = dt1.Rows[0]["5泵运行电流"].ToString();
                    list[k].泵6运行电流 = dt1.Rows[0]["6泵运行电流"].ToString();
                    list[k].小泵1运行电流 = dt1.Rows[0]["1小泵运行电流"].ToString();
                    list[k].小泵2运行电流 = dt1.Rows[0]["2小泵运行电流"].ToString();
                    list[k].系统总电压 = dt1.Rows[0]["系统总电压"].ToString();
                    list[k].系统总电流 = dt1.Rows[0]["系统总电流"].ToString();
                    list[k].总电能 = dt1.Rows[0]["总电能"].ToString();
                    list[k].A相电压 = dt1.Rows[0]["A相电压"].ToString();
                    list[k].B相电压 = dt1.Rows[0]["B相电压"].ToString();
                    list[k].C相电压 = dt1.Rows[0]["C相电压"].ToString();
                    list[k].A相电流 = dt1.Rows[0]["A相电流"].ToString();
                    list[k].B相电流 = dt1.Rows[0]["B相电流"].ToString();
                    list[k].C相电流 = dt1.Rows[0]["C相电流"].ToString();
                    list[k].压力传感器量程 = dt1.Rows[0]["压力传感器量程"].ToString();
                    list[k].水箱液位高度 = dt1.Rows[0]["水箱液位高度"].ToString();
                    list[k].瞬时流量 = dt1.Rows[0]["瞬时流量"].ToString();
                    list[k].正向累计流量 = dt1.Rows[0]["正向累计流量"].ToString();
                    list[k].反向累计流量 = dt1.Rows[0]["反向累计流量"].ToString();
                    list[k].泵房温度 = dt1.Rows[0]["泵房温度"].ToString();
                    list[k].泵房湿度 = dt1.Rows[0]["泵房湿度"].ToString();
                    list[k].浊度 = dt1.Rows[0]["浊度"].ToString();
                    list[k].余氯 = dt1.Rows[0]["余氯"].ToString();
                    list[k].PH值 = dt1.Rows[0]["PH值"].ToString();
                    list[k].COD = dt1.Rows[0]["COD"].ToString();
                    list[k].泵1运行状态 = dt1.Rows[0]["1泵运行状态"].ToString();
                    list[k].泵2运行状态 = dt1.Rows[0]["2泵运行状态"].ToString();
                    list[k].泵3运行状态 = dt1.Rows[0]["3泵运行状态"].ToString();
                    list[k].泵4运行状态 = dt1.Rows[0]["4泵运行状态"].ToString();
                    list[k].泵5运行状态 = dt1.Rows[0]["5泵运行状态"].ToString();
                    list[k].泵6运行状态 = dt1.Rows[0]["6泵运行状态"].ToString();
                    list[k].小泵1运行状态 = dt1.Rows[0]["1小泵运行状态"].ToString();
                    list[k].小泵2运行状态 = dt1.Rows[0]["2小泵运行状态"].ToString();
                    list[k].泵1手自动状态 = dt1.Rows[0]["1泵手自动状态"].ToString();
                    list[k].泵2手自动状态 = dt1.Rows[0]["2泵手自动状态"].ToString();
                    list[k].泵3手自动状态 = dt1.Rows[0]["3泵手自动状态"].ToString();
                    list[k].泵4手自动状态 = dt1.Rows[0]["4泵手自动状态"].ToString();
                    list[k].泵5手自动状态 = dt1.Rows[0]["5泵手自动状态"].ToString();
                    list[k].泵6手自动状态 = dt1.Rows[0]["6泵手自动状态"].ToString();
                    list[k].小泵1手自动状态 = dt1.Rows[0]["1小泵手自动状态"].ToString();
                    list[k].小泵2手自动状态 = dt1.Rows[0]["2小泵手自动状态"].ToString();
                    list[k].系统运行状态 = dt1.Rows[0]["系统运行状态"].ToString();
                    list[k].PLC故障状态 = dt1.Rows[0]["PLC故障状态"].ToString();
                    list[k].压力报警状态 = dt1.Rows[0]["压力报警状态"].ToString();
                    list[k].水箱缺水状态 = dt1.Rows[0]["水箱缺水状态"].ToString();
                    list[k].变频器1状态 = dt1.Rows[0]["1变频器状态"].ToString();
                    list[k].变频器2状态 = dt1.Rows[0]["2变频器状态"].ToString();
                    list[k].变频器3状态 = dt1.Rows[0]["3变频器状态"].ToString();
                    list[k].变频器4状态 = dt1.Rows[0]["4变频器状态"].ToString();
                    list[k].阀门开关状态 = dt1.Rows[0]["阀门开关状态"].ToString();
                    list[k].阀门到位状态 = dt1.Rows[0]["阀门到位状态"].ToString();
                    list[k].停机报警 = dt1.Rows[0]["停机报警"].ToString();
                    list[k].泵房进水报警状态 = dt1.Rows[0]["泵房进水报警状态"].ToString();
                    list[k].停电来电报警状态 = dt1.Rows[0]["停电来电报警状态"].ToString();
                    list[k].门禁报警状态 = dt1.Rows[0]["门禁报警状态"].ToString();
                    list[k].烟感报警状态 = dt1.Rows[0]["烟感报警状态"].ToString();
                    list[k].污水泵启停状态 = dt1.Rows[0]["污水泵启停状态"].ToString();
                    list[k].故障复位操作 = dt1.Rows[0]["故障复位操作"].ToString();
                    list[k].上位机控制下位机系统 = dt1.Rows[0]["上位机控制下位机系统"].ToString();
                    list[k].控制参数修改确认键 = dt1.Rows[0]["控制参数修改确认键"].ToString();
                    list[k].阀门开关控制 = dt1.Rows[0]["阀门开关控制"].ToString();
                    list[k].远程设定压力 = dt1.Rows[0]["远程设定压力"].ToString();
                    list[k].加泵频率 = dt1.Rows[0]["加泵频率"].ToString();
                    list[k].减泵频率 = dt1.Rows[0]["减泵频率"].ToString();
                    list[k].加泵时间 = dt1.Rows[0]["加泵时间"].ToString();
                    list[k].减泵时间 = dt1.Rows[0]["减泵时间"].ToString();
                    list[k].换泵时间 = dt1.Rows[0]["换泵时间"].ToString();
                    list[k].睡眠频率 = dt1.Rows[0]["睡眠频率"].ToString();
                    list[k].睡眠延时 = dt1.Rows[0]["睡眠延时"].ToString();
                    list[k].唤醒值设定 = dt1.Rows[0]["唤醒值设定"].ToString();
                    list[k].负压报警值设定 = dt1.Rows[0]["负压报警值设定"].ToString();
                    list[k].负压停止延时 = dt1.Rows[0]["负压停止延时"].ToString();
                    list[k].超压警值设定 = dt1.Rows[0]["超压警值设定"].ToString();
                    list[k].超压停止延时 = dt1.Rows[0]["超压停止延时"].ToString();
                    list[k].泵1启停控制 = dt1.Rows[0]["1泵启停控制"].ToString();
                    list[k].泵2启停控制 = dt1.Rows[0]["2泵启停控制"].ToString();
                    list[k].泵3启停控制 = dt1.Rows[0]["3泵启停控制"].ToString();
                    list[k].泵4启停控制 = dt1.Rows[0]["4泵启停控制"].ToString();
                    list[k].泵5启停控制 = dt1.Rows[0]["5泵启停控制"].ToString();
                    list[k].泵6启停控制 = dt1.Rows[0]["6泵启停控制"].ToString();
                    list[k].小泵1启停控制 = dt1.Rows[0]["1小泵启停控制"].ToString();
                    list[k].小泵2启停控制 = dt1.Rows[0]["2小泵启停控制"].ToString();
                }
            }

            return list;
        }
    }
}
