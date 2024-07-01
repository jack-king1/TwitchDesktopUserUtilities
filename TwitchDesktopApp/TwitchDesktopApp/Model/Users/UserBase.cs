using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDesktopApp.Model.Users
{
    //A class to hold data about the loggedin twitch user.
    //E.g. username, picture, current stream
    abstract class UserBase
    {

        private int _id = -1;

        [BsonId]
        public int TwitchID
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        private string _username = "No Name";

        public string TwitchUsername
        {
            get { return _username; }
            set
            {
                _username = value;
            }
        }


        public abstract void SaveUserToDB();
    }
}
