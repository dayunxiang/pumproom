using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuCheap.Core.Data;
using JuCheap.Core.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JuCheap.Core.Web.Controllers
{
    public class GisController : Controller
    {
        //引入context
        private readonly JuCheapContext _context;
        public GisController(JuCheapContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetMarkerArr(string id)
        {
            DbSet<MarkerArrEntity> sb = _context.MarkerArrs;
            List<MarkerArrEntity> list = sb.ToList();
            //DbSet<GisProEntity> sb = _context.GisPros;
            //List<GisProEntity> list = sb.ToList();
            string json = JsonConvert.SerializeObject(list);
            return Json(new { IsSuccess = true, json });
        }
        public IActionResult Advance()
        {
            return View();
        }

    }
}