using Newtonsoft.Json;
using System.Collections.Generic;

namespace Learning_projects.Tic_tac_toe
{
    /// <summary>
    /// Данный класс хранит настройки консоли
    /// </summary>
    internal sealed class defaultSettings
    {
        [JsonProperty("Width")]
        static public int Width { get; private set; }
        [JsonProperty("Height")]
        static public int Height { get; private set; }
        [JsonProperty("CursorVisible")] //ToDo: Данный параметр по дефолту должен быть равен false, его надо заменить на другие настройки, такие как цвет консоли
        static public bool CursorVisible { get; private set; }

        public defaultSettings(int width, int height, bool cursorVisible)
        {
            Width = width;
            Height = height;
            CursorVisible = cursorVisible;
        }

        public defaultSettings()
        {
            Width = 60;
            Height = 60;
            CursorVisible = false;
        }

    }
}