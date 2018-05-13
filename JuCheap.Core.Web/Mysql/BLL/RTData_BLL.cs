using JuCheap.Core.Web.Mysql.DAL;
using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.BLL
{
    public class RTData_BLL
    {
        public IEnumerable<RTData> GetRTData()
        {
            return new RTData_DAL().GetRTData();
        }
    }
}
