using JuCheap.Core.Web.Mysql.DAL;
using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.BLL
{
    public class GisData_BLL
    {
        public IEnumerable<GisData> GetAll()
        {
            return new GisData_DAL().GetAll();
        }
    }
}
