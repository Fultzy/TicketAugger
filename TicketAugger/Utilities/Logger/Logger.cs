using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAugger.Utilities
{
    public static class Logger
    {

        // Example usage:

        // Logger.Debugging("This is a debug message");

        // This error message will be written to the Error log and Import log
        // throw new Exception(Logger.Error(Logger.Importing(errorMessage)));


    public static void CheckAllLogFiles(string path)
        {
            var cutOff = DateTime.Now.AddDays(-1);

            Console.WriteLine("Checking Logs...");

            CheckLogFile(path + @"\Logs\dbLog.txt", cutOff);
            CheckLogFile(path + @"\Logs\ErrorLog.txt", cutOff);
            CheckLogFile(path + @"\Logs\DebugLog.txt", cutOff);
            CheckLogFile(path + @"\Logs\ImportLog.txt", cutOff);
        }


        private static void CheckLogFile(string filePath, DateTime cutOff)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            else if (File.GetCreationTime(filePath) < cutOff)
            {
                // check if the archive folder exists
                string archiveFolderPath = Directory.GetCurrentDirectory() + @"\Logs\Archive";
                if (!Directory.Exists(archiveFolderPath))
                {
                    Directory.CreateDirectory(archiveFolderPath);
                }

                // move the file to the archive folder
                string archiveFilePath = Path.Combine(archiveFolderPath, $"{Path.GetFileNameWithoutExtension(filePath)}_{DateTime.Now.ToString("yyMMdd HHmmss")}.txt");

                File.Move(filePath, archiveFilePath);
                File.Create(filePath).Close();
            }
        }


        private static void Write(DateTime logTime, string logPath, string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"{logTime}: {message}");
                }
            }
            catch (Exception ex)
            {
                int maxRetries = 3;
                int retryCount = 0;
                bool retry = true;

                while (retry && retryCount < maxRetries)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(logPath, true))
                        {
                            writer.WriteLine($"{logTime}: {message}");
                        }

                        retry = false;
                    }
                    catch (Exception)
                    {
                        retryCount++;
                    }
                }

                if (retryCount == maxRetries)
                {
                    throw new Exception(ex.Message + $" Could Not Add To {Path.GetFileName(logPath)}!");
                }
            }
        }


        public static string Debugging(string message, string prefix = "")
        {
            string logPath = Directory.GetCurrentDirectory() + @"\Logs\Debugging.txt";

            message = prefix != "" ? $"{prefix} : {message}" : $"DeBug : {message}";
            Write(DateTime.Now, logPath, message);

            return message;
        }

        public static string Database(string message, string prefix = "")
        {
            string logPath = Directory.GetCurrentDirectory() + @"\Logs\dbLog.txt";

            message = prefix != "" ? $"{prefix} : {message}" : $"DATABASE : {message}";
            Write(DateTime.Now, logPath, message);

            return message;
        }

        public static string Importing(string message, string prefix = "")
        {
            string logPath = Directory.GetCurrentDirectory() + @"\Logs\ImportLog.txt";

            message = prefix != "" ? $"{prefix} : {message}" : $"IMPORTING : {message}";
            Write(DateTime.Now, logPath, message);

            return message;
        }

        public static string Error(string message, string prefix = "")
        {
            string logPath = Directory.GetCurrentDirectory() + @"\Logs\ErrorLog.txt";

            message = prefix != "" ? $"{prefix} : {message}" : $"!!ERROR!! : {message}";
            Write(DateTime.Now, logPath, message);

            return message;
        }

        public static string Warning(string message, string prefix = "")
        {
            string logPath = Directory.GetCurrentDirectory() + @"\Logs\ErrorLog.txt";

            message = prefix != "" ? $"{prefix} : {message}" : $"WARNING : {message}";
            Write(DateTime.Now, logPath, message);

            return message;
        }
    }
}
