using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using TwitchDesktopApp.Model.Users;

namespace TwitchDesktopApp.Model.Database
{
    public static class Database
    {
        public static void CreateDB()
        {
            // Specify the database file path
            string connectionString = @"C:\MyData.db";

            UserViewer viewer = new UserViewer("shroud", 1);

            // Create or open a LiteDB database
            using (var db = new LiteDatabase(connectionString))
            {
                // Access a collection (or create, if it doesn't exist)
                var col = db.GetCollection<UserViewer>("Viewers");

                // Check if a viewer with the same TwitchId already exists
                if (col.FindById(viewer.TwitchID) == null)
                {
                    // Insert the viewer object into the collection
                    col.Insert(viewer);

                    // Print a success message
                    Console.WriteLine("Viewer inserted into the database with TwitchID: " + viewer.TwitchID);
                }
                else
                {
                    Console.WriteLine("A viewer with the same TwitchID already exists.");
                }
            }
        }
    }


}
