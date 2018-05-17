using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.DAL
{
    public class GisData_DAL
    {
        public IEnumerable<GisData> GetAll()
        {
            int i = 1;
            DataTable dt = MySqlHelper.ExecuteDataTable("select * from gispros where IsDeleted='0';");
            List<GisData> list = new List<GisData>(); 
            foreach(DataRow dr in dt.Rows)
            {
                GisData gd = new GisData();
                gd.id = i;
                gd.title = dr["分区名称"].ToString();
                gd.elecname = dr["泵个数name"].ToString();
                gd.electricity = dr["泵个数"].ToString();
                gd.watername = dr["状态信息name"].ToString();
                gd.water = dr["状态信息"].ToString();
                gd.airname = dr["报警信息name"].ToString();
                gd.air = dr["报警信息"].ToString();
                gd.alarmname =dr["站点名称"].ToString();
                gd.alarm =dr["备用1"].ToString();
                gd.point = dr["坐标"].ToString();
                gd.isOnline =dr["备用2"].ToString();
                gd.beiyong1 =dr["备用3"].ToString();
                gd.beiyong2 =dr["备用4"].ToString();
                list.Add(gd);
                i++;

            }
            return list;
        }
    }
}
