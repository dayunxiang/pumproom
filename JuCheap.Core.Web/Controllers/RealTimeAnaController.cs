using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuCheap.Core.Web.Mysql.BLL;
using JuCheap.Core.Web.Mysql.Model;
using Microsoft.AspNetCore.Mvc;

namespace JuCheap.Core.Web.Controllers
{
    public class RealTimeAnaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RealTimeData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetData2(string sidx, string sord, int page, int rows)
        {
            //string s = sidx + " " + sord + " " + page.ToString() + " " + rows.ToString();

            List<RTData> list =(List<RTData>) new RTData_BLL().GetRTData();

            var jsonData = new
            {

                total = 1, // we'll implement later 。返回的是总共的页数,跟随数据前面的操作而变化
                page = 1,//这个就不用变了，返回的是当前第几页
                records = rows, // implement later 所有的条数，记录中所有的条数。
                //id是当前记录的id号。
                //rows = new[]{
                //new {id = 13, cell = new[] {"13","2007-10-06","Client 3","1000.00","0.00","1000.00",null}},
                //new {id = 12, cell = new[] {"12","2007-10-06","Client 3","1000.00","0.00","1000.00",null}}
                rows=(
                from s in list
                select new
                {
                    id=s.Id,
                    cell=new string[] {
                    s.Id.ToString(),s.分区名称.ToString(),s.站点名称.ToString(),s.上传时间.ToString(),s.进口压力.ToString(),s.出口压力.ToString(),s.设定压力.ToString(),s.变频器1运行频率.ToString(),s.变频器2运行频率.ToString(),s.变频器3运行频率.ToString(),s.变频器4运行频率.ToString(),s.变频器1运行电压.ToString(),s.变频器2运行电压.ToString(),s.变频器3运行电压.ToString(),s.变频器4运行电压.ToString(),s.变频器1运行电流.ToString(),s.变频器2运行电流.ToString(),s.变频器3运行电流.ToString(),s.变频器4运行电流.ToString(),s.变频器1运行温度.ToString(),s.变频器2运行温度.ToString(),s.变频器3运行温度.ToString(),s.变频器4运行温度.ToString(),s.泵1运行电流.ToString(),s.泵2运行电流.ToString(),s.泵3运行电流.ToString(),s.泵4运行电流.ToString(),s.泵5运行电流.ToString(),s.泵6运行电流.ToString(),s.小泵1运行电流.ToString(),s.小泵2运行电流.ToString(),s.系统总电压.ToString(),s.系统总电流.ToString(),s.总电能.ToString(),s.A相电压.ToString(),s.B相电压.ToString(),s.C相电压.ToString(),s.A相电流.ToString(),s.B相电流.ToString(),s.C相电流.ToString(),s.压力传感器量程.ToString(),s.水箱液位高度.ToString(),s.瞬时流量.ToString(),s.正向累计流量.ToString(),s.反向累计流量.ToString(),s.泵房温度.ToString(),s.泵房湿度.ToString(),s.浊度.ToString(),s.余氯.ToString(),s.PH值.ToString(),s.COD.ToString(),s.泵1运行状态.ToString(),s.泵2运行状态.ToString(),s.泵3运行状态.ToString(),s.泵4运行状态.ToString(),s.泵5运行状态.ToString(),s.泵6运行状态.ToString(),s.小泵1运行状态.ToString(),s.小泵2运行状态.ToString(),s.泵1手自动状态.ToString(),s.泵2手自动状态.ToString(),s.泵3手自动状态.ToString(),s.泵4手自动状态.ToString(),s.泵5手自动状态.ToString(),s.泵6手自动状态.ToString(),s.小泵1手自动状态.ToString(),s.小泵2手自动状态.ToString(),s.系统运行状态.ToString(),s.PLC故障状态.ToString(),s.压力报警状态.ToString(),s.水箱缺水状态.ToString(),s.变频器1状态.ToString(),s.变频器2状态.ToString(),s.变频器3状态.ToString(),s.变频器4状态.ToString(),s.阀门开关状态.ToString(),s.阀门到位状态.ToString(),s.停机报警.ToString(),s.泵房进水报警状态.ToString(),s.停电来电报警状态.ToString(),s.门禁报警状态.ToString(),s.烟感报警状态.ToString(),s.污水泵启停状态.ToString(),s.故障复位操作.ToString(),s.上位机控制下位机系统.ToString(),s.控制参数修改确认键.ToString(),s.阀门开关控制.ToString(),s.远程设定压力.ToString(),s.加泵频率.ToString(),s.减泵频率.ToString(),s.加泵时间.ToString(),s.减泵时间.ToString(),s.换泵时间.ToString(),s.睡眠频率.ToString(),s.睡眠延时.ToString(),s.唤醒值设定.ToString(),s.负压报警值设定.ToString(),s.负压停止延时.ToString(),s.超压警值设定.ToString(),s.超压停止延时.ToString(),s.泵1启停控制.ToString(),s.泵2启停控制.ToString(),s.泵3启停控制.ToString(),s.泵4启停控制.ToString(),s.泵5启停控制.ToString(),s.泵6启停控制.ToString(),s.小泵1启停控制.ToString(),s.小泵2启停控制.ToString()}
                }).ToArray()
                
            };
            return Json(jsonData);
        }
    }
}