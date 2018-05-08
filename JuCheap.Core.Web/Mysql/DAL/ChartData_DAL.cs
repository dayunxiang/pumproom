using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.DAL
{
    public class ChartData_DAL
    {
        //只查询当天的数据。
        public IEnumerable<ChartData> GetToday(string tablename)
        {

            List<ChartData> list = new List<ChartData>();
            DataTable dt = MySqlHelper.ExecuteDataTable("select 进口压力,出口压力 from " + tablename + " where to_days(时间) = to_days(now());");
            foreach(DataRow dr in dt.Rows)
            {
                ChartData c = new ChartData();
                c.出口压力 = dr["出口压力"].ToString();
                c.进口压力 = dr["进口压力"].ToString();
                list.Add(c);
            }
            return list;

        }
    }
}
