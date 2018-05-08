using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.DAL
{
    public class CeShi_DAL
    {

        public IEnumerable<CeShi> GetAll(string s)
        {
            DataTable dt = MySqlHelper.ExecuteDataTable("select Id,时间,进口压力,出口压力,设定压力,1变频器运行频率,2变频器运行频率,3变频器运行频率,4变频器运行频率 from " + s+";");
            List<CeShi> list = new List<CeShi>();
            foreach(DataRow dr in dt.Rows)
            {
                CeShi p = new CeShi();
                p.Id = Convert.ToInt32(dr["Id"]);
                p.时间 = (DateTime)dr["时间"];
                p.进口压力 = dr["进口压力"].ToString();
                p.出口压力 = dr["出口压力"].ToString();
                p.设定压力 = dr["设定压力"].ToString();
                p.变频器1运行频率 = dr["1变频器运行频率"].ToString();
                p.变频器2运行频率 = dr["2变频器运行频率"].ToString();
                p.变频器3运行频率 = dr["3变频器运行频率"].ToString();
                p.变频器4运行频率 = dr["4变频器运行频率"].ToString();
                list.Add(p);
            }
            return list;
        }
        public string Test(string s)
        {
            string sb="";
            DataTable dt = MySqlHelper.ExecuteDataTable("select Id from " + s);
            foreach(DataRow dr in dt.Rows)
            {
                sb = sb + dr["Id"].ToString();
            }
            return sb;

        }

        public IEnumerable<CeShi> FenYeGet(int page,int rows,string s)
        {
            DataTable dt=MySqlHelper.ExecuteDataTable("select Id,时间,进口压力,出口压力,设定压力,1变频器运行频率,2变频器运行频率,3变频器运行频率,4变频器运行频率 from " + s + " limit "+(page-1)*rows+","+rows+";");
            List<CeShi> list = new List<CeShi>();
            foreach (DataRow dr in dt.Rows)
            {
                CeShi p = new CeShi();
                p.Id = Convert.ToInt32(dr["Id"]);
                p.时间 = (DateTime)dr["时间"];
                p.进口压力 = dr["进口压力"].ToString();
                p.出口压力 = dr["出口压力"].ToString();
                p.设定压力 = dr["设定压力"].ToString();
                p.变频器1运行频率 = dr["1变频器运行频率"].ToString();
                p.变频器2运行频率 = dr["2变频器运行频率"].ToString();
                p.变频器3运行频率 = dr["3变频器运行频率"].ToString();
                p.变频器4运行频率 = dr["4变频器运行频率"].ToString();
                list.Add(p);
            }
            return list;
        }

        public IEnumerable<CeShi1> GetDiffer()
        {
            List<string> names = (List<string>)new ReadPumpRoom_DAL().ReadPumpRoom();
            List<CeShi1> ls = new List<CeShi1>();
            foreach(string s in names)
            {
                DataTable dt = MySqlHelper.ExecuteDataTable("select Id,时间,进口压力,出口压力,设定压力,1变频器运行频率,2变频器运行频率,3变频器运行频率,4变频器运行频率 from " + s + " order by 时间 desc limit 1 ;");
                CeShi1 p = new CeShi1();
                p.Name = s;
                if (dt.Rows.Count==1)
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
                    

                }
                ls.Add(p);

            }
            return ls;
        }
    }
}
