using JuCheap.Core.Web.Mysql.DAL;
using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.BLL
{
    public class ChartData_BLL
    {
        public IEnumerable<ChartData> GetToday(string tablename)
        {
            return new ChartData_DAL().GetToday(tablename);
        }
    }
}
