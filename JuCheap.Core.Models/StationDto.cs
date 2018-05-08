using System.ComponentModel.DataAnnotations;

namespace JuCheap.Core.Models
{
    public class StationDto
    {
        public string Id
        {
            get;set;
        }
        [Display(Name = "分区名称"), Required, MinLength(1)]
        public string 分区名称
        {
            get; set;
        }
        [Display(Name = "分区类型"),Required, MinLength(1)]
        public string 分区类型
        {
            get; set;
        }
        [Display(Name = "站点名称"), Required, MinLength(1)]
        public string 站点名称
        {
            get; set;
        }
        [Display(Name = "站点编号"), Required, MinLength(1)]
        public string 站点编号
        {
            get; set;
        }
        [Display(Name = "编号")]
        public string 编号
        {
            get; set;
        }
        [Display(Name = "站点全名")]
        public string 站点全名
        {
            get; set;
        }
        [Display(Name = "站点类型"), Required, MinLength(1)]
        public string 站点类型
        {
            get; set;
        }
        [Display(Name = "分区内排序"), Required]
        public int 分区内排序
        {
            get; set;
        }
    }
}