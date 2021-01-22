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

        public void SetConfiguration()
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    object settings = new defaultSettings();
                    cfg = JsonConvert.SerializeObject(settings);
                    sw.WriteLine(cfg);
                    sw.Close();
                }
                Console.WriteLine("Файл настроек не найден! Сгенерированы настройки по умолчанию.");

            }
            else
            {
                string fileSettings = File.ReadAllText(path, new UTF8Encoding(false));
                var readedSettings = JsonConvert.DeserializeObject<defaultSettings>(fileSettings);
                Console.WriteLine("Файл настроек загружен.");
                Console.WriteLine($"Ширина = {defaultSettings.Width}, Высота = {defaultSettings.Height}, Видимость курсора = {defaultSettings.CursorVisible}");
            }
        }

        /*public (int width, int height) GetConfiguration(){
            return (defaultSettings.Height, defaultSettings.Width);
        }*/

    }
}