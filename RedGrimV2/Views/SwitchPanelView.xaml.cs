using Microsoft.Maui.Controls;
using System.Net.Sockets;
using System.Text;
using System;
using RedGrimV2.Tools;

namespace RedGrimV2;

public partial class SwitchPanelView : ContentView
{
    string auxDeviceName = "HC-05";
    bool connected = false;

    public SwitchPanelView()
	{
		InitializeComponent();
	}

    #region Aux Bluetooth Connection
    private async void btnAuxConnect_Clicked(object sender, EventArgs e)
    {
         btnAuxConnect.Text = "Connecting...";

        if (!connected) ConnectSavedDevice();
        else await TestConnection();
    }

    public async void ConnectSavedDevice()
    {
        //try
        //{
        //    //Adapter
        //    adapter = BluetoothAdapter.DefaultAdapter;
        //    if (adapter == null)
        //        throw new Exception("Bluetooth adapter not found.");

        //    if (!adapter.IsEnabled)
        //        throw new Exception("Bluetooth adapter is not enabled.");

        //    //Device
        //    device = (from bd in adapter.BondedDevices where bd.Name == auxDeviceName select bd).FirstOrDefault();
        //    if (device == null) throw new Exception($"Aux device ({auxDeviceName}) not found");

        //    //Socket
        //    socket = device.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
        //    await socket.ConnectAsync();
        //    SuccessfulConnection();
        //}

        //catch (Exception ex)
        //{
        //    FailedAuxConnection(ex.Message);
        //}
    }

    public async Task TestConnection()
    {
        //try
        //{
        //    // Write data to the device
        //    byte[] writeBuffer = Encoding.ASCII.GetBytes("");
        //    await socket.OutputStream.WriteAsync(writeBuffer, 0, writeBuffer.Length);
        //    await socket.OutputStream.FlushAsync();
        //}
        //catch (Exception ex)
        //{
        //    FailedAuxConnection(ex.Message);
        //}
    }

    private async void SuccessfulConnection()
    {
        //try
        //{
        //    connected = true;
        //    tbkAuxStatus.Text = "Connected";
        //    tbkAuxStatus.TextColor = Color.Magenta;
        //    BluetoothControl.SystemLogEntry($"AUX - Connected Successfully", false);
        //}
        //catch (Exception ex)
        //{
        //    FailedAuxConnection(ex.Message);
        //}
    }

    private void FailedAuxConnection(string error)
    {
        //connected = false;
        //if (device != null) device.Dispose();
        //if (socket != null) socket.Close();

        //tbkAuxStatus.Text = "No Connection";
        //tbkAuxStatus.TextColor = Color.OrangeRed;

        //Aux1Off();
        //Aux2Off();
        //Aux3Off();
        //Aux4Off();

        //BluetoothControl.SystemLogEntry($"AUX - {error}", false);
    }

    private async void SendCommand(string input)
    {
        try
        {
            // Write data to the device
            byte[] writeBuffer = Encoding.ASCII.GetBytes(input);
            //await socket.OutputStream.WriteAsync(writeBuffer, 0, writeBuffer.Length);
            //await socket.OutputStream.FlushAsync();
        }
        catch (Exception ex)
        {
            await TestConnection();
        }
    }

    #endregion

    #region Button Events
    private void btnAux1On_Clicked(object sender, EventArgs e) { Aux1On(); }
    private void btnAux2On_Clicked(object sender, EventArgs e) { Aux2On(); }
	private void btnAux3On_Clicked(object sender, EventArgs e) { Aux3On(); }
    private void btnAux4On_Clicked(object sender, EventArgs e) { Aux4On(); }

	private void btnAux1Off_Clicked(object sender, EventArgs e) { Aux1Off(); }
    private void btnAux2Off_Clicked(object sender, EventArgs e) { Aux2Off(); }
	private void btnAux3Off_Clicked(object sender, EventArgs e) { Aux3Off(); }
    private void btnAux4Off_Clicked(object sender, EventArgs e) { Aux4Off(); }

    #endregion

    #region Button Methods

    //ON
    private void Aux1On()
    {
        btnAux1On.IsVisible = false;
        btnAux1Off.IsVisible = true;
        if (connected)
        {
            SendCommand("1");
            bdr1.BorderColor = ColorMaster.ColorOn;
        }
        else
            bdr1.BorderColor = ColorMaster.ColorOnSecondary;
    }

    private void Aux2On()
    {
        btnAux2On.IsVisible = false;
        btnAux2Off.IsVisible = true;
        if (connected)
        {
            SendCommand("2");
            bdr2.BorderColor = ColorMaster.ColorOn;
        }
        else
            bdr2.BorderColor = ColorMaster.ColorOnSecondary;
    }

    private void Aux3On()
    {
        btnAux3On.IsVisible = false;
        btnAux3Off.IsVisible = true;
        if (connected)
        {
            SendCommand("3");
            bdr3.BorderColor = ColorMaster.ColorOn;
        }
        else
            bdr3.BorderColor = ColorMaster.ColorOnSecondary;
    }

    private void Aux4On()
    {
        btnAux4On.IsVisible = false;
        btnAux4Off.IsVisible = true;
        if (connected)
        {
            SendCommand("4");
            bdr4.BorderColor = ColorMaster.ColorOn;
        }
        else
            bdr4.BorderColor = ColorMaster.ColorOnSecondary;
    }


    //OFF
    private void Aux1Off()
    {
        btnAux1Off.IsVisible = false;
        btnAux1On.IsVisible = true;
        bdr1.BorderColor = ColorMaster.ColorOff;
        if (connected) SendCommand("5");
    }

    private void Aux2Off()
    {
        btnAux2Off.IsVisible = false;
        btnAux2On.IsVisible = true;
        bdr2.BorderColor = ColorMaster.ColorOff;
        if (connected) SendCommand("6");
    }

    private void Aux3Off()
    {
        btnAux3Off.IsVisible = false;
        btnAux3On.IsVisible = true;
        bdr3.BorderColor = ColorMaster.ColorOff;
        if (connected) SendCommand("7");
    }

    private void Aux4Off()
    {
        btnAux4Off.IsVisible = false;
        btnAux4On.IsVisible = true;
        bdr4.BorderColor = ColorMaster.ColorOff;
        if (connected) SendCommand("8");
    }

    //EFFECTS
    private void btnAuxEffects_Clicked(object sender, EventArgs e)
    {
        if (pnlEffects.IsVisible) pnlEffects.IsVisible = false;
        else pnlEffects.IsVisible = true;
    }


    #endregion

}