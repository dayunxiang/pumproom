using JuCheap.Core.Web.Mysql.DAL;
using JuCheap.Core.Web.Mysql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.BLL
{
    public class BaseAll_BLL
    {
        public IEnumerable<BaseAll> GetAll(string s)
        {
            return new BaseAll_DAL().GetAll(s);
        }
        public IEnumerable<BaseAll1> GetDiffer()
        {
            return new BaseAll_DAL().GetDiffer();
        }
        //通过站点名称获取编号
        public string GetNumberByName(string s)
        {
            return new BaseAll_DAL().GetNumberByName(s);
        }
        public BaseAll GetByName(string s)
        {
            return new BaseAll_DAL().GetByName(s);
        }
        public IEnumerable<string> GetDataByDay(string tablename, string fieldname, int day)
        {
            return new BaseAll_DAL().GetDataByDay(tablename, fieldname, day);
        }

        public IEnumerable<BaseAll> GetAllByTime(string tablename, DateTime time)
        {
            return new BaseAll_DAL().GetAllByTime(tablename, time);
        }
        public IEnumerable<BaseAll> GetDataByDate(string tablename, string time)
        {
            return new BaseAll_DAL().GetDataByDate(tablename, time);
        }
    }
}
