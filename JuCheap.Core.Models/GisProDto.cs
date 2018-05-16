using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JuCheap.Core.Models
{
    public class GisProDto
    {
        public string Id
        {
            get;set;
        }
        [Display(Name = "站点名称"), Required, MinLength(1)]
        public string 站点名称
        {
            get;set;
        }
        [Display(Name ="分区名称"),Required,MinLength(1)]
        public string 分区名称
        {
            get;set;
        }
        [Display(Name = "泵个数name"), Required, MinLength(1)]
        public string 泵个数name
        {
            get;set;
        }
        [Display(Name = "泵个数"), Required,MinLength(1)]
        public string 泵个数
        {
            get;set;
        }
        [Display(Name = "状态信息name") ,Required,MinLength(1)]
        public string 状态信息name
        {
            get;set;
        }
        [Display(Name = "状态信息"),Required,MinLength(1)]
        public string 状态信息
        {
            get;set;
        }
        [Display(Name = "报警信息name"), Required, MinLength(1)]
        public string 报警信息name
        {
            get; set;
        }
        [Display(Name = "报警信息"), Required, MinLength(1)]
        public string 报警信息
        {
            get; set;
        }
        [Display(Name = "坐标"),Required,MinLength(1)]
        public string 坐标
        {
            get;set;
        }
        [Display(Name = "泵表编号"),Required,MinLength(1)]
        public string 泵表编号
        {
            get;set;
        }
        [Display(Name ="备用1")]
        public string 备用1
        {
            get;set;
        }
        [Display(Name = "备用2")]
        public string 备用2
        {
            get; set;
        }
        [Display(Name = "备用3")]
        public string 备用3
        {
            get; set;
        }
        [Display(Name = "备用4")]
        public string 备用4
        {
            get; set;
        }
    }
}
