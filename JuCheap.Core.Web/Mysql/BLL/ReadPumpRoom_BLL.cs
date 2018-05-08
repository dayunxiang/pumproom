using JuCheap.Core.Web.Mysql.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.BLL
{
    public class ReadPumpRoom_BLL
    {
        public IEnumerable<string> ReadPumpRoom()
        {
            return new ReadPumpRoom_DAL().ReadPumpRoom();
        }

    }
}
