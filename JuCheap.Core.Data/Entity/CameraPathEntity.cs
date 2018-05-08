using System;
using System.Collections.Generic;
using System.Text;

namespace JuCheap.Core.Data.Entity
{
    public class CameraPathEntity:BaseEntity
    {
        public string Ip
        {
            get;set;
        }
        public string Port
        {
            get;set;
        }
        public string Pwd
        {
            get;set;
        }
        public string LoginName
        {
            get;set;
        }
        //信息，不小心小写了
        public string info
        {
            get;set;
        }
        public string PumpRoomId
        {
            get;set;
        }
        //泵房名称
        public string PumpRoomName
        {
            get;set;
        }

    }
}
