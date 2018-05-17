using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.Model
{
    public class GisData
    {
        public int id { get; set; }
        public string title { get; set; }
        public string elecname { get; set; }
        public string electricity { get; set; }
        public string watername { get; set; }
        public string water { get; set; }
        public string airname { get; set; }
        public string air { get; set; }
        public string alarmname { get; set; }
        public string alarm { get; set; }
        public string point { get; set; }
        public string isOnline { get; set; }
        public string beiyong1 { get; set; }
        public string beiyong2 { get; set; }
    }
}
