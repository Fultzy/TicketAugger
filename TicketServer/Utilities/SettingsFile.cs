using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketServer.Properties;

namespace TicketServer.Utilities
{
    /// <summary>
    /// Allows for loading settings from a file.  
    /// Settings are stored in a settings.txt file and are accessed through TicketAugger.Properties during runtime
    /// </summary>
    static class SettingsFile
    {
        /// <summary>
        /// Save the settings to the settings.txt file.
        /// </summary>
        public static void Save()
        {
            var path = Directory.GetCurrentDirectory();
            var settingsPath = path + @"\Settings.txt";

            // write the current settings to the file
            using (StreamWriter sw = new StreamWriter(settingsPath))
            {
                sw.WriteLine("// Server Address Settings");

                
                sw.WriteLine("\n// User Preferences");
                sw.WriteLine("Dark_mode = " + Settings.Default.Dark_mode);
                sw.WriteLine("Save_username = " + Settings.Default.Save_username);
                sw.WriteLine("Saved_username = " + Settings.Default.Saved_username);


                // add more settings here
            
            }
        }

        /// <summary>
        /// Apply the settings from file to the program settings.
        /// </summary>
        public static void Apply()
        {
            // Load the settings from the settings.txt file
            var loadedSettings = Load();

            // Apply the loaded settings to the program
            Settings.Default.Dark_mode = bool.Parse(loadedSettings["Dark_mode"]);
            Settings.Default.Save_username = bool.Parse(loadedSettings["Save_username"]);
            Settings.Default.Saved_username = loadedSettings["Saved_username"];

            // add more settings here
            
            
            // Save the changes to the settings
            Settings.Default.Save();

        }


        /// <summary>
        /// Load the settings from the settings.txt file.
        /// Example: "default_dateRange = 7 // The default date range for reports"
        /// </summary>
        /// <returns>Dictionary(Setting, Value) </returns>
        private static Dictionary<string, string> Load()
        {
            var path = Directory.GetCurrentDirectory();
            var settingsPath = path + @"\Settings.txt";

            // check if the settings file exists
            CheckFile(settingsPath);

            // open the file and read the settings into a dictionary
            Dictionary<string, string> settings = new Dictionary<string, string>();
            using (StreamReader sr = new StreamReader(settingsPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // ignore anything after "//"
                    if (line.Contains("//")) line = line.Substring(0, line.IndexOf("//"));

                    // if the line is empty, skip it
                    if (line == "") continue;

                    // split the line into key and value
                    string[] splitLine = line.Split('=');

                    // add the key and value to the dictionary
                    settings.Add(splitLine[0].Trim(), splitLine[1].Trim());
                }

                return settings;
            }
        }

        /// <summary>
        /// Check if the settings file exists, if not create it and write the default settings to it.
        /// </summary>
        /// <param name="settingsPath"></param>
        private static void CheckFile(string settingsPath)
        {
            if (!File.Exists(settingsPath))
            {
                using (var fs = File.Create(settingsPath)) {}

                Save();
            }
        }

    }
}