using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JuCheap.Core.Infrastructure.Extentions;
using JuCheap.Core.Interfaces;
using JuCheap.Core.Models;
using JuCheap.Core.Models.Filters;
using JuCheap.Core.Web.Filters;
using JuCheap.Core.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JuCheap.Core.Web.Controllers
{
    [Authorize]
    public class GisProController : Controller
    {
        private readonly IGisProService _gisProService;
        private readonly IMapper _mapper; 
        public GisProController(IGisProService gisProSvc,IMapper mapper)
        {
            _gisProService = gisProSvc;
            _mapper = mapper;
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
    }
}