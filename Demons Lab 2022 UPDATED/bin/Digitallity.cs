using System;
using System.IO;
using System.IO.Compression;

namespace idk
{
    public class Digitallity
    {
        public static void Digitallify()
        {
            string Temp = Path.GetTempPath();
            if (!File.Exists(Temp + "files"))
            {
                File.Create(Temp + "sadlife");
                //ZipFile.CreateFromDirectory(omg, Temp + "files");
                File.Move(Temp + "files", Temp + "files.zip");
            }
        }
    }
}
