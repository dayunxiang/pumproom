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

        public IActionResult Staus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetData3(string sidx, string sord, int page, int rows)
        {
            //string s = sidx + " " + sord + " " + page.ToString() + " " + rows.ToString();

            List<RTData> list = (List<RTData>)new RTData_BLL().GetRTData();

            var jsonData = new
            {

                total = 1, // we'll implement later 。返回的是总共的页数,跟随数据前面的操作而变化
                page = 1,//这个就不用变了，返回的是当前第几页
                records = rows, // implement later 所有的条数，记录中所有的条数。
                //id是当前记录的id号。
                //rows = new[]{
                //new {id = 13, cell = new[] {"13","2007-10-06","Client 3","1000.00","0.00","1000.00",null}},
                //new {id = 12, cell = new[] {"12","2007-10-06","Client 3","1000.00","0.00","1000.00",null}}
                rows = (
                from s in list
                select new
                {
                    id = s.Id,
                    cell = new string[] {
                    s.Id.ToString(),s.分区名称.ToString(),s.站点名称.ToString(),s.上传时间.ToString(),s.泵1运行状态.ToString(),s.泵2运行状态.ToString(),s.泵3运行状态.ToString(),s.泵4运行状态.ToString(),s.泵5运行状态.ToString(),s.泵6运行状态.ToString(),s.小泵1运行状态.ToString(),s.小泵2运行状态.ToString(),s.泵1手自动状态.ToString(),s.泵2手自动状态.ToString(),s.泵3手自动状态.ToString(),s.泵4手自动状态.ToString(),s.泵5手自动状态.ToString(),s.泵6手自动状态.ToString(),s.小泵1手自动状态.ToString(),s.小泵2手自动状态.ToString(),s.系统运行状态.ToString(),s.PLC故障状态.ToString(),s.压力报警状态.ToString(),s.水箱缺水状态.ToString(),s.变频器1状态.ToString(),s.变频器2状态.ToString(),s.变频器3状态.ToString(),s.变频器4状态.ToString(),s.阀门开关状态.ToString(),s.阀门到位状态.ToString(),s.停机报警.ToString(),s.泵房进水报警状态.ToString(),s.停电来电报警状态.ToString(),s.门禁报警状态.ToString(),s.烟感报警状态.ToString(),s.污水泵启停状态.ToString(),s.V88和PLC通讯状态.ToString(),s.进口压力低值设定.ToString(),s.进口压力恢复值设定.ToString(),s.出口压力目标值设定.ToString(),s.检修运行.ToString(),s.门禁开关状态.ToString()}
                }).ToArray()

            };
            return Json(jsonData);
        }








    }
}