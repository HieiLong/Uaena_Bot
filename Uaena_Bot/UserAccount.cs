using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uaena_Bot
{
    public class UserAccount
    {
        // DEBUGGER - Account Settings
        private string userName = "";
        private string channel = "";
        private string twitchOAuth = ""; // chatbot's oauth from www.twitchapps.com/tmi/

        public string GetUserName()
        {
            return userName;
        }

        public string GetChannel()
        {
            return channel;
        }

        public string GetTwitchOAuth()
        {
            return twitchOAuth;
        }
    }
}
