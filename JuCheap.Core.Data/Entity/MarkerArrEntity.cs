using System;
using System.Collections.Generic;
using System.Text;

namespace JuCheap.Core.Data.Entity
{
    public class MarkerArrEntity
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
        public int isOnline { get; set; }
    }
}
