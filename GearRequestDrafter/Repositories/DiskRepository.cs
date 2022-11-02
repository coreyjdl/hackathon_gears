using GearRequestDrafter.Models;
using System.IO;
using System.Text;
using System.Web;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GearRequestDrafter.Repositories
{
    public class DiskRepository : IDiskRepository
    {
        private readonly string filePath = HttpContext.Current.Server.MapPath("~/App_Data/");
        private readonly string fileName = "profileLibrary.json";

        private string path;

        public DiskRepository()
        {
            //TODO: allow path params 
            path = filePath + fileName;
        }


        public void Write(ProfileLibrary pLibrary)
            {
                //Create File if it does not exist
                if (!File.Exists(path))
                {
                    // Create the file.
                    using (var fs = File.Create(path))
                    {
                        var info = new UTF8Encoding(true).GetBytes("This is some text in the file.");

                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }

                else
                {
                    if(pLibrary != null)
                    {
                        File.Delete(path);
                        using (var fs = File.Create(path))
                        {
                            var info = new UTF8Encoding(true).GetBytes(JsonSerializer.Serialize(pLibrary));

                            // Add some information to the file.
                            fs.Write(info, 0, info.Length);
                        }
                    }

                }
            }

        public ProfileLibrary Read()
        {
            var pLibrary = new ProfileLibrary();
            if (File.Exists(path))
            {
                var jsonFile = File.ReadAllText(path);
                pLibrary = JsonSerializer.Deserialize<ProfileLibrary>(jsonFile);
            }

            return pLibrary;
        }
    }
}