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
    public class CameraPathController : Controller
    {
        private readonly ICameraPathService _cameraPathService;
        private readonly IMapper _mapper;
        public CameraPathController(ICameraPathService cameraPathSvc,IMapper mapper)
        {
            _cameraPathService=cameraPathSvc;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View(new CameraPathDto());
        }
        [HttpPost]
        public async Task<IActionResult> Add(CameraPathDto dto)
        {
            if(ModelState.IsValid)
            {
                var result = await _cameraPathService.AddAsync(dto);
                if (result.IsNotBlank())
                    return RedirectToAction("Index");

            }
            return View(dto);
        }
        [IgnoreRightFilter]
        public async Task<IActionResult> GetListWithPager(CameraPathFilters filters)
        {
            var result = await _cameraPathService.SearchAsync(filters);
            return Json(result);
        }
        //跟表单有关系进行了数据库的操作
        [HttpPost]
        public async Task<IActionResult> Edit(CameraPathDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            var result = await _cameraPathService.UpdateAsync(dto);
            if (result)
                return RedirectToAction("Index");
            return View(dto);
            
        }
        public async Task<IActionResult> Edit(string id)
        {
            var model = await _cameraPathService.FindAsync(id);
            return View(model);
        }
        public async Task<IActionResult> Check(string id)
        {
            var model = await _cameraPathService.FindAsync(id);
            return View(model);
        }
        public async Task<IActionResult> Check1(string id)
        {
            var model = await _cameraPathService.FindAsync(id);
            return View(model);
        }
        public async Task<IActionResult> Delete([FromBody]IEnumerable<string> ids)
        {
            var result = new JsonResultModel<bool>();
            if (ids.AnyOne())
            {
                result.flag = await _cameraPathService.DeleteAsync(ids);
            }
            return Json(result);
        }
    }
}