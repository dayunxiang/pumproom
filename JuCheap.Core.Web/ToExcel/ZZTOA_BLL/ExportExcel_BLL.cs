using JuCheap.Core.Web.Mysql.Model;
using JuCheap.Core.Web.ToExcel.ZZTOA_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.ToExcel.ZZTOA_BLL
{
    public class ExportExcel_BLL
    {

        /// <summary>
        /// 将泵房的数据导出
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="list">baseall的list</param>
        /// <param name="type"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ReturnMsg ExportMs(ref MemoryStream ms,List<BaseAll> list,int type=0,string path="")
        {
            ReturnMsg rm = ZZTOA_DAL.ExportExcel_DAL.ExportList(ref ms, list, type, path);
            return rm;
        }
    }
}
