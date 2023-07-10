using System;

namespace web_api.Configurations
{
    public class Log
    {
        public static string getFullPath()
        {
            string fileName = $"{DateTime.Now.ToString("dd-MM-yyyy")}.txt";
            string path = System.Configuration.ConfigurationManager.AppSettings["loja-caminho-arquivo-log"];
            string fullPath = System.IO.Path.Combine(path, fileName);

            return fullPath;
        }
    }
}