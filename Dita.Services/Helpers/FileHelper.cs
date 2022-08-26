using System.IO;

namespace Dita.Services.Helpers
{
    public static class FileHelper
    {
        public static void CreateDirectoryIfNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static void WriteToFile(string data, string path)
        {
            var output = AppConst.OUTPUT_FILE_NAME;
            CreateDirectoryIfNotExist(path);
            using (StreamWriter file = File.CreateText(Path.Combine(path, output)))
            {
                file.WriteLine(data);
            }
        }
    }
}
