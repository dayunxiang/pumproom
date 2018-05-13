using JuCheap.Core.Data;
using JuCheap.Core.Models.Filters;
using JuCheap.Core.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly JuCheapContext _context;
        public PagesController(JuCheapContext context)
        {
            _context = context;
        }

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
        /// <summary>
        /// 但是我不知道这些参数是怎么传递过来的，根据这些参数已经可以实现分页的功能，然后还需要的就是搜索，有没有无所谓。
        /// </summary>
        /// <param name="sidx">sort的name</param>
        /// <param name="sord">sord的方式desc或者</param>
        /// <param name="page">当前第几页</param>
        /// <param name="rows">当前页面显示的行数</param>
        /// <returns></returns>
       [HttpPost]
        public IActionResult GetData(string sidx, string sord, int page, int rows)
        {
            string s = sidx + " " + sord + " " + page.ToString() + " " + rows.ToString();
            var jsonData = new
            {
                
                total = 10, // we'll implement later 。返回的是总共的页数,跟随数据前面的操作而变化
                page = page,//这个就不用变了，返回的是当前第几页
                records = rows, // implement later 所有的条数，记录中所有的条数。
                //id是当前记录的id号。
                rows = new[]{
                new {id = 13, cell = new[] {"13","2007-10-06","Client 3","1000.00","0.00","1000.00",s}},
                new {id = 12, cell = new[] {"12","2007-10-06","Client 3","1000.00","0.00","1000.00",null}}
                }
            };
          


            //使用efcore调用原生态的sql语句
            //var conn = _context.Database.GetDbConnection();
            //try
            //{
            //    await conn.OpenAsync();
            //    using (var command = conn.CreateCommand())
            //    {
            //        string query = "select "
            //    }
            //}
            //finally
            //{
            //    conn.Close();
            //}
            return Json(jsonData);
        }




    }
  
}