using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.DAL
{
    public class PressureData_DAL
    {
        //如果为空写入空的字符串即可。jqgrid的要求。
        public IEnumerable<PressureData> GetPressureAna()
        {
            int i = 1;
            string[] sensor = { "设定压力", "进口压力", "出口压力" };
            List<PressureData> list = new List<PressureData>();
            //查询分区名称、站点名称、编号
            DataTable dt = MySqlHelper.ExecuteDataTable("select 分区名称,站点名称,编号 from stations where IsDeleted = '0';"); 
            foreach(DataRow dr in dt.Rows)
            {
                for(int j=0;j<3;j++)
                {
                    PressureData pd = new PressureData();
                    pd.Id = i;
                    pd.分区名称 = dr["分区名称"].ToString();
                    pd.站点名称 = dr["站点名称"].ToString();
                    pd.Tablename = "pumproom" + dr["编号"].ToString();
                    pd.传感器 = sensor[j];
                    pd.上传时间 = "";
                    list.Add(pd);
                    i++;
                }
            }

            //后面查询并计算各种平均值,然后补充到list当中
            for (int k = 0; k < list.Count; k++)
            {
                //string tablename = list[k].Tablename;
                //先查询最大压力及时间
                DataTable dt1 = MySqlHelper.ExecuteDataTable("select " + list[k].传感器 + ",时间 from " + list[k].Tablename + " where to_days(时间)=to_days(now()) order by " + list[k].传感器 + " desc limit 1 ;");
                if (dt1.Rows.Count == 0)
                {
                    list[k].今日最高 = "";
                    list[k].时间1 = "";
                }
                else
                {
                    list[k].今日最高 = dt1.Rows[0][list[k].传感器.ToString()].ToString();
                    list[k].时间1 = dt1.Rows[0]["时间"].ToString();
                }
                DataTable dt2 = MySqlHelper.ExecuteDataTable("select " + list[k].传感器 + ",时间 from " + list[k].Tablename + " where to_days(时间)=to_days(now()) order by " + list[k].传感器 + " asc limit 1 ;");
                if (dt2.Rows.Count == 0)
                {
                    list[k].今日最低 = "";
                    list[k].时间2 = "";
                }
                else
                {
                    list[k].今日最低 = dt2.Rows[0][list[k].传感器.ToString()].ToString();
                    list[k].时间2 = dt2.Rows[0]["时间"].ToString();
                }
                DataTable dt3 = MySqlHelper.ExecuteDataTable("select " + list[k].传感器 + ",时间 from " + list[k].Tablename + " where to_days(now())-to_days(时间)=1 order by " + list[k].传感器 + " desc limit 1 ;");
                if (dt3.Rows.Count == 0)
                {
                    list[k].昨日最高 = "";
                    list[k].时间3 = "";
                }
                else
                {
                    list[k].昨日最高 = dt3.Rows[0][list[k].传感器.ToString()].ToString();
                    list[k].时间3 = dt3.Rows[0]["时间"].ToString();
                }
                DataTable dt4 = MySqlHelper.ExecuteDataTable("select " + list[k].传感器 + ",时间 from " + list[k].Tablename + " where to_days(now())-to_days(时间)=1 order by " + list[k].传感器 + " asc limit 1 ;");
                if (dt4.Rows.Count == 0)
                {
                    list[k].昨日最低 = "";
                    list[k].时间4 = "";
                }
                else
                {
                    list[k].昨日最低 = dt4.Rows[0][list[k].传感器.ToString()].ToString();
                    list[k].时间4 = dt4.Rows[0]["时间"].ToString();
                }
                DataTable dt5 = MySqlHelper.ExecuteDataTable("select avg(" + list[k].传感器.ToString() + ") as 昨日平均 from " + list[k].Tablename + " where to_days(now())-to_days(时间)=1;");
                if (dt5.Rows.Count == 0)
                {
                    list[k].昨日平均 = "";

                }
                else
                {
                    list[k].昨日平均 = dt5.Rows[0]["昨日平均"].ToString();
                }
                DataTable dt6 = MySqlHelper.ExecuteDataTable("select avg(" + list[k].传感器.ToString() + ") as 今日平均 from " + list[k].Tablename + " where to_days(时间)=to_days(now());");
                if (dt6.Rows.Count == 0)
                {
                    list[k].今日平均 = "";
                }
                else
                {
                    list[k].今日平均 = dt6.Rows[0]["今日平均"].ToString();
                }
                DataTable dt7 = MySqlHelper.ExecuteDataTable("select " + list[k].传感器 + " as 压力, 时间  from " + list[k].Tablename + " order by 时间 desc limit 1;");
                if (dt7.Rows.Count == 0)
                {
                    list[k].压力 = "";
                    list[k].上传时间 = "";
                }
                else
                {
                    list[k].压力 = dt7.Rows[0]["压力"].ToString();
                    list[k].上传时间 = dt7.Rows[0]["时间"].ToString();
                    //list[k].压力 = "123";
                    //list[k].上传时间 = "123";
                }
                //list[k].压力 = "123";
                //list[k].上传时间 = "123";
            }
            return list;
        }
    }
}
