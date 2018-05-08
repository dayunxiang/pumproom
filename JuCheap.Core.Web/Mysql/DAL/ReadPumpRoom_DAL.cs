using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.DAL
{
    public class ReadPumpRoom_DAL
    {
        public IEnumerable<string> ReadPumpRoom()
        {
            DataTable dt = MySqlHelper.ExecuteDataTable("select table_name from information_schema.tables where table_schema='jucheapcore' and table_name like 'pumproom%';");
            List<string> list = new List<string>();
            foreach(DataRow dr in dt.Rows)
            {
                string s = dr["table_name"].ToString();
                list.Add(s);
            }
            return list;
        }
    }
}
