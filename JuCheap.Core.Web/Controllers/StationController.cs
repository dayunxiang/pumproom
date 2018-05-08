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
    public class StationController : Controller
    {
        private readonly IStationService _stationservice;
        private readonly IMapper _mapper;
        public StationController(IStationService stationservice,IMapper mapper)
        {
            _stationservice = stationservice;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View(new StationDto());
        }
        [HttpPost]
        public async Task<IActionResult> Add(StationDto dto)
        {
            if(ModelState.IsValid)
            {
                var result = await _stationservice.AddAsync(dto);
                if(result.IsNotBlank())
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        [IgnoreRightFilter]
        public async Task<IActionResult> GetListWithPager(StationFilters filters)
        {
            var result = await _stationservice.SearchAsync(filters);
            return Json(result);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(StationDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            var result = await _stationservice.UpdateAsync(dto);
            if (result)
                return RedirectToAction("Index");
            return View(dto);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await _stationservice.FindAsync(id);
            return View(model);
        }
        public async Task<IActionResult> Check(string id)
        {
            var model = await _stationservice.FindAsync(id);
            return View(model);
        }

        public async Task<IActionResult> Delete([FromBody]IEnumerable<string> ids)
        {
            var result = new JsonResultModel<bool>();
            if (ids.AnyOne())
            {
                result.flag = await _stationservice.DeleteAsync(ids);
            }
            return Json(result);
        }



    }
}