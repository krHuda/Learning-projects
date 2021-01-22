using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Learning_projects.Tic_tac_toe
{
    internal sealed class defaultSettings
    {
        [JsonProperty("Width")]
        static public int Width { get; private set; }
        [JsonProperty("Height")]
        static public int Height { get; private set; }
        [JsonProperty("CursorVisible")]
        static public bool CursorVisible { get; private set; }


        public defaultSettings(int width, int height, bool cursorVisible)
        {
            Width = width;
            Height = height;
            CursorVisible = cursorVisible;
        }

        public defaultSettings()
        {
            Width = 900;
            Height = 900;
            CursorVisible = false;
        }

    }
}