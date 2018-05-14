using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.WcfSevice
{
    
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            string GetData(int value);

            [OperationContract]
            string ControlLock();

            // TODO: 在此添加您的服务操作
        }
    
}
