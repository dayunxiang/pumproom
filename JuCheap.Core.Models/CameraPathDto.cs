using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JuCheap.Core.Models
{
    public class CameraPathDto
    {
        public string Id
        {
            get;set;
        }
        [Display(Name ="监控的IP地址"),Required, MinLength(5)]
        public string Ip
        {
            get;set;
        }
        [Display(Name ="端口号"),Required,MinLength(1)]
        public string Port
        {
            get;set;
        }
        [Display(Name ="监控密码"),Required,MinLength(1)]
        public string Pwd
        {
            get;set;
        }
        [Display(Name = "监控用户名"),Required,MinLength(1)]
        public string LoginName
        {
            get;set;
        }
        [Display(Name = "信息"),Required,MinLength(1)]
        public string info
        {
            get;set;
        }
        [Display(Name = "泵房ID")]
        public string PumpRoomId
        {
            get;set;
        }
        [Display(Name = "泵房名称"),Required,MinLength(1)]
        public string PumpRoomName
        {
            get;set;
        }
        


    }
}
