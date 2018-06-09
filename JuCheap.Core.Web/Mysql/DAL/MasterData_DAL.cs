using JuCheap.Core.Web.Mysql.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.DAL
{
    public class MasterData_DAL
    {
        public MasterData GetMasterData(string tablename)
        {
            List<MasterData> list = new List<MasterData>();
            DataTable dt = MySqlHelper.ExecuteDataTable("select * from "+tablename+" order by 时间 desc limit 1");
            MasterData md = new MasterData();
            md.远程设定压力 = dt.Rows[0]["远程设定压力"].ToString();
            md.加泵频率 = dt.Rows[0]["加泵频率"].ToString();
            md.减泵频率 = dt.Rows[0]["减泵频率"].ToString();
            md.加泵时间 = dt.Rows[0]["加泵时间"].ToString();
            md.减泵时间 = dt.Rows[0]["减泵时间"].ToString();
            md.换泵时间 = dt.Rows[0]["换泵时间"].ToString();
            md.睡眠频率 = dt.Rows[0]["睡眠频率"].ToString();
            md.睡眠延时 = dt.Rows[0]["睡眠延时"].ToString();
            md.唤醒值设定 = dt.Rows[0]["唤醒值设定"].ToString();
            md.负压报警值设定 = dt.Rows[0]["负压报警值设定"].ToString();
            md.负压停止延时 = dt.Rows[0]["负压停止延时"].ToString();
            md.超压警值设定 = dt.Rows[0]["超压警值设定"].ToString();
            md.超压停止延时 = dt.Rows[0]["超压停止延时"].ToString();
            md.泵1启停控制 = dt.Rows[0]["1泵启停控制"].ToString();
            md.泵2启停控制 = dt.Rows[0]["2泵启停控制"].ToString();
            md.泵3启停控制 = dt.Rows[0]["3泵启停控制"].ToString();
            md.泵4启停控制 = dt.Rows[0]["4泵启停控制"].ToString();
            md.泵5启停控制 = dt.Rows[0]["5泵启停控制"].ToString();
            md.泵6启停控制 = dt.Rows[0]["6泵启停控制"].ToString();
            md.小泵1启停控制 = dt.Rows[0]["1小泵启停控制"].ToString();
            md.小泵2启停控制 = dt.Rows[0]["2小泵启停控制"].ToString();
            return md;
        }

        /// <summary>
        /// 根据站点名称查泵站的ip，查的是camerapath的表中的ip
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetIpByName(string name)
        {
            DataTable dt = MySqlHelper.ExecuteDataTable("select Ip from camerapaths where PumpRoomName=@name; ", new MySqlParameter("name", name));
            string ip = "";
            foreach (DataRow dr in dt.Rows)
            {
                ip = dr["Ip"].ToString();
            }
            return ip;

        }
    }
}
