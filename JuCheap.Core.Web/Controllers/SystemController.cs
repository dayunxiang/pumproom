﻿
using System.Threading.Tasks;
using JuCheap.Core.Interfaces;
using JuCheap.Core.Web.Filters;
using JuCheap.Core.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JuCheap.Core.Web.Controllers
{
    /// <summary>
    /// 系统管理
    /// </summary>
    [Authorize]
    public class SystemController : Controller
    {
        private readonly IDatabaseInitService _databaseInitService;

        public SystemController(IDatabaseInitService databaseInitService)
        {
            _databaseInitService = databaseInitService;
        }

        /// <summary>
        /// 系统管理首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 重置路径码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReloadPathCode()
        {
            var result = new JsonResultModel<bool>
            {
                flag = await _databaseInitService.InitPathCodeAsync()
            };
            return Json(result);
        }

        /// <summary>
        /// 初始化省市区数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [IgnoreRightFilter]
        public async Task<JsonResult> ReInitAreas()
        {
            var result = new JsonResultModel<bool>
            {
                flag = await _databaseInitService.InitAreas()
            };
            return Json(result);
        }
    }
}