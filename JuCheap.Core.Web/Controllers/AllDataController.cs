using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuCheap.Core.Data;
using JuCheap.Core.Web.Mysql.BLL;
using JuCheap.Core.Web.Mysql.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JuCheap.Core.Web.Controllers
{
    public class AllDataController : Controller
    {
        private readonly JuCheapContext _context;
        public AllDataController(JuCheapContext context)
        {
            _context = context;
        }
        //返回所有的station然后用于显示列表
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stations.Where(item=>!item.IsDeleted).ToListAsync());
        }
        //传入的是站点的名称
        public async Task<IActionResult> AllView(string s)
        {
            ViewData["stationname"] = s;
            return View(await _context.Stations.Where(item=>!item.IsDeleted)
                .Where(item=>item.站点名称==s).ToListAsync());
        }
        //输入参数，站点名称
        [HttpPost]
        public  JsonResult GetData(string data)
        {
            BaseAll p =  new BaseAll_BLL().GetByName(data);
            //IEnumerable<BaseAll1> list = new BaseAll_BLL().GetDiffer();
            string json= JsonConvert.SerializeObject(p);
            //string json = "hello"+data;
            return Json(new { IsSuccess = true, json });
        }
        //获取图标的数据
        [HttpPost]
        public JsonResult GetChartData(string name,string fieldname,int day)
        {
            string s = new BaseAll_BLL().GetNumberByName(name);
            string tablename = "pumproom" + s;
            List<string> list = (List<string>)new BaseAll_BLL().GetDataByDay(tablename, fieldname, day);
            string json = JsonConvert.SerializeObject(list);
            //string json = name+fieldname+day.ToString();
            return Json(new { IsSuccess = true, json });

        }
        [HttpPost]
        public JsonResult GetChartDataPro(string name)
        {
            string s = new BaseAll_BLL().GetNumberByName(name);
            string tablename = "pumproom" + s;
            List<ChartData> list = (List<ChartData>)new ChartData_BLL().GetToday(tablename);
            string json = JsonConvert.SerializeObject(list);
            return Json(new { IsSuccess = true, json });


        }
    }
}