using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture_Soufiane.Application
{
    public interface IAppInfo
    {
        public  string getAppName();
        public string  GetAppNameSpace();
    }
}
