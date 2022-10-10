using Microsoft.Maui.Controls;
using System.Net.Sockets;
using System.Text;
using System;
using RedGrimV2.Tools;
using RedGrimV2.Models;

namespace RedGrimV2;

public partial class SettingsView : ContentView
{
    public static Configuration saveSettings = new Configuration();
    public static Configuration loadedSettings;

    public static bool debugMode = true;

    public SettingsView()
	{
		InitializeComponent();
	}



}