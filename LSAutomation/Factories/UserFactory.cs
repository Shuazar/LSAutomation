using LSAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LSAutomation.Factories
{
   public static class UserFactory
    {
        public static User GetUser()
        {
            var document = XDocument.Load("FacebookUsers.xml");
            var user = new User();
            foreach (var userData in document.Root.Elements("User"))
            {

                var userName = userData.Attribute("username").Value;
                user.Username = userName;
                var password = userData.Attribute("password").Value;
                user.Password = password;
            }
            return user;
        }
    }
}
