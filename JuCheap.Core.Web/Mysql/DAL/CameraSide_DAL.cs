using JuCheap.Core.Web.Mysql.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.DAL
{
    public class CameraSide_DAL
    {
        public CameraSide GetAll(string s)
        {
            DataTable dt = MySqlHelper.ExecuteDataTable("select * from " + s + " order by 时间 desc limit 1;");
            CameraSide p = new CameraSide();
            foreach(DataRow dr in dt.Rows)
            {

               p.Id= Convert.ToInt32(dr["Id"]);
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
                p.系统总电压 = dr["系统总电压"].ToString();
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
                p.泵房进水报警状态 = dr["泵房进水报警状态"].ToString();
                p.门禁报警状态 = dr["门禁报警状态"].ToString();
                p.烟感报警状态 = dr["烟感报警状态"].ToString();
                p.故障复位操作 = dr["故障复位操作"].ToString();
                p.上位机控制下位机系统 = dr["上位机控制下位机系统"].ToString();
                p.控制参数修改确认键 = dr["控制参数修改确认键"].ToString();
                p.远程设定压力 = dr["远程设定压力"].ToString();
                p.换泵时间 = dr["换泵时间"].ToString();
                p.超压警值设定 = dr["超压警值设定"].ToString(); 
                p.泵1启停控制 = dr["1泵启停控制"].ToString();
                p.泵2启停控制 = dr["2泵启停控制"].ToString();
                p.泵3启停控制 = dr["3泵启停控制"].ToString();
                p.泵4启停控制 = dr["4泵启停控制"].ToString();
                p.泵5启停控制 = dr["5泵启停控制"].ToString();
                p.泵6启停控制 = dr["6泵启停控制"].ToString();
                //这里面还有未加的。
                p.V88和PLC通讯状态 = dr["V88和PLC通讯状态"].ToString();
                p.进口压力低值设定 = dr["进口压力低值设定"].ToString();
                p.进口压力恢复值设定 = dr["进口压力恢复值设定"].ToString();
                p.出口压力目标值设定 = dr["出口压力目标值设定"].ToString();
                p.检修运行 = dr["检修运行"].ToString();
                p.门禁开关状态 = dr["门禁开关状态"].ToString();
               

            }
            return p;
        }

        //根据泵站的名称，查询camerapath列表中的泵表编号
        public string GetNumByName(string name)
        {
            DataTable dt = MySqlHelper.ExecuteDataTable("select PumpRoomId from camerapaths where PumpRoomName=@name;",new MySqlParameter("name",name));
            string num = "";
            foreach (DataRow dr in dt.Rows)
            {
                num = dr["PumpRoomId"].ToString();
            }
            return num;
        }
    }
}
