using System.Text;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Learning_projects.Tic_tac_toe
{
    public class Config
    {            
        private string path = "Config.json";
        private string cfg = string.Empty;
        private void Check_config()
        {
            if (!File.Exists(path)){
                File.Create(path);
                object settings = new defaultSettings();
                cfg = JsonConvert.SerializeObject(settings);
                File.WriteAllText(path, cfg, new UTF8Encoding(false));
            }
            else{
                object settings = new defaultSettings();
                return;
            }
                
        }

        public string SetConfiguration(int width, int height, bool cursorVisible)
        {
            Check_config();
            cfg = File.ReadAllText(path, new UTF8Encoding(false));
            return cfg;
        }

    }
}