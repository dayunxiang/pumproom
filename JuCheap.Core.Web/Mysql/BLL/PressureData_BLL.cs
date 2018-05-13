using JuCheap.Core.Web.Mysql.DAL;
using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.BLL
{
    public class PressureData_BLL
    {
        public IEnumerable<PressureData> GetPressureAna()
        {
            return new PressureData_DAL().GetPressureAna();
        }
    }
}
