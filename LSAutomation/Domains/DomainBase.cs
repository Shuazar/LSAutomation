using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.Domains
{
    public abstract class DomainBase
    {
        protected readonly Automation Automation;

        protected DomainBase(Automation automation)
        {
            Automation = automation;
        }
    }
}

