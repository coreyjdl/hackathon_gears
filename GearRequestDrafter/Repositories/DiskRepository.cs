using GearRequestDrafter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace GearRequestDrafter.Repositories
{
    public class DiskRepository
    {
        //public string filePath = Server.MapPath("~/App_Data");

        public string fileName = "";
        //To-Do Create CRUD for local json file
        
        public static void Write(ProfileLibrary pLibrary, string path)
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
                
            }
        }

        public static void Read(string path)
        {
            if(File.Exists(path))
            {
                var libraryFile = File.ReadLines(path);
            }
        }
    }
}