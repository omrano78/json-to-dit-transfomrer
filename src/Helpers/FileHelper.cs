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
        public static void WriteToFile(string data)
        {
            var output = "output.xml";
            var dirName = "output";
            CreateDirectoryIfNotExist(dirName);
            using (StreamWriter file = File.CreateText(Path.Combine(dirName, output)))
            {
                file.WriteLine(data);
            }
        }
    }
}
