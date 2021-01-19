using System.Diagnostics;
using System.IO.Enumeration;
using System;
using System.Security.AccessControl;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.IO;
namespace Learning_projects.Tic_tac_toe
{
    public class Config
    {
        private int width;
        private int height;

        public int Width { get; }
        public int Height { get; }

        public int Set_width()
        {
            return 600;
        }

        private void Check_config()
        {
            if (!File.Exists("Config.cfg"))
            {
                File.Create("Config.cfg");
                File.OpenWrite("Config.cfg");
                
            }

            else
            {
                
            }
        }

        public int Set_height()
        {
            File.OpenRead("Config.cfg");
            return height;
        }
    }
}