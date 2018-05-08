using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.DAL
{
    /// <summary>
    /// 获取所有的原始数据
    /// </summary>
    public class BaseAll_DAL
    {


        
        public IEnumerable<BaseAll> GetAll(string s)
        {
            //DataTable dt = MySqlHelper.ExecuteDataTable("select * from " + s + " ;");
            DataTable dt = MySqlHelper.ExecuteDataTable("select * from "+s+" order by 时间 desc limit 10;");
            
            List<BaseAll> list = new List<BaseAll>();
            foreach(DataRow dr in dt.Rows)
            {
                BaseAll p = new BaseAll();
                p.Id = Convert.ToInt32(dr["Id"]);
                p.时间 = (DateTime)dr["时间"];
                p.进口压力 = dr["进口压力"].ToString();
                p.出口压力 = dr["出口压力"].ToString();
                p.设定压力= dr["设定压力"].ToString();
                p.变频器1运行频率 = dr["1变频器运行频率"].ToString();
                p.变频器2运行频率 = dr["2变频器运行频率"].ToString();
                p.变频器3运行频率 = dr["3变频器运行频率"].ToString();
                p.变频器4运行频率 = dr["4变频器运行频率"].ToString();
                p.变频器1运行电流 = dr["1变频器运行频率"].ToString();
                p.变频器2运行电流 = dr["2变频器运行电流"].ToString();
                p.变频器3运行电流 = dr["3变频器运行电流"].ToString();
                p.变频器4运行电流 = dr["4变频器运行电流"].ToString();
                p.变频器1运行电压 = dr["1变频器运行电压"].ToString();
                p.变频器2运行电压 = dr["2变频器运行电压"].ToString();
                p.变频器3运行电压 = dr["3变频器运行电压"].ToString();
                p.变频器4运行电压 = dr["4变频器运行电压"].ToString();
                p.变频器1运行温度 = dr["1变频器运行温度"].ToString();
                p.变频器2运行温度 = dr["2变频器运行温度"].ToString();
                p.变频器3运行温度 = dr["3变频器运行温度"].ToString();
                p.变频器4运行温度 = dr["4变频器运行温度"].ToString();
                p.泵1运行电流 = dr["1泵运行电流"].ToString();
                p.泵2运行电流 = dr["2泵运行电流"].ToString();
                p.泵3运行电流 = dr["3泵运行电流"].ToString();
                p.泵4运行电流 = dr["4泵运行电流"].ToString();
                p.泵5运行电流 = dr["5泵运行电流"].ToString();
                p.泵6运行电流 = dr["6泵运行电流"].ToString();
                p.小泵1运行电流 = dr["1小泵运行电流"].ToString();
                p.小泵2运行电流= dr["1小泵运行电流"].ToString();
                p.系统总电压 = dr["系统总电压"].ToString();
                p.系统总电流 = dr["系统总电流"].ToString();
                p.总电能 = dr["总电能"].ToString();
                p.A相电压 = dr["A相电压"].ToString();
                p.B相电压 = dr["B相电压"].ToString();
                p.C相电压 = dr["C相电压"].ToString();
                p.A相电流= dr["A相电流"].ToString();
                p.B相电流 = dr["B相电流"].ToString();
                p.C相电流= dr["C相电流"].ToString();
                p.压力传感器量程 = dr["压力传感器量程"].ToString();
                p.水箱液位高度 = dr["水箱液位高度"].ToString();
                p.瞬时流量 = dr["瞬时流量"].ToString();
                p.正向累计流量 = dr["正向累计流量"].ToString();
                p.反向累计流量 = dr["反向累计流量"].ToString();
                p.泵房温度 = dr["泵房温度"].ToString();
                p.泵房湿度 = dr["泵房湿度"].ToString();
                p.浊度 = dr["浊度"].ToString();
                p.余氯 = dr["余氯"].ToString();
                p.PH值 = dr["PH值"].ToString();
                p.COD = dr["COD"].ToString();
                p.泵1运行状态 = dr["1泵运行状态"].ToString();
                p.泵2运行状态 = dr["2泵运行状态"].ToString();
                p.泵3运行状态 = dr["3泵运行状态"].ToString();
                p.泵4运行状态 = dr["4泵运行状态"].ToString();
                p.泵5运行状态 = dr["5泵运行状态"].ToString();
                p.泵6运行状态 = dr["6泵运行状态"].ToString();
                p.小泵1运行状态 = dr["1小泵运行状态"].ToString();
                p.小泵2运行状态 = dr["2小泵运行状态"].ToString();
                p.泵1手自动状态 = dr["1泵手自动状态"].ToString();
                p.泵2手自动状态 = dr["2泵手自动状态"].ToString();
                p.泵3手自动状态 = dr["3泵手自动状态"].ToString();
                p.泵4手自动状态 = dr["4泵手自动状态"].ToString();
                p.泵5手自动状态 = dr["5泵手自动状态"].ToString();
                p.泵6手自动状态 = dr["6泵手自动状态"].ToString();
                p.小泵1手自动状态 = dr["1小泵手自动状态"].ToString();
                p.小泵2手自动状态 = dr["2小泵手自动状态"].ToString();
                p.系统运行状态 = dr["系统运行状态"].ToString();
                p.PLC故障状态 = dr["PLC故障状态"].ToString();
                p.压力报警状态 = dr["压力报警状态"].ToString();
                p.水箱缺水状态 = dr["水箱缺水状态"].ToString();
                p.变频器1状态 = dr["1变频器状态"].ToString();
                p.变频器2状态 = dr["2变频器状态"].ToString();
                p.变频器3状态 = dr["3变频器状态"].ToString();
                p.变频器4状态 = dr["4变频器状态"].ToString();
                p.阀门开关状态 = dr["阀门开关状态"].ToString();
                p.阀门到位状态 = dr["阀门到位状态"].ToString();
                p.停机报警 = dr["停机报警"].ToString();
                p.泵房进水报警状态 = dr["泵房进水报警状态"].ToString();
                p.门禁报警状态 = dr["门禁报警状态"].ToString();
                p.烟感报警状态 = dr["烟感报警状态"].ToString();
                p.污水泵启停状态 = dr["污水泵启停状态"].ToString();
                p.故障复位操作 = dr["故障复位操作"].ToString();
                p.上位机控制下位机系统 = dr["上位机控制下位机系统"].ToString();
                p.控制参数修改确认键 = dr["控制参数修改确认键"].ToString();
                p.阀门开关控制 = dr["阀门开关控制"].ToString();
                p.远程设定压力 = dr["远程设定压力"].ToString();
                p.加泵频率 = dr["加泵频率"].ToString();
                p.减泵频率 = dr["减泵频率"].ToString();
                p.加泵时间 = dr["加泵时间"].ToString();
                p.减泵时间 = dr["减泵时间"].ToString();
                p.换泵时间 = dr["换泵时间"].ToString();
                p.睡眠频率 = dr["睡眠频率"].ToString();
                p.睡眠延时 = dr["睡眠延时"].ToString();
                p.唤醒值设定 = dr["唤醒值设定"].ToString();
                p.负压报警值设定 = dr["负压报警值设定"].ToString();
                p.负压停止延时 = dr["负压停止延时"].ToString();
                p.超压警值设定 = dr["超压警值设定"].ToString();
                p.超压停止延时 = dr["超压停止延时"].ToString();
                p.泵1启停控制 = dr["1泵启停控制"].ToString();
                p.泵2启停控制 = dr["2泵启停控制"].ToString();
                p.泵3启停控制 = dr["3泵启停控制"].ToString();
                p.泵4启停控制 = dr["4泵启停控制"].ToString();
                p.泵5启停控制 = dr["5泵启停控制"].ToString();
                p.泵6启停控制 = dr["6泵启停控制"].ToString();
                p.小泵1启停控制 = dr["1小泵启停控制"].ToString();
                p.小泵2启停控制 = dr["2小泵启停控制"].ToString();

                list.Add(p);


            }
            return list;
           
        }

        public IEnumerable<BaseAll1> GetDiffer()
        {
            List<string> names = (List<string>)new ReadPumpRoom_DAL().ReadPumpRoom();
            List<BaseAll1> ls = new List<BaseAll1>();
            foreach (string s in names)
            {
                DataTable dt = MySqlHelper.ExecuteDataTable("select * from " + s + " order by 时间 desc limit 1 ;");
                BaseAll1 p = new BaseAll1();

                p.Name = GetName(s.Substring(8));
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];

                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.时间 = (DateTime)dr["时间"];
                    p.进口压力 = dr["进口压力"].ToString();
                    p.出口压力 = dr["出口压力"].ToString();
                    p.设定压力 = dr["设定压力"].ToString();
                    p.变频器1运行频率 = dr["1变频器运行频率"].ToString();
                    p.变频器2运行频率 = dr["2变频器运行频率"].ToString();
                    p.变频器3运行频率 = dr["3变频器运行频率"].ToString();
                    p.变频器4运行频率 = dr["4变频器运行频率"].ToString();
                    p.变频器1运行电流 = dr["1变频器运行频率"].ToString();
                    p.变频器2运行电流 = dr["2变频器运行电流"].ToString();
                    p.变频器3运行电流 = dr["3变频器运行电流"].ToString();
                    p.变频器4运行电流 = dr["4变频器运行电流"].ToString();
                    p.变频器1运行电压 = dr["1变频器运行电压"].ToString();
                    p.变频器2运行电压 = dr["2变频器运行电压"].ToString();
                    p.变频器3运行电压 = dr["3变频器运行电压"].ToString();
                    p.变频器4运行电压 = dr["4变频器运行电压"].ToString();
                    p.变频器1运行温度 = dr["1变频器运行温度"].ToString();
                    p.变频器2运行温度 = dr["2变频器运行温度"].ToString();
                    p.变频器3运行温度 = dr["3变频器运行温度"].ToString();
                    p.变频器4运行温度 = dr["4变频器运行温度"].ToString();
                    p.泵1运行电流 = dr["1泵运行电流"].ToString();
                    p.泵2运行电流 = dr["2泵运行电流"].ToString();
                    p.泵3运行电流 = dr["3泵运行电流"].ToString();
                    p.泵4运行电流 = dr["4泵运行电流"].ToString();
                    p.泵5运行电流 = dr["5泵运行电流"].ToString();
                    p.泵6运行电流 = dr["6泵运行电流"].ToString();
                    p.小泵1运行电流 = dr["1小泵运行电流"].ToString();
                    p.小泵2运行电流 = dr["1小泵运行电流"].ToString();
                    p.系统总电压 = dr["系统总电压"].ToString();
                    p.系统总电流 = dr["系统总电流"].ToString();
                    p.总电能 = dr["总电能"].ToString();
                    p.A相电压 = dr["A相电压"].ToString();
                    p.B相电压 = dr["B相电压"].ToString();
                    p.C相电压 = dr["C相电压"].ToString();
                    p.A相电流 = dr["A相电流"].ToString();
                    p.B相电流 = dr["B相电流"].ToString();
                    p.C相电流 = dr["C相电流"].ToString();
                    p.压力传感器量程 = dr["压力传感器量程"].ToString();
                    p.水箱液位高度 = dr["水箱液位高度"].ToString();
                    p.瞬时流量 = dr["瞬时流量"].ToString();
                    p.正向累计流量 = dr["正向累计流量"].ToString();
                    p.反向累计流量 = dr["反向累计流量"].ToString();
                    p.泵房温度 = dr["泵房温度"].ToString();
                    p.泵房湿度 = dr["泵房湿度"].ToString();
                    p.浊度 = dr["浊度"].ToString();
                    p.余氯 = dr["余氯"].ToString();
                    p.PH值 = dr["PH值"].ToString();
                    p.COD = dr["COD"].ToString();
                    p.泵1运行状态 = dr["1泵运行状态"].ToString();
                    p.泵2运行状态 = dr["2泵运行状态"].ToString();
                    p.泵3运行状态 = dr["3泵运行状态"].ToString();
                    p.泵4运行状态 = dr["4泵运行状态"].ToString();
                    p.泵5运行状态 = dr["5泵运行状态"].ToString();
                    p.泵6运行状态 = dr["6泵运行状态"].ToString();
                    p.小泵1运行状态 = dr["1小泵运行状态"].ToString();
                    p.小泵2运行状态 = dr["2小泵运行状态"].ToString();
                    p.泵1手自动状态 = dr["1泵手自动状态"].ToString();
                    p.泵2手自动状态 = dr["2泵手自动状态"].ToString();
                    p.泵3手自动状态 = dr["3泵手自动状态"].ToString();
                    p.泵4手自动状态 = dr["4泵手自动状态"].ToString();
                    p.泵5手自动状态 = dr["5泵手自动状态"].ToString();
                    p.泵6手自动状态 = dr["6泵手自动状态"].ToString();
                    p.小泵1手自动状态 = dr["1小泵手自动状态"].ToString();
                    p.小泵2手自动状态 = dr["2小泵手自动状态"].ToString();
                    p.系统运行状态 = dr["系统运行状态"].ToString();
                    p.PLC故障状态 = dr["PLC故障状态"].ToString();
                    p.压力报警状态 = dr["压力报警状态"].ToString();
                    p.水箱缺水状态 = dr["水箱缺水状态"].ToString();
                    p.变频器1状态 = dr["1变频器状态"].ToString();
                    p.变频器2状态 = dr["2变频器状态"].ToString();
                    p.变频器3状态 = dr["3变频器状态"].ToString();
                    p.变频器4状态 = dr["4变频器状态"].ToString();
                    p.阀门开关状态 = dr["阀门开关状态"].ToString();
                    p.阀门到位状态 = dr["阀门到位状态"].ToString();
                    p.停机报警 = dr["停机报警"].ToString();
                    p.泵房进水报警状态 = dr["泵房进水报警状态"].ToString();
                    p.门禁报警状态 = dr["门禁报警状态"].ToString();
                    p.烟感报警状态 = dr["烟感报警状态"].ToString();
                    p.污水泵启停状态 = dr["污水泵启停状态"].ToString();
                    p.故障复位操作 = dr["故障复位操作"].ToString();
                    p.上位机控制下位机系统 = dr["上位机控制下位机系统"].ToString();
                    p.控制参数修改确认键 = dr["控制参数修改确认键"].ToString();
                    p.阀门开关控制 = dr["阀门开关控制"].ToString();
                    p.远程设定压力 = dr["远程设定压力"].ToString();
                    p.加泵频率 = dr["加泵频率"].ToString();
                    p.减泵频率 = dr["减泵频率"].ToString();
                    p.加泵时间 = dr["加泵时间"].ToString();
                    p.减泵时间 = dr["减泵时间"].ToString();
                    p.换泵时间 = dr["换泵时间"].ToString();
                    p.睡眠频率 = dr["睡眠频率"].ToString();
                    p.睡眠延时 = dr["睡眠延时"].ToString();
                    p.唤醒值设定 = dr["唤醒值设定"].ToString();
                    p.负压报警值设定 = dr["负压报警值设定"].ToString();
                    p.负压停止延时 = dr["负压停止延时"].ToString();
                    p.超压警值设定 = dr["超压警值设定"].ToString();
                    p.超压停止延时 = dr["超压停止延时"].ToString();
                    p.泵1启停控制 = dr["1泵启停控制"].ToString();
                    p.泵2启停控制 = dr["2泵启停控制"].ToString();
                    p.泵3启停控制 = dr["3泵启停控制"].ToString();
                    p.泵4启停控制 = dr["4泵启停控制"].ToString();
                    p.泵5启停控制 = dr["5泵启停控制"].ToString();
                    p.泵6启停控制 = dr["6泵启停控制"].ToString();
                    p.小泵1启停控制 = dr["1小泵启停控制"].ToString();
                    p.小泵2启停控制 = dr["2小泵启停控制"].ToString();


                }
                ls.Add(p);

            }
            return ls;
        }
        
        public string GetName(string s)
        {
            DataTable dt = MySqlHelper.ExecuteDataTable("select 站点名称 from stations where 编号 = " + s + " ;");
            string result = "";
            if(dt.Rows.Count>0)
            {
                DataRow dr = dt.Rows[0];
                result = dr["站点名称"].ToString();
                
            }
            return result;


        }
        /// <summary>
        /// 通过站点名称获取编号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string GetNumberByName(string s )
        {
            DataTable dt = MySqlHelper.ExecuteDataTable("select 编号 from stations where 站点名称 = '" + s + "' ;");
            string result = "";
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                result = dr["编号"].ToString();

            }
            return result;

        }

        public BaseAll GetByName(string s )
        {
            DataTable dt1 = MySqlHelper.ExecuteDataTable("select 编号 from stations where  站点名称 ='" + s + "' and IsDeleted = false;");
            DataRow dr1 = dt1.Rows[0];
            string name = "pumproom" + dr1["编号"].ToString();
            DataTable dt = MySqlHelper.ExecuteDataTable("select * from " + name + " order by 时间 desc limit 1;");
            BaseAll p = new BaseAll();
            DataRow dr = dt.Rows[0];
            p.Id = Convert.ToInt32(dr["Id"]);
            p.时间 = (DateTime)dr["时间"];
            p.进口压力 = dr["进口压力"].ToString();
            p.出口压力 = dr["出口压力"].ToString();
            p.设定压力 = dr["设定压力"].ToString();
            p.变频器1运行频率 = dr["1变频器运行频率"].ToString();
            p.变频器2运行频率 = dr["2变频器运行频率"].ToString();
            p.变频器3运行频率 = dr["3变频器运行频率"].ToString();
            p.变频器4运行频率 = dr["4变频器运行频率"].ToString();
            p.变频器1运行电流 = dr["1变频器运行频率"].ToString();
            p.变频器2运行电流 = dr["2变频器运行电流"].ToString();
            p.变频器3运行电流 = dr["3变频器运行电流"].ToString();
            p.变频器4运行电流 = dr["4变频器运行电流"].ToString();
            p.变频器1运行电压 = dr["1变频器运行电压"].ToString();
            p.变频器2运行电压 = dr["2变频器运行电压"].ToString();
            p.变频器3运行电压 = dr["3变频器运行电压"].ToString();
            p.变频器4运行电压 = dr["4变频器运行电压"].ToString();
            p.变频器1运行温度 = dr["1变频器运行温度"].ToString();
            p.变频器2运行温度 = dr["2变频器运行温度"].ToString();
            p.变频器3运行温度 = dr["3变频器运行温度"].ToString();
            p.变频器4运行温度 = dr["4变频器运行温度"].ToString();
            p.泵1运行电流 = dr["1泵运行电流"].ToString();
            p.泵2运行电流 = dr["2泵运行电流"].ToString();
            p.泵3运行电流 = dr["3泵运行电流"].ToString();
            p.泵4运行电流 = dr["4泵运行电流"].ToString();
            p.泵5运行电流 = dr["5泵运行电流"].ToString();
            p.泵6运行电流 = dr["6泵运行电流"].ToString();
            p.小泵1运行电流 = dr["1小泵运行电流"].ToString();
            p.小泵2运行电流 = dr["1小泵运行电流"].ToString();
            p.系统总电压 = dr["系统总电压"].ToString();
            p.系统总电流 = dr["系统总电流"].ToString();
            p.总电能 = dr["总电能"].ToString();
            p.A相电压 = dr["A相电压"].ToString();
            p.B相电压 = dr["B相电压"].ToString();
            p.C相电压 = dr["C相电压"].ToString();
            p.A相电流 = dr["A相电流"].ToString();
            p.B相电流 = dr["B相电流"].ToString();
            p.C相电流 = dr["C相电流"].ToString();
            p.压力传感器量程 = dr["压力传感器量程"].ToString();
            p.水箱液位高度 = dr["水箱液位高度"].ToString();
            p.瞬时流量 = dr["瞬时流量"].ToString();
            p.正向累计流量 = dr["正向累计流量"].ToString();
            p.反向累计流量 = dr["反向累计流量"].ToString();
            p.泵房温度 = dr["泵房温度"].ToString();
            p.泵房湿度 = dr["泵房湿度"].ToString();
            p.浊度 = dr["浊度"].ToString();
            p.余氯 = dr["余氯"].ToString();
            p.PH值 = dr["PH值"].ToString();
            p.COD = dr["COD"].ToString();
            p.泵1运行状态 = dr["1泵运行状态"].ToString();
            p.泵2运行状态 = dr["2泵运行状态"].ToString();
            p.泵3运行状态 = dr["3泵运行状态"].ToString();
            p.泵4运行状态 = dr["4泵运行状态"].ToString();
            p.泵5运行状态 = dr["5泵运行状态"].ToString();
            p.泵6运行状态 = dr["6泵运行状态"].ToString();
            p.小泵1运行状态 = dr["1小泵运行状态"].ToString();
            p.小泵2运行状态 = dr["2小泵运行状态"].ToString();
            p.泵1手自动状态 = dr["1泵手自动状态"].ToString();
            p.泵2手自动状态 = dr["2泵手自动状态"].ToString();
            p.泵3手自动状态 = dr["3泵手自动状态"].ToString();
            p.泵4手自动状态 = dr["4泵手自动状态"].ToString();
            p.泵5手自动状态 = dr["5泵手自动状态"].ToString();
            p.泵6手自动状态 = dr["6泵手自动状态"].ToString();
            p.小泵1手自动状态 = dr["1小泵手自动状态"].ToString();
            p.小泵2手自动状态 = dr["2小泵手自动状态"].ToString();
            p.系统运行状态 = dr["系统运行状态"].ToString();
            p.PLC故障状态 = dr["PLC故障状态"].ToString();
            p.压力报警状态 = dr["压力报警状态"].ToString();
            p.水箱缺水状态 = dr["水箱缺水状态"].ToString();
            p.变频器1状态 = dr["1变频器状态"].ToString();
            p.变频器2状态 = dr["2变频器状态"].ToString();
            p.变频器3状态 = dr["3变频器状态"].ToString();
            p.变频器4状态 = dr["4变频器状态"].ToString();
            p.阀门开关状态 = dr["阀门开关状态"].ToString();
            p.阀门到位状态 = dr["阀门到位状态"].ToString();
            p.停机报警 = dr["停机报警"].ToString();
            p.泵房进水报警状态 = dr["泵房进水报警状态"].ToString();
            p.门禁报警状态 = dr["门禁报警状态"].ToString();
            p.烟感报警状态 = dr["烟感报警状态"].ToString();
            p.污水泵启停状态 = dr["污水泵启停状态"].ToString();
            p.故障复位操作 = dr["故障复位操作"].ToString();
            p.上位机控制下位机系统 = dr["上位机控制下位机系统"].ToString();
            p.控制参数修改确认键 = dr["控制参数修改确认键"].ToString();
            p.阀门开关控制 = dr["阀门开关控制"].ToString();
            p.远程设定压力 = dr["远程设定压力"].ToString();
            p.加泵频率 = dr["加泵频率"].ToString();
            p.减泵频率 = dr["减泵频率"].ToString();
            p.加泵时间 = dr["加泵时间"].ToString();
            p.减泵时间 = dr["减泵时间"].ToString();
            p.换泵时间 = dr["换泵时间"].ToString();
            p.睡眠频率 = dr["睡眠频率"].ToString();
            p.睡眠延时 = dr["睡眠延时"].ToString();
            p.唤醒值设定 = dr["唤醒值设定"].ToString();
            p.负压报警值设定 = dr["负压报警值设定"].ToString();
            p.负压停止延时 = dr["负压停止延时"].ToString();
            p.超压警值设定 = dr["超压警值设定"].ToString();
            p.超压停止延时 = dr["超压停止延时"].ToString();
            p.泵1启停控制 = dr["1泵启停控制"].ToString();
            p.泵2启停控制 = dr["2泵启停控制"].ToString();
            p.泵3启停控制 = dr["3泵启停控制"].ToString();
            p.泵4启停控制 = dr["4泵启停控制"].ToString();
            p.泵5启停控制 = dr["5泵启停控制"].ToString();
            p.泵6启停控制 = dr["6泵启停控制"].ToString();
            p.小泵1启停控制 = dr["1小泵启停控制"].ToString();
            p.小泵2启停控制 = dr["2小泵启停控制"].ToString();
            return p;
        }

        //day=1：昨天，=0：今天，=2：前天
        /// <summary>
        /// 获取昨天今天或者前天的数据
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="fieldname"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public IEnumerable<string> GetDataByDay(string tablename,string fieldname,int day)
        {
            if (day == 0)
            {
                List<string> list = new List<string>();
                DataTable dt = MySqlHelper.ExecuteDataTable("select " + fieldname + " from " + tablename + " where to_days(时间) = to_days(now());");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(dr[fieldname].ToString());
                }
                return list;
            }
            else if (day == 1)
            {
                List<string> list1 = new List<string>();
                DataTable dt = MySqlHelper.ExecuteDataTable("SELECT " + fieldname + " FROM " + tablename + " WHERE TO_DAYS( NOW( ) ) - TO_DAYS(时间) = 1;");
                foreach (DataRow dr in dt.Rows)
                {
                    list1.Add(dr[fieldname].ToString());
                }
                return list1;
            }
            else if (day == 2)
            {
                List<string> list2 = new List<string>();
                DataTable dt = MySqlHelper.ExecuteDataTable("SELECT " + fieldname + " FROM " + tablename + " WHERE TO_DAYS( NOW( ) ) - TO_DAYS(时间) = 2;");
                foreach (DataRow dr in dt.Rows)
                {
                    list2.Add(dr[fieldname].ToString());
                }
                return list2;
            }
            else
                return null;
        }

        //取时间点左右5分钟的数据
        public IEnumerable<BaseAll> GetAllByTime(string tablename,DateTime time)
        {
            DataTable dt = MySqlHelper.ExecuteDataTable("select * from " + tablename + " where 时间 >= '"+time.AddMinutes(-5).ToString()+"' and 时间 <='"+time.AddMinutes(5).ToString()+"'; ");
            List<BaseAll> list = new List<BaseAll>();
            foreach (DataRow dr in dt.Rows)
            {
                BaseAll p = new BaseAll();
                p.Id = Convert.ToInt32(dr["Id"]);
                p.时间 = (DateTime)dr["时间"];
                p.进口压力 = dr["进口压力"].ToString();
                p.出口压力 = dr["出口压力"].ToString();
                p.设定压力 = dr["设定压力"].ToString();
                p.变频器1运行频率 = dr["1变频器运行频率"].ToString();
                p.变频器2运行频率 = dr["2变频器运行频率"].ToString();
                p.变频器3运行频率 = dr["3变频器运行频率"].ToString();
                p.变频器4运行频率 = dr["4变频器运行频率"].ToString();
                p.变频器1运行电流 = dr["1变频器运行频率"].ToString();
                p.变频器2运行电流 = dr["2变频器运行电流"].ToString();
                p.变频器3运行电流 = dr["3变频器运行电流"].ToString();
                p.变频器4运行电流 = dr["4变频器运行电流"].ToString();
                p.变频器1运行电压 = dr["1变频器运行电压"].ToString();
                p.变频器2运行电压 = dr["2变频器运行电压"].ToString();
                p.变频器3运行电压 = dr["3变频器运行电压"].ToString();
                p.变频器4运行电压 = dr["4变频器运行电压"].ToString();
                p.变频器1运行温度 = dr["1变频器运行温度"].ToString();
                p.变频器2运行温度 = dr["2变频器运行温度"].ToString();
                p.变频器3运行温度 = dr["3变频器运行温度"].ToString();
                p.变频器4运行温度 = dr["4变频器运行温度"].ToString();
                p.泵1运行电流 = dr["1泵运行电流"].ToString();
                p.泵2运行电流 = dr["2泵运行电流"].ToString();
                p.泵3运行电流 = dr["3泵运行电流"].ToString();
                p.泵4运行电流 = dr["4泵运行电流"].ToString();
                p.泵5运行电流 = dr["5泵运行电流"].ToString();
                p.泵6运行电流 = dr["6泵运行电流"].ToString();
                p.小泵1运行电流 = dr["1小泵运行电流"].ToString();
                p.小泵2运行电流 = dr["1小泵运行电流"].ToString();
                p.系统总电压 = dr["系统总电压"].ToString();
                p.系统总电流 = dr["系统总电流"].ToString();
                p.总电能 = dr["总电能"].ToString();
                p.A相电压 = dr["A相电压"].ToString();
                p.B相电压 = dr["B相电压"].ToString();
                p.C相电压 = dr["C相电压"].ToString();
                p.A相电流 = dr["A相电流"].ToString();
                p.B相电流 = dr["B相电流"].ToString();
                p.C相电流 = dr["C相电流"].ToString();
                p.压力传感器量程 = dr["压力传感器量程"].ToString();
                p.水箱液位高度 = dr["水箱液位高度"].ToString();
                p.瞬时流量 = dr["瞬时流量"].ToString();
                p.正向累计流量 = dr["正向累计流量"].ToString();
                p.反向累计流量 = dr["反向累计流量"].ToString();
                p.泵房温度 = dr["泵房温度"].ToString();
                p.泵房湿度 = dr["泵房湿度"].ToString();
                p.浊度 = dr["浊度"].ToString();
                p.余氯 = dr["余氯"].ToString();
                p.PH值 = dr["PH值"].ToString();
                p.COD = dr["COD"].ToString();
                p.泵1运行状态 = dr["1泵运行状态"].ToString();
                p.泵2运行状态 = dr["2泵运行状态"].ToString();
                p.泵3运行状态 = dr["3泵运行状态"].ToString();
                p.泵4运行状态 = dr["4泵运行状态"].ToString();
                p.泵5运行状态 = dr["5泵运行状态"].ToString();
                p.泵6运行状态 = dr["6泵运行状态"].ToString();
                p.小泵1运行状态 = dr["1小泵运行状态"].ToString();
                p.小泵2运行状态 = dr["2小泵运行状态"].ToString();
                p.泵1手自动状态 = dr["1泵手自动状态"].ToString();
                p.泵2手自动状态 = dr["2泵手自动状态"].ToString();
                p.泵3手自动状态 = dr["3泵手自动状态"].ToString();
                p.泵4手自动状态 = dr["4泵手自动状态"].ToString();
                p.泵5手自动状态 = dr["5泵手自动状态"].ToString();
                p.泵6手自动状态 = dr["6泵手自动状态"].ToString();
                p.小泵1手自动状态 = dr["1小泵手自动状态"].ToString();
                p.小泵2手自动状态 = dr["2小泵手自动状态"].ToString();
                p.系统运行状态 = dr["系统运行状态"].ToString();
                p.PLC故障状态 = dr["PLC故障状态"].ToString();
                p.压力报警状态 = dr["压力报警状态"].ToString();
                p.水箱缺水状态 = dr["水箱缺水状态"].ToString();
                p.变频器1状态 = dr["1变频器状态"].ToString();
                p.变频器2状态 = dr["2变频器状态"].ToString();
                p.变频器3状态 = dr["3变频器状态"].ToString();
                p.变频器4状态 = dr["4变频器状态"].ToString();
                p.阀门开关状态 = dr["阀门开关状态"].ToString();
                p.阀门到位状态 = dr["阀门到位状态"].ToString();
                p.停机报警 = dr["停机报警"].ToString();
                p.泵房进水报警状态 = dr["泵房进水报警状态"].ToString();
                p.门禁报警状态 = dr["门禁报警状态"].ToString();
                p.烟感报警状态 = dr["烟感报警状态"].ToString();
                p.污水泵启停状态 = dr["污水泵启停状态"].ToString();
                p.故障复位操作 = dr["故障复位操作"].ToString();
                p.上位机控制下位机系统 = dr["上位机控制下位机系统"].ToString();
                p.控制参数修改确认键 = dr["控制参数修改确认键"].ToString();
                p.阀门开关控制 = dr["阀门开关控制"].ToString();
                p.远程设定压力 = dr["远程设定压力"].ToString();
                p.加泵频率 = dr["加泵频率"].ToString();
                p.减泵频率 = dr["减泵频率"].ToString();
                p.加泵时间 = dr["加泵时间"].ToString();
                p.减泵时间 = dr["减泵时间"].ToString();
                p.换泵时间 = dr["换泵时间"].ToString();
                p.睡眠频率 = dr["睡眠频率"].ToString();
                p.睡眠延时 = dr["睡眠延时"].ToString();
                p.唤醒值设定 = dr["唤醒值设定"].ToString();
                p.负压报警值设定 = dr["负压报警值设定"].ToString();
                p.负压停止延时 = dr["负压停止延时"].ToString();
                p.超压警值设定 = dr["超压警值设定"].ToString();
                p.超压停止延时 = dr["超压停止延时"].ToString();
                p.泵1启停控制 = dr["1泵启停控制"].ToString();
                p.泵2启停控制 = dr["2泵启停控制"].ToString();
                p.泵3启停控制 = dr["3泵启停控制"].ToString();
                p.泵4启停控制 = dr["4泵启停控制"].ToString();
                p.泵5启停控制 = dr["5泵启停控制"].ToString();
                p.泵6启停控制 = dr["6泵启停控制"].ToString();
                p.小泵1启停控制 = dr["1小泵启停控制"].ToString();
                p.小泵2启停控制 = dr["2小泵启停控制"].ToString();

                list.Add(p);


            }
            return list;
        }

        private static BaseAll ToModel(DataRow dr)
        {
            BaseAll p = new BaseAll();
            p.Id = Convert.ToInt32(dr["Id"]);
            p.时间 = (DateTime)dr["时间"];
            p.进口压力 = dr["进口压力"].ToString();
            p.出口压力 = dr["出口压力"].ToString();
            p.设定压力 = dr["设定压力"].ToString();
            p.变频器1运行频率 = dr["1变频器运行频率"].ToString();
            p.变频器2运行频率 = dr["2变频器运行频率"].ToString();
            p.变频器3运行频率 = dr["3变频器运行频率"].ToString();
            p.变频器4运行频率 = dr["4变频器运行频率"].ToString();
            p.变频器1运行电流 = dr["1变频器运行频率"].ToString();
            p.变频器2运行电流 = dr["2变频器运行电流"].ToString();
            p.变频器3运行电流 = dr["3变频器运行电流"].ToString();
            p.变频器4运行电流 = dr["4变频器运行电流"].ToString();
            p.变频器1运行电压 = dr["1变频器运行电压"].ToString();
            p.变频器2运行电压 = dr["2变频器运行电压"].ToString();
            p.变频器3运行电压 = dr["3变频器运行电压"].ToString();
            p.变频器4运行电压 = dr["4变频器运行电压"].ToString();
            p.变频器1运行温度 = dr["1变频器运行温度"].ToString();
            p.变频器2运行温度 = dr["2变频器运行温度"].ToString();
            p.变频器3运行温度 = dr["3变频器运行温度"].ToString();
            p.变频器4运行温度 = dr["4变频器运行温度"].ToString();
            p.泵1运行电流 = dr["1泵运行电流"].ToString();
            p.泵2运行电流 = dr["2泵运行电流"].ToString();
            p.泵3运行电流 = dr["3泵运行电流"].ToString();
            p.泵4运行电流 = dr["4泵运行电流"].ToString();
            p.泵5运行电流 = dr["5泵运行电流"].ToString();
            p.泵6运行电流 = dr["6泵运行电流"].ToString();
            p.小泵1运行电流 = dr["1小泵运行电流"].ToString();
            p.小泵2运行电流 = dr["1小泵运行电流"].ToString();
            p.系统总电压 = dr["系统总电压"].ToString();
            p.系统总电流 = dr["系统总电流"].ToString();
            p.总电能 = dr["总电能"].ToString();
            p.A相电压 = dr["A相电压"].ToString();
            p.B相电压 = dr["B相电压"].ToString();
            p.C相电压 = dr["C相电压"].ToString();
            p.A相电流 = dr["A相电流"].ToString();
            p.B相电流 = dr["B相电流"].ToString();
            p.C相电流 = dr["C相电流"].ToString();
            p.压力传感器量程 = dr["压力传感器量程"].ToString();
            p.水箱液位高度 = dr["水箱液位高度"].ToString();
            p.瞬时流量 = dr["瞬时流量"].ToString();
            p.正向累计流量 = dr["正向累计流量"].ToString();
            p.反向累计流量 = dr["反向累计流量"].ToString();
            p.泵房温度 = dr["泵房温度"].ToString();
            p.泵房湿度 = dr["泵房湿度"].ToString();
            p.浊度 = dr["浊度"].ToString();
            p.余氯 = dr["余氯"].ToString();
            p.PH值 = dr["PH值"].ToString();
            p.COD = dr["COD"].ToString();
            p.泵1运行状态 = dr["1泵运行状态"].ToString();
            p.泵2运行状态 = dr["2泵运行状态"].ToString();
            p.泵3运行状态 = dr["3泵运行状态"].ToString();
            p.泵4运行状态 = dr["4泵运行状态"].ToString();
            p.泵5运行状态 = dr["5泵运行状态"].ToString();
            p.泵6运行状态 = dr["6泵运行状态"].ToString();
            p.小泵1运行状态 = dr["1小泵运行状态"].ToString();
            p.小泵2运行状态 = dr["2小泵运行状态"].ToString();
            p.泵1手自动状态 = dr["1泵手自动状态"].ToString();
            p.泵2手自动状态 = dr["2泵手自动状态"].ToString();
            p.泵3手自动状态 = dr["3泵手自动状态"].ToString();
            p.泵4手自动状态 = dr["4泵手自动状态"].ToString();
            p.泵5手自动状态 = dr["5泵手自动状态"].ToString();
            p.泵6手自动状态 = dr["6泵手自动状态"].ToString();
            p.小泵1手自动状态 = dr["1小泵手自动状态"].ToString();
            p.小泵2手自动状态 = dr["2小泵手自动状态"].ToString();
            p.系统运行状态 = dr["系统运行状态"].ToString();
            p.PLC故障状态 = dr["PLC故障状态"].ToString();
            p.压力报警状态 = dr["压力报警状态"].ToString();
            p.水箱缺水状态 = dr["水箱缺水状态"].ToString();
            p.变频器1状态 = dr["1变频器状态"].ToString();
            p.变频器2状态 = dr["2变频器状态"].ToString();
            p.变频器3状态 = dr["3变频器状态"].ToString();
            p.变频器4状态 = dr["4变频器状态"].ToString();
            p.阀门开关状态 = dr["阀门开关状态"].ToString();
            p.阀门到位状态 = dr["阀门到位状态"].ToString();
            p.停机报警 = dr["停机报警"].ToString();
            p.泵房进水报警状态 = dr["泵房进水报警状态"].ToString();
            p.门禁报警状态 = dr["门禁报警状态"].ToString();
            p.烟感报警状态 = dr["烟感报警状态"].ToString();
            p.污水泵启停状态 = dr["污水泵启停状态"].ToString();
            p.故障复位操作 = dr["故障复位操作"].ToString();
            p.上位机控制下位机系统 = dr["上位机控制下位机系统"].ToString();
            p.控制参数修改确认键 = dr["控制参数修改确认键"].ToString();
            p.阀门开关控制 = dr["阀门开关控制"].ToString();
            p.远程设定压力 = dr["远程设定压力"].ToString();
            p.加泵频率 = dr["加泵频率"].ToString();
            p.减泵频率 = dr["减泵频率"].ToString();
            p.加泵时间 = dr["加泵时间"].ToString();
            p.减泵时间 = dr["减泵时间"].ToString();
            p.换泵时间 = dr["换泵时间"].ToString();
            p.睡眠频率 = dr["睡眠频率"].ToString();
            p.睡眠延时 = dr["睡眠延时"].ToString();
            p.唤醒值设定 = dr["唤醒值设定"].ToString();
            p.负压报警值设定 = dr["负压报警值设定"].ToString();
            p.负压停止延时 = dr["负压停止延时"].ToString();
            p.超压警值设定 = dr["超压警值设定"].ToString();
            p.超压停止延时 = dr["超压停止延时"].ToString();
            p.泵1启停控制 = dr["1泵启停控制"].ToString();
            p.泵2启停控制 = dr["2泵启停控制"].ToString();
            p.泵3启停控制 = dr["3泵启停控制"].ToString();
            p.泵4启停控制 = dr["4泵启停控制"].ToString();
            p.泵5启停控制 = dr["5泵启停控制"].ToString();
            p.泵6启停控制 = dr["6泵启停控制"].ToString();
            p.小泵1启停控制 = dr["1小泵启停控制"].ToString();
            p.小泵2启停控制 = dr["2小泵启停控制"].ToString();
            return p;

        }


        /// <summary>
        /// 用来将某天的数据打印出来
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="time">某天的日期，默认是当日的日期</param>
        /// <returns></returns>
        public IEnumerable<BaseAll> GetDataByDate(string tablename, string time)
        {
            DataTable dt = MySqlHelper.ExecuteDataTable("select * from "+tablename+" where date_format(时间,'%Y-%m-%d')='"+time+"';");
            List<BaseAll> list = new List<BaseAll>();
            foreach(DataRow dr in dt.Rows)
            {
                BaseAll ba = new BaseAll();
                ba = ToModel(dr);
                list.Add(ba);

            }
            return list;
        }
    }



    
}
