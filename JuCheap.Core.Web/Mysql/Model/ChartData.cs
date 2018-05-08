using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.Model
{
    /// <summary>
    /// 用于传递图表所需要的数据的种类。AllData中的chart所用
    /// </summary>
    public class ChartData
    {
        public string 进口压力
        {
            get;set;
        }
        public string 出口压力
        {
            get;set;
        }
    }
}
