using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using JuCheap.Core.Data;
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
        public IActionResult Index(string s)
        {
            ViewData["Name"] = s;
            return View();
        }
        public async Task<IActionResult> List()
        {
            return View(await _context.Stations.Where(item => !item.IsDeleted).ToListAsync());
        }

        [HttpPost]
        public async Task<JsonResult> GetData(string s)
        {
            //ServiceReference1.Service1Client sa = new ServiceReference1.Service1Client();
            //string wcfdata = await sa.GetDataAsync(s);
            //string wcfdata = sa.GetData(Convert.ToInt32(s));
            //string url = "http://192.168.1.109:8045/Service1.svc";
            //IService1 proxy = WcfInvokeFactory.CreateServiceByUrl<IService1>(url);
            //int result = proxy.Add(1, 3);
            //string wcfdata = ExecuteMethod<IService1>("net.tcp://192.168.0.109:8045/Service1", "GetData", new object[] { 123 }).ToString();

            //MyServiceReference.MyServiceClient sa = new MyServiceReference.MyServiceClient();
            //string wcfdata = await sa.GetDataAsync(s);
            string url = "http://192.168.1.109:8045/MyService.svc";
            IMyService proxy = WcfInvokeFactory.CreateServiceByUrl<IMyService>(url);
            string wcfdata = proxy.GetData(s);
            //Console.WriteLine(result);
            return Json(new { IsSuccess = true, wcfdata });


        }

        //public interface IService1
        //{
        //    string GetData(int value);
            
        //}

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