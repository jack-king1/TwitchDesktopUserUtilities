using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDesktopApp.Model.Users
{
    public class UserAdmin : UserBase
    {
        public UserAdmin() { }

        public UserAdmin(TwitchUserDataList _data)
        {
            Data = _data;
        }

    }
}
