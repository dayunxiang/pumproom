using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JuCheap.Core.Data;
using JuCheap.Core.Infrastructure.Extentions;
using JuCheap.Core.Interfaces;
using JuCheap.Core.Models;
using JuCheap.Core.Models.Filters;
using JuCheap.Core.Web.Filters;
using JuCheap.Core.Web.Models;
using JuCheap.Core.Web.Mysql.BLL;
using JuCheap.Core.Web.Mysql.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JuCheap.Core.Web.Controllers
{
    [Authorize]
    public class GisProController : Controller
    {
        private readonly IGisProService _gisProService;
        private readonly IMapper _mapper; 
        private readonly JuCheapContext _context;
        public GisProController(IGisProService gisProSvc,IMapper mapper, JuCheapContext context)
        {
            _gisProService = gisProSvc;
            _mapper = mapper;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View(new GisProDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add(GisProDto dto)
        {
            if(ModelState.IsValid)
            {
                var result = await _gisProService.AddAsync(dto);
                if(result.IsNotBlank())
                {
                    return RedirectToAction("Index");
                }
            }
            return View(dto);
        }

        [IgnoreRightFilter]
        public async Task<IActionResult> GetListWithPager(GisProFilters filters)
        {
            var result = await _gisProService.SearchAsync(filters);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GisProDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            var result = await _gisProService.UpdateAsync(dto);
            if (result)
                return RedirectToAction("Index");
            return View(dto);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var model = await _gisProService.FindAsync(id);
            return View(model);
        }
       public async Task<IActionResult> Delete ([FromBody] IEnumerable<string> ids)
        {
            var result = new JsonResultModel<bool>();
            if(ids.AnyOne())
            {
                result.flag = await _gisProService.DeleteAsync(ids);
            }
            return Json(result);
        }

        public async Task<IActionResult> Pro()
        {

            return View(await _context.GisPros.Where(item => !item.IsDeleted).ToListAsync());
        }
        [HttpPost]
        public JsonResult GetMarkerArr(string id)
        {
            //DbSet<MarkerArrEntity> sb = _context.MarkerArrs;
            //List<MarkerArrEntity> list = sb.ToList();
            //DbSet<GisProEntity> sb = _context.GisPros;
            //List<GisProEntity> list = sb.ToList();
            List<GisData> list =(List<GisData>) new GisData_BLL().GetAll();
            string json = JsonConvert.SerializeObject(list);
            return Json(new { IsSuccess = true, json });
        }
        [HttpPost]
        public JsonResult GetAlarm()
        {
            //获取报警信息
            string message = new GisData_BLL().GetAlarm();
            return Json(new { IsSuccess = true, message });
        }
    }
}