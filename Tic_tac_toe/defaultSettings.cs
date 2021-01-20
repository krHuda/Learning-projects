using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Learning_projects.Tic_tac_toe
{
    internal sealed class defaultSettings
    {
        [JsonProperty("width")]
        public int Width { get; private set; }
        [JsonProperty("height")]
        public int Height { get; private set; }
        [JsonProperty("cursorVisible")]
        public bool CursorVisible { get; private set; }

        public defaultSettings(int width, int height, bool cursorVisible)
        {
            this.Width = width;
            this.Height = height;
            this.CursorVisible = cursorVisible;
        }

        public defaultSettings()
        {
            this.Width = 900;
            this.Height = 900;
            this.CursorVisible = false;
        }

    }
}