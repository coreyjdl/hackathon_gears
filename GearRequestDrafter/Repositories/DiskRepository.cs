using GearRequestDrafter.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Web;
using System.Web.Mvc;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GearRequestDrafter.Repositories
{
    public class DiskRepository
    {
        private static string filePath = HttpContext.Current.Server.MapPath("~/App_Data/");
        private static string fileName = "profileLibrary.json";
        private static string path = filePath + fileName;
        
        public static void Write(ProfileLibrary pLibrary)
        {
            //Create File if it does not exist
            if (!File.Exists(path))
            {
                // Create the file.
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }

            else
            {
                if(pLibrary != null)
                {
                    File.Delete(path);
                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(JsonSerializer.Serialize(pLibrary));

                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }

            }
        }

        public static ProfileLibrary Read()
        {
            ProfileLibrary pLibrary = new ProfileLibrary();
            if (File.Exists(path))
            {
                string jsonFile = File.ReadAllText(path);
                pLibrary = JsonSerializer.Deserialize<ProfileLibrary>(jsonFile);
            }

            return pLibrary;
        }
    }
}