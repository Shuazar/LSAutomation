using Common;
using LSAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.Pages
{
    public abstract class HomePageBase : PageBase
    {
        public HomePageBase(Browser browser) : base(browser)
        {

        }
        public abstract void OpenHomePage(string url);
        public abstract void Login(User user);
        public abstract string GetDataSiteKey();

    }
}
