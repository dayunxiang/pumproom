using JuCheap.Core.Web.Mysql.DAL;
using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.BLL
{
    public class MasterData_BLL
    {
        public MasterData GetMasterData(string tablename)
        {
            return new MasterData_DAL().GetMasterData(tablename);
        }
        //根据站点名称获取泵站路由器的ip地址。
        public string GetIpByName(string name)
        {
            return new MasterData_DAL().GetIpByName(name);
        }
    }
}
