using System;
using System.IO;
using System.Text;

namespace Logger
{
    public class Log
    {
        public static void write(Exception ex, String fullPath)
        {
            using(StreamWriter sw = new StreamWriter(fullPath, true))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Date: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}\n");
                sb.Append($"Message: {ex.Message}\n");
                sb.Append($"StackTrace: {ex.StackTrace}\n");
                sb.Append($"InnerException: {ex.InnerException}\n");
                sb.Append($"Type of error: {ex.GetType()}\n");
                sb.Append($"Source: {ex.Source}\n");
                sb.Append($"TargetSite: {ex.TargetSite}\n");
                sb.Append("\n--------------------------\n");

                sw.WriteLine(sb.ToString());
            }
        }
    }
}
