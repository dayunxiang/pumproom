using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.WcfSevice
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        string GetData(string value);

    }
}
