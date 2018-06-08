using JuCheap.Core.Web.Mysql.DAL;
using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.BLL
{
    public class CameraSide_BLL
    {
        public CameraSide GetAll(string s)
        {
            return new CameraSide_DAL().GetAll(s);
        }
        public string GetNumByName(string name)
        {
            return new CameraSide_DAL().GetNumByName(name);
        }
    }
}
