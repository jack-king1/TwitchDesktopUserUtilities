using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDesktopApp.Model.Users
{
    public class UserViewer : UserBase
    { 

        public UserViewer() { }
    
        public UserViewer(string username, int id = -1)
        {
            TwitchID = id;
            TwitchUsername = username;
        }
    }
}
