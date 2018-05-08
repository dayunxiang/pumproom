using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JuCheap.Core.Data;
using JuCheap.Core.Web.Mysql.BLL;
using JuCheap.Core.Web.Mysql.DAL;
using JuCheap.Core.Web.Mysql.Model;
using JuCheap.Core.Web.ToExcel.ZZTOA_BLL;
using JuCheap.Core.Web.ToExcel.ZZTOA_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JuCheap.Core.Web.Controllers
{
    public class RTDataController : Controller
    {
        //使用ef的查询数据库才使用这个。
        private readonly JuCheapContext _context;
        public RTDataController(JuCheapContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<string> list = (List<string>)new ReadPumpRoom_BLL().ReadPumpRoom();
            ViewData["PumpList"] = list;
            //IEnumerable<CeShi1> ls = new CeShi_BLL().GetDiffer();            
            IEnumerable<BaseAll1> ls= new BaseAll_BLL().GetDiffer();
            
            
            
            return View(ls);
        }

        public async Task<IActionResult> ShowData(string s)
        {
            ViewData["tablename"] = "pumproom"+s;
            string name= "pumproom" + s;
            //IEnumerable<BaseAll> list = new BaseAll_BLL().GetAll(s); 
            //IEnumerable<CeShi> list =  await Task.Run(()=> new CeShi_BLL().GetAll(s));

            IEnumerable<BaseAll> list = await Task.Run(() => new BaseAll_BLL().GetAll(name));
            //ViewData["sb"] = new CeShi_DAL().Test(s);
            return View(list);
        }

        public IActionResult Test()
        {
            return View();
        }

        public async Task<IActionResult> RawData()
        {
            //读取数据库中的表名
            //List<string> list = (List<string>)new ReadPumpRoom_BLL().ReadPumpRoom();
            //ViewData["PumpList"] = list;
            //IEnumerable<CeShi1> ls = new CeShi_BLL().GetDiffer();            
            //IEnumerable<BaseAll1> ls = new BaseAll_BLL().GetDiffer();
            return View(await _context.Stations.Where(item => !item.IsDeleted).ToListAsync());





         

        }
        [HttpPost]
        public JsonResult GetDataByTime(string tablename, string time)
        {
            DateTime timep = Convert.ToDateTime(time);
            IEnumerable<BaseAll> ls = new BaseAll_BLL().GetAllByTime(tablename, timep);
            string json = JsonConvert.SerializeObject(ls);
            //string json = tablename + time;
            return Json(new{ IsSuccess=true,json});

        }

        [HttpPost]
        public FileResult ExportExcelToClient(IFormCollection fc)
        {
            MemoryStream ms = new MemoryStream();
            //DbSet<>
            //string date = "2018-04-29";
            string tablename = fc["tablename"];
            string date = fc["time"];
            List<BaseAll> list =(List<BaseAll>) new BaseAll_BLL().GetDataByDate(tablename, date);
            ReturnMsg rm = ExportExcel_BLL.ExportMs(ref ms, list, 0, "");
            string downloadname = date + ".xls";
            return File(ms, "application/vnd.ms-excel", downloadname);

        }









    }
}