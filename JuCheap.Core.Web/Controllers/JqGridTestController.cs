using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuCheap.Core.Infrastructure;
using JuCheap.Core.Models;
using JuCheap.Core.Models.Filters;
using JuCheap.Core.Web.Filters;
using JuCheap.Core.Web.Mysql.BLL;
using JuCheap.Core.Web.Mysql.Model;
using Microsoft.AspNetCore.Mvc;

namespace JuCheap.Core.Web.Controllers
{
    public class JqGridTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[IgnoreRightFilter]
        //public async Task<IActionResult> Test(JqGridTestFilters filters)
        //{
        //    //需要返回一个json
        //    //var result = await SearchData(filters);
        //    //return Json(result);
            

        //}

        
    }
}