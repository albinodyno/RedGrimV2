using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGrimV2.Tools
{
    public static class ColorMaster
    {
        public static Color ColorPrimary { get; set; } = Color.FromArgb("#ffffff");
        public static Color ColorSecondary { get; set; } = Color.FromArgb("#ffffff");
        public static Color ColorWarning { get; set; } = Color.FromArgb("#ffffff");
        public static Color ColorCritical { get; set; } = Color.FromArgb("#ffffff");
        public static Color ColorLabel { get; set; } = Color.FromArgb("#ffffff");
        public static Color ColorText { get; set; } = Color.FromArgb("#ffffff");
        public static Color ColorOn { get; set; } = Color.FromArgb("#ff4500");
        public static Color ColorOnSecondary { get; set; } = Color.FromArgb("#b8860b");
        public static Color ColorOff { get; set; } = Color.FromArgb("#d3d3d3");
        public static Image MainImage { get; set; } = new Image() { Source = ImageSource.FromFile("splash.png") };

        public static void DefaultTheme()
        {
            DarkTheme();
        }

        public static void ChangeTheme(int input)
        {
            switch (input)
            {
                case 0:
                    DarkTheme();
                    break;
                case 1:
                    StealthTheme();
                    break;
                case 2:
                    MobTheme();
                    break;
            }

            //MainImage.Source = ImageSource.FromFile("splash.png");

            //SettingsControl.saveSettings.theme = input;
            //SettingsControl.SaveData();
        }

        public static void DarkTheme()
        {
            ColorPrimary = Color.FromArgb("#00ffff");
            ColorSecondary = Color.FromArgb("#ff00ff");
            ColorWarning = Color.FromArgb("#b8860b");
            ColorCritical = Color.FromArgb("#ff4500");
            ColorLabel = Color.FromArgb("#ffffff");
            ColorText = Color.FromArgb("#b8860b");
            MainImage.Source = ImageSource.FromFile("redgrimGC.png");
        }

        public static void StealthTheme()
        {
            ColorPrimary = Color.FromArgb("#808080");
            ColorSecondary = Color.FromArgb("#ff4500");
            ColorWarning = Color.FromArgb("#ff4500");
            ColorCritical = Color.FromArgb("#ff4500");
            ColorLabel = Color.FromArgb("#ffffff");
            ColorText = Color.FromArgb("#ffffff");
            MainImage.Source = ImageSource.FromFile("redgrimGO.png");
        }

        public static void MobTheme()
        {
            ColorPrimary = Color.FromArgb("#ffffff");
            ColorSecondary = Color.FromArgb("#ff4500");
            ColorWarning = Color.FromArgb("#ff4500");
            ColorCritical = Color.FromArgb("#ff4500");
            ColorLabel = Color.FromArgb("#ffffff");
            ColorText = Color.FromArgb("#ffffff");
            MainImage.Source = ImageSource.FromFile("redgrimGW.png");
        }


    }
}
