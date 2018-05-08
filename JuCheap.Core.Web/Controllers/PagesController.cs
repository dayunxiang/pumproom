using JuCheap.Core.Models.Filters;
using JuCheap.Core.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text;

namespace JuCheap.Core.Web.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    [IgnoreRightFilter]
    [Route("pages")]
    public class PagesController : Controller
    { 
        [Route("{id}")]
        public IActionResult Index(string id)
        {
            return View(id);
        }
        public IActionResult suibian()
        {
            return View();
        }
        public IActionResult TimeUse()
        {
            return View();
        }

        public IActionResult Ceshi()
        {
            return View();
        }
        public IActionResult Check()
        {
            return View();
        }
        public IActionResult CeshiTable()
        {
            return View();
        }

       [HttpPost]
        public IActionResult GetData(string sidx, string sord, int page, int rows)
        {
            var jsonData = new
            {
                total = 10, // we'll implement later 
                page = page,
                records = 13, // implement later 
                rows = new[]{
                new {id = 13, cell = new[] {"13","2007-10-06","Client 3","1000.00","0.00","1000.00",null}}}
            };
            return Json(jsonData);
        }




    }
  
}