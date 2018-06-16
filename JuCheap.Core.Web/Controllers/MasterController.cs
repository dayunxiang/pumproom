using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using JuCheap.Core.Data;
using JuCheap.Core.Web.Mysql.BLL;
using JuCheap.Core.Web.Mysql.Model;
using JuCheap.Core.Web.WcfSevice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace JuCheap.Core.Web.Controllers
{
    public class MasterController : Controller
    {
        private readonly JuCheapContext _context;
        public MasterController(JuCheapContext context)
        {
            _context = context;
        }
        public IActionResult Index(string s,string x,string y)
        {
            //s就是泵站的站点名称
            ViewData["Name"] = s+" |类型："+y;
            ViewData["Type"] = y;
            string Tablename = "pumproom" + x;
            MasterData md = new MasterData_BLL().GetMasterData(Tablename);   
            return View(md);
        }
        public async Task<IActionResult> List()
        {
            return View(await _context.Stations.Where(item => !item.IsDeleted).ToListAsync());
        }

        //[HttpPost]
        //public async Task<JsonResult> GetData(string s)
        //{
        //    //ServiceReference1.Service1Client sa = new ServiceReference1.Service1Client();
        //    //string wcfdata = await sa.GetDataAsync(s);
        //    //string wcfdata = sa.GetData(Convert.ToInt32(s));
        //    //string url = "http://192.168.1.109:8045/Service1.svc";
        //    //IService1 proxy = WcfInvokeFactory.CreateServiceByUrl<IService1>(url);
        //    //int result = proxy.Add(1, 3);
        //    //string wcfdata = ExecuteMethod<IService1>("net.tcp://192.168.0.109:8045/Service1", "GetData", new object[] { 123 }).ToString();

        //    //MyServiceReference.MyServiceClient sa = new MyServiceReference.MyServiceClient();
        //    //string wcfdata = await sa.GetDataAsync(s);
        //    string url = "http://192.168.1.109:8045/MyService.svc";
        //    IMyService proxy = WcfInvokeFactory.CreateServiceByUrl<IMyService>(url);
        //    string wcfdata = proxy.GetData(s);
        //    //Console.WriteLine(result);
        //    return Json(new { IsSuccess = true, wcfdata });


        //}

            //控制门禁的。
        [HttpPost]
        public JsonResult GetData(string num,string name)
        {


            //string wcfdata = "hello"+num;
            //从这里进行查询
            //string url = "http://192.168.2.7:8072/Service1.svc";
            string ip= new MasterData_BLL().GetIpByName(name);
            string port = "8084";
            string url= "http://" + ip + ":" + port + "/Service1.svc";
            IService1 proxy = WcfInvokeFactory.CreateServiceByUrl<IService1>(url);
            //string wcfdata = proxy.GetData(s);
            //Console.WriteLine(result);
            string wcfdata = proxy.ControlLock()+"hello"+num;
            return Json(new { IsSuccess = true, wcfdata });
            //return Json(new { IsSuccess = true, wcfdata });
        }
        //测试plc开关的。
        /// <summary>
        /// 作为示例自动查找泵站的ip地址。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetData1(string name,string data)
        {
            //string wcfdata = "hello,this is second   "+data;
            //需要将泵站的名称传过来。
            string port = "8084";
            string ip = new MasterData_BLL().GetIpByName(name);
            string url = "http://" + ip + ":" + port + "/Service1.svc";
            //string url= "http://192.168.1.101:8051/Service1.svc";
            IService1 proxy = WcfInvokeFactory.CreateServiceByUrl<IService1>(url);
            string wcfdata = proxy.GetData( Convert.ToInt32(data)) + "hello" + data;
            return Json(new { IsSuccess = true, wcfdata});
        }
        //public interface IService1
        //{
        //    string GetData(int value);
            
        //}

        [HttpPost]
        public JsonResult Control(string name,string type,string data,string pumpname)
        {
            string port = "8072";
            string ip = new MasterData_BLL().GetIpByName(name);
            string url = "http://" + ip + ":" + port + "/Service1.svc";
            //IService1 proxy = WcfInvokeFactory.CreateServiceByUrl<IService1>(url);
            //string wcfdata = proxy.GetData(Convert.ToInt32(data)) + "hello" + data;
            string wcfdata = url + "  " + name + "  " + data + "  " + pumpname+"    "+type;
            return Json(new { IsSuccess = true, wcfdata });
        }

        //public class WcfInvokeFactory
        //{
        //    #region WCF服务工厂
        //    public static T CreateServiceByUrl<T>(string url)
        //    {
        //        return CreateServiceByUrl<T>(url, "basicHttpBinding");
        //    }

        //    public static T CreateServiceByUrl<T>(string url, string bing)
        //    {
        //        try
        //        {
        //            if (string.IsNullOrEmpty(url)) throw new NotSupportedException("This url is not Null or Empty!");
        //            EndpointAddress address = new EndpointAddress(url);
        //            Binding binding = CreateBinding(bing);
        //            ChannelFactory<T> factory = new ChannelFactory<T>(binding, address);
        //            return factory.CreateChannel();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("创建服务工厂出现异常.");
        //        }
        //    }
        //    #endregion

        //    #region 创建传输协议
        //    /// <summary>
        //    /// 创建传输协议
        //    /// </summary>
        //    /// <param name="binding">传输协议名称</param>
        //    /// <returns></returns>
        //    private static Binding CreateBinding(string binding)
        //    {
        //        Binding bindinginstance = null;
        //        if (binding.ToLower() == "basichttpbinding")
        //        {
        //            BasicHttpBinding ws = new BasicHttpBinding();
        //            ws.MaxBufferSize = 2147483647;
        //            ws.MaxBufferPoolSize = 2147483647;
        //            ws.MaxReceivedMessageSize = 2147483647;
        //            ws.ReaderQuotas.MaxStringContentLength = 2147483647;
        //            ws.CloseTimeout = new TimeSpan(0, 30, 0);
        //            ws.OpenTimeout = new TimeSpan(0, 30, 0);
        //            ws.ReceiveTimeout = new TimeSpan(0, 30, 0);
        //            ws.SendTimeout = new TimeSpan(0, 30, 0);

        //            bindinginstance = ws;
        //        }
        //        else if (binding.ToLower() == "nettcpbinding")
        //        {
        //            NetTcpBinding ws = new NetTcpBinding();
        //            ws.MaxReceivedMessageSize = 65535000;
        //            ws.Security.Mode = SecurityMode.None;
        //            bindinginstance = ws;
        //        }
        //        //else if (binding.ToLower() == "wshttpbinding")
        //        //{
        //        //    WSHttpBinding ws = new WSHttpBinding(SecurityMode.None);
        //        //    ws.MaxReceivedMessageSize = 65535000;
        //        //    ws.Security.Message.ClientCredentialType = System.ServiceModel.MessageCredentialType.Windows;
        //        //    ws.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Windows;
        //        //    bindinginstance = ws;
        //        //}
        //        return bindinginstance;

        //    }
        //    #endregion
        //}
        //public static object ExecuteMethod<T>(string pUrl, string pMethodName, params object[] pParams)
        //{
        //    EndpointAddress address = new EndpointAddress(pUrl);
        //    Binding bindinginstance = null;
        //    NetTcpBinding ws = new NetTcpBinding();
        //    ws.MaxReceivedMessageSize = 20971520;
        //    ws.Security.Mode = SecurityMode.None;
        //    bindinginstance = ws;
        //    using (ChannelFactory<T> channel = new ChannelFactory<T>(bindinginstance, address))
        //    {
        //        T instance = channel.CreateChannel();
        //        using (instance as IDisposable)
        //        {
        //            try
        //            {
        //                Type type = typeof(T);
        //                MethodInfo mi = type.GetMethod(pMethodName);
        //                return mi.Invoke(instance, pParams);
        //            }
        //            catch (TimeoutException)
        //            {
        //                (instance as ICommunicationObject).Abort();
        //                throw;
        //            }
        //            catch (CommunicationException)
        //            {
        //                (instance as ICommunicationObject).Abort();
        //                throw;
        //            }
        //            catch (Exception vErr)
        //            {
        //                (instance as ICommunicationObject).Abort();
        //                throw;
        //            }
        //        }
        //    }
        //}
    }
}