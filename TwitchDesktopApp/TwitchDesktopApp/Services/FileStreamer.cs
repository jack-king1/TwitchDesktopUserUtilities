using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TwitchDesktopApp.Services
{
    public static class FileStreamer
    {
        //public static bool FileExists(string fileName)
        //{
        //    string path = Application.persistentDataPath + ("/" + fileName + ".json");
        //    return File.Exists(path);
        //}

        //public static void SaveIntoJson<T>(string fileName, T gameData)
        //{
        //    Debug.Log("Saving to: " + (Application.persistentDataPath + "/" + fileName));
        //    string json = JsonUtility.ToJson(gameData);
        //    System.IO.File.WriteAllText(Application.persistentDataPath + "/" + fileName + ".json", json);
        //}

        //public static T LoadJson<T>(string fileName)
        //{
        //    string json = File.ReadAllText(Application.persistentDataPath + "/" + fileName + ".json");
        //    return JsonUtility.FromJson<T>(json);
        //}
    }
}
