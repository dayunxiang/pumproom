using JuCheap.Core.Web.Mysql.DAL;
using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.BLL
{
    public class CeShi_BLL
    {

        public IEnumerable<CeShi> GetAll(string s)
        {
            return new CeShi_DAL().GetAll(s);
        }
        public IEnumerable<CeShi> FenYeGet(int page, int rows, string s)
        {
            return new CeShi_DAL().FenYeGet(page, rows, s);
        }

        public IEnumerable<CeShi1> GetDiffer()
        {
            return new CeShi_DAL().GetDiffer();
        }
    }
}
