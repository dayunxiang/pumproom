using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuCheap.Core.Web.Mysql.BLL;
using JuCheap.Core.Web.Mysql.Model;
using Microsoft.AspNetCore.Mvc;

namespace JuCheap.Core.Web.Controllers
{
    public class RunAnaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Pressure()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetData1(string sidx, string sord, int page, int rows)
        {

            List<PressureData> list =(List<PressureData>) new PressureData_BLL().GetPressureAna();
            var jsonData = new
            {
                total = 1, // we'll implement later 
                page = 1,
                records = 13, // implement later        
                //rows = new[]{
                //new {id = 1, cell = new[] {"1","三利plc","黄岛昆仑山泵站你1","设定压力","2018-05-10","0.550","0.520","00:01","0.520","00:01","0.520","00:01","0.520","2018-05-09 00:01","0.520","0.520"}}}
                rows = (
                from s in list
                select new
                {
                    id=s.Id,
                    cell=new string[] {
                        s.Id.ToString(),
                    s.分区名称.ToString(),s.站点名称.ToString(),s.传感器.ToString(),s.上传时间.ToString(),s.压力.ToString(),s.今日最高.ToString(),s.时间1.ToString(),s.今日最低.ToString(),s.时间2.ToString(),s.昨日最高.ToString(),s.时间3.ToString(),s.昨日最低.ToString(),s.时间4.ToString(),s.今日平均.ToString(),s.昨日平均.ToString()}
                }).ToArray()


            };
            //string s = sidx + " " + sord + " " + page.ToString() + " " + rows.ToString();
            //var jsonData = new
            //{

            //    total = 10, // we'll implement later 。返回的是总共的页数,跟随数据前面的操作而变化
            //    page = page,//这个就不用变了，返回的是当前第几页
            //    records = rows, // implement later 所有的条数，记录中所有的条数。
            //                    //id是当前记录的id号。
            //    rows = new[]{
            //        new {id = 13, cell = new[] {"13","2007-10-06","Client 3","1000.00","0.00","1000.00",s}},
            //        new {id = 12, cell = new[] {"12","2007-10-06","Client 3","1000.00","0.00","1000.00",null}}
            //        }
            //};
            return Json(jsonData);
        }
        //[HttpPost]
        //public IActionResult GetData(string sidx, string sord, int page, int rows)
        //{
        //    string s = sidx + " " + sord + " " + page.ToString() + " " + rows.ToString();
        //    var jsonData = new
        //    {

        //        total = 10, // we'll implement later 。返回的是总共的页数,跟随数据前面的操作而变化
        //        page = page,//这个就不用变了，返回的是当前第几页
        //        records = rows, // implement later 所有的条数，记录中所有的条数。
        //                        //id是当前记录的id号。
        //        rows = new[]{
        //            new {id = 13, cell = new[] {"13","2007-10-06","Client 3","1000.00","0.00","1000.00",s}},
        //            new {id = 12, cell = new[] {"12","2007-10-06","Client 3","1000.00","0.00","1000.00",null}}
        //            }
        //    };



        //    //使用efcore调用原生态的sql语句
        //    //var conn = _context.Database.GetDbConnection();
        //    //try
        //    //{
        //    //    await conn.OpenAsync();
        //    //    using (var command = conn.CreateCommand())
        //    //    {
        //    //        string query = "select "
        //    //    }
        //    //}
        //    //finally
        //    //{
        //    //    conn.Close();
        //    //}
        //    return Json(jsonData);
        //}
    }
}