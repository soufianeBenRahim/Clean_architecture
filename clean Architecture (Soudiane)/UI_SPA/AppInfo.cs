using Clean_Architecture_Soufiane.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_SPA
{
    public class AppInfo : IAppInfo
    {
        public string getAppName()
        {
            return Program.AppName;
        }

        public string GetAppNameSpace()
        {
            return Program.Namespace;
        }
    }
}
