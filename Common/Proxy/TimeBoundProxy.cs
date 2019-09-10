using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Proxy
{
    public class TimeBoundProxy
    {
        public string IpProxy { get; set; }
        public DateTime LastTimeOfUse { get; set; }

        public TimeBoundProxy(string ipProxy)
        {
            IpProxy = ipProxy;
        }
    }
}
